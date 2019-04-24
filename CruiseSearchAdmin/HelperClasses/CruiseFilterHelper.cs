using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;

namespace CruiseSearchAdmin.HelperClasses
{
    public static class CruiseFilterHelper
    {
       
        private static void GetShipFilter(ComboBox cbShips, ref List<Ship> ships)
        {
            var sDT = WorkWithData.GetDataTable(@"select * from Ships order by name_en");
            if(ships==null){ships = new List<Ship>();}
            ships.Clear();
            ships.Add(new Ship(0, "All", 0, string.Empty,null));
            ships.AddRange((from DataRow row in sDT.Rows
                               let id = Convert.ToInt32(row["id"])
                               let name_en = row["name_en"].ToString()
                               let crid = Convert.ToInt32(row["cruise_line_id"])
                               let sc = row["code"].ToString()
                               select new Ship(id, name_en, crid, sc,null)).ToList());
            
            if (ships.Count < 1) return;
            cbShips.DataSource = ships;
            cbShips.DisplayMember = "Name";
            cbShips.ValueMember = "id";
            cbShips.SelectedIndex = 0;
        }
        private static void GetCruiseLineFilter(ComboBox cbCruiseLines, ref List<CruiseLine> cruiseLines)
        {
            var clDT = WorkWithData.GetDataTable(@"select * from CruiseLines order by name_en");
            if (cruiseLines == null) { cruiseLines = new List<CruiseLine>(); }
            cruiseLines.Clear();
            cruiseLines.Add(new CruiseLine(0,"All", "", "all","" , 0, WorkWithData.TsConnection));
            cruiseLines.AddRange((from DataRow row in clDT.Rows
                            let id = Convert.ToInt32(row["id"])
                            let name_en = row["name_en"].ToString()
                            let mnemo = row["mnemo"].ToString()
                                  select new CruiseLine(id, name_en, "", mnemo,"", 0, WorkWithData.TsConnection)).ToList());
            if (cruiseLines.Count < 1) return;
            cbCruiseLines.DataSource = cruiseLines;cbCruiseLines.DisplayMember = "EnName";
            cbCruiseLines.ValueMember = "mnemo";
            cbCruiseLines.SelectedIndex = 0;
        }
        private static void GetRegionFilter(ComboBox cbRegions, ref List<ItRegion> filterRegions)
        {
            var rDT = WorkWithData.GetDataTable(@"declare @maxorder int 
                                                 select @maxorder=MAX(ordrer) from regions 
                                                 SELECT     id, code, case when parent IS not null then '---'+ name_ru else name_ru end as name_ru, name_en, visible, parent, ordrer
                                                 FROM         Regions as r
                                                 ORDER BY (select [ordrer] from regions where id = isnull(r. parent,r.id)), CASE WHEN parent IS NULL THEN ordrer ELSE ordrer + @maxorder END");
            if (filterRegions == null) { filterRegions = new List<ItRegion>(); }
            filterRegions.Clear();
            filterRegions.Add(new ItRegion(0, "All"));
            filterRegions.Add(new ItRegion(-1, "Без регионов"));
            filterRegions.AddRange((from DataRow row in rDT.Rows
                                let id = Convert.ToInt32(row["id"])
                                let name_ru = row["name_ru"].ToString()
                                select new ItRegion(id, name_ru)).ToList());

            if (filterRegions.Count < 1) return;
            cbRegions.DataSource = filterRegions;
            cbRegions.DisplayMember = "Name";
            cbRegions.ValueMember = "id";
            cbRegions.SelectedIndex = 0;
        }

        public static void GetActionGroupFilter(ComboBox cbGactions)
        {
            var actionTbl = WorkWithData.GetDataTable(@"select id,Name from Actions_visible_group ");
            
            DataRow dr = actionTbl.NewRow();
            dr["id"] = 0;
            dr["Name"] = "All";
            actionTbl.Rows.InsertAt(dr, 0);
            dr = actionTbl.NewRow();
            dr["id"] = -1;
            dr["Name"] = "Без тематики";
            actionTbl.Rows.InsertAt(dr, 1);
            cbGactions.DataSource = actionTbl;
            cbGactions.DisplayMember = "Name";
            cbGactions.ValueMember = "id";cbGactions.SelectedIndex = 0;
            


        }
        
        public static void GetActionFilter(ComboBox cbActions,int id_group)
        {
            var actionTbl = WorkWithData.GetDataTable(
            string.Format(@"select * from 
                                                     (select * from
                                                     (select Actions_visible_group.id,Actions_visible_group.Name,SUM(mk_tbVisibleTypes.VT_MASK)as summask 
                                                    from Actions_visible_group inner join dbo.mk_tbVisibleTypes on Actions_visible_group.id =mk_tbVisibleTypes.VT_id_group
                                                    group by Actions_visible_group.id,Actions_visible_group.Name)as grm inner join Actions as a on (a.action_visible_type & summask) >0
                                                    where id={0}
                                                    
                                                    union
                                                    select 5 ,'Без группы',0,Actions.* from Actions where (action_visible_type=0 or action_visible_type is null) and 5={0}
                                                   ) as t1 order by t1.id,action_text
                                                     
                                                   ", id_group));
            DataRow dr = actionTbl.NewRow();
            dr["action_id"] = 0;
            dr["action_text"] = "All";
            actionTbl.Rows.InsertAt(dr, 0);
            cbActions.DataSource = actionTbl;
            cbActions.DisplayMember = "action_text";
            cbActions.ValueMember = "action_Id";
            cbActions.SelectedIndex = 0;
        }
       
        /// <summary>
        /// Форматирование таблицы для отображения круизов
        /// </summary>
        /// <param name="dgvCruises">Элемент управления таблица</param>
        public static void SetCruiseGrid(DataGridView dgvCruises)
        {
            foreach (DataGridViewColumn column in dgvCruises.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "saildate":
                        {
                            column.HeaderText = "Дата";
                            column.Width = 75;
                            column.Resizable = DataGridViewTriState.False;
                        }
                        break;
                    case "depporten":
                        {
                            column.MinimumWidth = 90;
                            column.HeaderText = "Порт отправления";
                        }
                        break;
                    case "itinerary":
                        {
                            column.MinimumWidth = 100;
                            column.HeaderText = "Маршрут";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        break;
                    case "crlnen":
                        {
                            column.MinimumWidth = 80;
                            column.HeaderText = "Круизная компания";
                        }
                        break;
                    case "shipen":
                        {
                            column.MinimumWidth = 60;
                            column.HeaderText = "Лайнер";
                        }
                        break;
                    case "duration":
                        {
                            column.HeaderText = "Дни";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.Width = 40;
                            column.Resizable = DataGridViewTriState.False;
                        }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Установка круизного фильтра
        /// </summary>
        /// <param name="cbShips">ComboBox "Лайнер"</param>
        /// <param name="ships">Коллекция лайнеров</param>
        /// <param name="cbCruiseLines">ComboBox "Круизная компания"</param>
        /// <param name="cruiseLines">Коллекция круизных компаний</param>
        /// <param name="cbRegs">ComboBox "Регион"</param>
        /// <param name="filterRegions">Коллекция регионов</param>
        /// <param name="cbActions">ComboBox "Акция"</param>
        public static void GetFilterData(ComboBox cbShips, ref List<Ship> ships, ComboBox cbCruiseLines, ref List<CruiseLine> cruiseLines, ComboBox cbRegs, ref List<ItRegion> filterRegions,ComboBox cbActions)
        {
            if(cbShips!=null)
            GetShipFilter(cbShips, ref ships);
            if (cbCruiseLines != null)
            GetCruiseLineFilter(cbCruiseLines, ref cruiseLines);
            if (cbRegs != null)
            GetRegionFilter(cbRegs, ref filterRegions);
            if (cbActions != null)
            GetActionGroupFilter(cbActions);
        }
       
    }
}
