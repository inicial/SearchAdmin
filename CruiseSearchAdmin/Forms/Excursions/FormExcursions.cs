using System;
using System.Linq;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms.SynchronizationForms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormExcursions : ProjectForm
    {private Seaport _seaPort;
        private ExcursionsCollection _excursions = new ExcursionsCollection();
       
        private FormExcursions()
        {
            InitializeComponent();
        }
        void GetData()
        {
            _excursions.GetItems(WorkWithData.TsConnection);
        }

        void UpdateDgvByPort(Seaport port)
        {
            if (port == null) return;
            dgvExcursions.DataSource = _excursions.Where((Excursion ex) => ex.PortID == port.ID).ToList();
            tbPortName.Text = port.Name;
            SetExcursionsGrid();
        }

        public static  void GetExcursions()
        {
            using(var f = new FormExcursions())
            {
                f.ShowDialog();
            }
        }

        private void FormExcursions_Load(object sender, EventArgs e)
        {
            _seaPort = FormSelectPort.SelectSeaPort();
            if(_seaPort==null)this.Close();
            GetData();
            UpdateDgvByPort(_seaPort);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var sp = FormSelectPort.SelectSeaPort();
            if (sp == null) return;
            if (sp.ID == _seaPort.ID) return;
            _seaPort = sp;
            UpdateDgvByPort(_seaPort);
        }
        void SetExcursionsGrid()
        {
            foreach (DataGridViewColumn column in dgvExcursions.Columns)
            {
                var n = column.Name.ToLower();
                switch(n)
                {
                    case "text":
                        {
                            column.MinimumWidth = 200;column.HeaderText = "Название";
                        }
                        break;
                    case "duration":
                        {
                            column.MinimumWidth = 150;
                            column.HeaderText = "Продолжительность";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        break;
                    case "description":
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.HeaderText = "Описание";
                        }
                        break;
                    default:
                        {
                            column.Visible = false;
                        }
                        break;
                }

            }
        }

        private void btnRemoveExcursion_Click(object sender, EventArgs e)
        {
            if (dgvExcursions.SelectedRows.Count < 1)
            {
                Messages.Error("Сначала нужно выбрать экскурсию");
                return;
            }
            var excursion = dgvExcursions.SelectedRows[0].DataBoundItem as Excursion;
            if (excursion == null)
            {
                Messages.Information("Не удалось выбрать экскурсию");
                return;
            }
            if (!Messages.Question("Вы действительно хотите удалить данную экскурсию?")) return;
            var dt =
                WorkWithData.GetDataTable(@"select * from [dbo].[mk_tbPartnerExcursions] where [EX_UID] = " + excursion.ID);
            if (dt.Rows.Count > 0)
            {
                Messages.Error("Данную экскурсию нельзя удалить, пока она не будет пустой!");
                return;
            }
            excursion.DeleteExcursion(WorkWithData.TsConnection);
            GetData();
            UpdateDgvByPort(_seaPort);
        }

        private void btnEditExcursion_Click(object sender, EventArgs e)
        {
            if(dgvExcursions.SelectedRows.Count<1)
            {
                Messages.Error("Сначала нужно выбрать экскурсию");
                return;
            }
            var excursion = dgvExcursions.SelectedRows[0].DataBoundItem as Excursion;
            if (excursion == null) 
            { 
                Messages.Information("Не удалось выбрать экскурсию");
                return;
            }
            if(!FormEditExcursion.EditExcursion(excursion,_excursions))return;
            excursion.UpdateExcursion(WorkWithData.TsConnection);
            GetData();
            UpdateDgvByPort(_seaPort);
        }

        private void btnAddExcursion_Click(object sender, EventArgs e)
        {
            var excursion = new Excursion();
            excursion.PortID = _seaPort.ID;
            excursion.PortName = _seaPort.Name;
            if (!FormEditExcursion.EditExcursion(excursion,_excursions)) return;
           excursion.InsertExcursion(WorkWithData.TsConnection);
           
            GetData();
            UpdateDgvByPort(_seaPort);
        }

       

        private void dgvExcursions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var excur = (sender as DataGridView).Rows[e.RowIndex].DataBoundItem as Excursion;
            if (excur == null) return;
            Hide();
            FormPartnerExcursions.GetPartnerExcursions(excur, _excursions);Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
