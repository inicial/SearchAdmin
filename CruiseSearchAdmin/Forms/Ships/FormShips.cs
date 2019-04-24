using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Deck;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Forms.CabineCatigories;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Ships
{
    public partial class FormShips :ProjectForm
    {
        private WorkMode _workMode;
        private ShipsCollection _ships  = new ShipsCollection();
        private CruiseLine _cruiseLine;
        private CruiseLinesCollection _cruiseLines = new CruiseLinesCollection();
        private SqlConnection _connection;
        private Ship _selectedShip;
        private FormShips()
        {
            InitializeComponent();
            //DownloadCruiseLines();
            
            
        }
        static public void ManageShips(CruiseLine cruiseLine)
        {using(var f = new FormShips())
            {
                f._cruiseLine = cruiseLine;
                f._ships = cruiseLine.Ships;
                f._connection = cruiseLine.Connection;
                f.GetData();
                f.ShowDialog();
            }
        }

        void GetData()
        {
            _cruiseLines.GetItems(_connection);
            _cruiseLine.GetShips();
            var sCruiseLine = _cruiseLines.ToList();
            cbShipCruiseLine.SetDataSource(sCruiseLine, "ID", "EnName");
            RefreshShipsGrid();
        }
        void RefreshShipsGrid()
        {
            dgvShips.DataSource = null;
            dgvShips.DataSource = _ships;
            UpdateShipsGrid();
        }
        void UpdateShipsGrid()
        {
            foreach (DataGridViewColumn column in dgvShips.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "name" :
                        {
                            column.HeaderText = "Лайнер";
                            column.MinimumWidth = dgvShips.Width/2-30;
                            column.Resizable = DataGridViewTriState.False;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 0;
                        }
                        break;
                    case "cruiselinename":
                        {
                            column.HeaderText = "Круизная компания";
                            column.MinimumWidth = dgvShips.Width / 2-30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 1;
                        }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }
        private void SwitchWorkMode(WorkMode wm)
        {
            gbShips.Enabled = !gbShips.Enabled;
            gbInfo.Enabled = !gbInfo.Enabled;
            _workMode = wm;
        }

        private void btnEditShip_Click(object sender, EventArgs e)
        {
            var formName = this.Name;
            if (dgvShips.SelectedRows.Count < 1)
            {
                Messages.Error("Выбирите лайнер");
                return; 
            }
            this.Name = this.Name + " - " + "Редактирование*";
            SwitchWorkMode(WorkMode.Edit);
            var selectedShip = dgvShips.SelectedRows[0].DataBoundItem as Ship;
            tbShipName.Text = selectedShip.Name;
            tbShipCode.Text = selectedShip.Code;
            cbShipCruiseLine.SelectedValue = selectedShip.CruiseLineID;
            chbShipVisible.Checked = !selectedShip.Visible;
            this.Name = formName;

        }

        private void btnCommitEdit_Click(object sender, EventArgs e)
        {
            if (dgvShips.SelectedRows.Count>0)
            _selectedShip = dgvShips.SelectedRows[0].DataBoundItem as Ship;
            if(_workMode==WorkMode.Add)
            {
                InsertShip();
            }
            if(_workMode==WorkMode.Edit)
            {
                UpdateShip();
            }
            GetData();
            SwitchWorkMode(WorkMode.None);
        }
        private void UpdateShip()
        {
            
            if (_selectedShip == null) return;
            if(tbShipName.Text.Equals(string.Empty))
            {
                Messages.Error("Название не может быть пустым");
                return;
            }
            if(tbShipName.Text.Length<3)
            {
                 Messages.Error("Название Должно быть не менее 3-х символов");
                return;
            }
            if(tbShipCode.Text.Equals(string.Empty))
            {
                tbShipCode.Text = tbShipName.Text.Substring(0, 3);
            }
            _selectedShip.Name = tbShipName.Text;
            _selectedShip.CruiseLineID = (int)cbShipCruiseLine.SelectedValue;
            _selectedShip.Code = tbShipCode.Text;
            _selectedShip.Visible = !chbShipVisible.Checked;
            _selectedShip.Update();
        }
        private void InsertShip()
        {
            if (tbShipName.Text.Equals(string.Empty))
            {
                Messages.Error("Название не может быть пустым");
                return;
            }
            if (tbShipName.Text.Length < 3)
            {
                Messages.Error("Название Должно быть не менее 3-х символов");
                return;
            }
            if (tbShipCode.Text.Equals(string.Empty))
            {
                tbShipCode.Text = tbShipName.Text.Substring(0, 3);
            }
            Ship ship = new Ship(-1, tbShipName.Text, (int)cbShipCruiseLine.SelectedValue, tbShipCode.Text, !chbShipVisible.Checked,_cruiseLine.Connection);
            ship.Insert();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            SwitchWorkMode(WorkMode.None);
        }

        private void dgvShips_SelectionChanged(object sender, EventArgs e)
        {
            string name, code;
            int cruiseLine;
            bool check = false; 

            if (dgvShips.SelectedRows.Count < 1)
            {
                name = string.Empty;
                code = string.Empty;
                cruiseLine = 0;
            }
            else
            {
                var selectedShip = ((DataGridView)sender).SelectedRows[0].DataBoundItem as Ship;
                if (selectedShip == null) return;
                name = selectedShip.Name;
                code = selectedShip.Code;
                cruiseLine = selectedShip.CruiseLineID;
                check = !selectedShip.Visible;
            }

            tbShipName.Text = name;
            tbShipCode.Text = code;
            chbShipVisible.Checked = check;if (cbShipCruiseLine.Items.Count < 1) return;
            if (cruiseLine != 0)
                cbShipCruiseLine.SelectedValue = cruiseLine;
            else cbShipCruiseLine.SelectedIndex = 0;
        }

        private void dgvShips_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditShip_Click(btnEditShip,e);
        }

        private void btnAddShip_Click(object sender, EventArgs e)
        {
            SwitchWorkMode(WorkMode.Add);
            cbShipCruiseLine.SelectedIndex = 0;
            tbShipName.Text = string.Empty;
            tbShipCode.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveShip_Click(object sender, EventArgs e)
        {
            if(dgvShips.SelectedRows.Count<1)
            {
                Messages.Error("Сначала следует выбрать лайнер");
                return;
            }
            Ship ship = dgvShips.SelectedRows[0].DataBoundItem as Ship;
            if (ship == null) return;
            string deleteShipQuery = @"delete from Ships where id=@p0";
            deleteShipQuery.ExecuteNonQuery(ship.ID);
            GetData();
        }

        private void btnCabineCatigories_Click(object sender, EventArgs e)
        {
            if (dgvShips.SelectedRows.Count >= 1)
            {

                Ship ship = dgvShips.SelectedRows[0].DataBoundItem as Ship;
                FormCabineCatigories cabineCatigories = new FormCabineCatigories(ship.ID);
                this.Hide();
                cabineCatigories.ShowDialog();
                this.Show();
            }
            else
            {
                Messages.Error("Сначала следует выбрать лайнер");
                return;
            }
        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            if (dgvShips.SelectedRows.Count >= 1)
            {

                Ship ship = dgvShips.SelectedRows[0].DataBoundItem as Ship;
                FormDeck cabineCatigories = new FormDeck(ship.ID);
                this.Hide();
                cabineCatigories.ShowDialog();
                this.Show();}
            else
            {
                Messages.Error("Сначала следует выбрать лайнер");
                return;
            }
        }
    }
}
