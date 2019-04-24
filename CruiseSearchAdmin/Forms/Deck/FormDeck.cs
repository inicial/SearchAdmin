using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Forms.Deck;using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Deck
{
    public partial class FormDeck : ProjectForm
    {
        private int _shipId;
        private DataTable decks;

        public FormDeck(int Ship_id)
        {
            InitializeComponent();
            _shipId = Ship_id;
            GetDate();
        }

        private void GetDate()
        {
            string selQuery =
                string.Format("select id,ship_id,name_ru,name_en,code,Deck_nomber from Decks where ship_id = {0} order by Deck_nomber",
                              _shipId);
            decks = WorkWithData.GetDataTable(selQuery);
            dgvDeck.DataSource = decks;
            UpdateDeckGrid();
        }

        void UpdateDeckGrid()
        {
            foreach (DataGridViewColumn column in dgvDeck.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "code":
                        {
                            column.HeaderText = "Код палубы";
                            column.MinimumWidth = dgvDeck.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 0;
                        }
                        break;
                    case "name_en":
                        {
                            column.HeaderText = "Наименование палубы";
                            column.MinimumWidth = dgvDeck.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 1;
                        }
                        break;
                    case "deck_nomber":
                        {
                            column.HeaderText = "Номер палубы";
                            column.MinimumWidth = dgvDeck.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 2;
                        }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void btnAddDeck_Click(object sender, EventArgs e)
        {
            gbInfo.Text = "Добавление палубы";
            tbCode.Text = string.Empty;
            tbDeck_nomber.Text = "1";
            tbName_en.Text = "New Deck";
            tbName_ru.Text = "Новая палуба";
            gbInfo.Enabled = true;
            dgvDeck.Enabled = false;
        }

        private void btnRemoveDeck_Click(object sender, EventArgs e)
        {
            if (dgvDeck.SelectedRows.Count < 1)
            {Messages.Error("Сначало выберете палубу!");
                return;
            }
            if (!Messages.Question("Вы уверены что хотите удалить палубу " + dgvDeck.SelectedRows[0].Cells["name_en"].Value.ToString() ))
            {
               return; 
            }
            string delDeck = "delete from Decks where id =" + dgvDeck.SelectedRows[0].Cells["id"].Value.ToString();
            delDeck.ExecuteNonQuery(WorkWithData.TsConnection);
            GetDate();
        }

        private void btnEditDeck_Click(object sender, EventArgs e)
        {
            gbInfo.Text = "Изменение палубы";
            tbCode.Text =Convert.ToString( dgvDeck.SelectedRows[0].Cells["Code"].Value);
            tbDeck_nomber.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Deck_nomber"].Value);
            tbName_en.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Name_en"].Value);
            tbName_ru.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Name_ru"].Value);
            gbInfo.Enabled = true;
            dgvDeck.Enabled = false;
        }

        private void dgvDeck_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDeck.SelectedRows.Count > 0)
            {
                gbInfo.Text = "Подробно";
                tbCode.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Code"].Value);
                tbDeck_nomber.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Deck_nomber"].Value);
                tbName_en.Text = Convert.ToString(dgvDeck.SelectedRows[0].Cells["Name_en"].Value);
                tbName_ru.Text =Convert.ToString( dgvDeck.SelectedRows[0].Cells["Name_ru"].Value);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbInfo.Enabled = false;
            dgvDeck.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (gbInfo.Text == "Изменение палубы")
            {
                string editdeck = @"update decks set
                                    name_ru = @p0,
                                    name_en = @p1,
                                    code=@p2,
                                    deck_nomber=@p3
                                    where id=@p4";
                SqlCommand ad = new SqlCommand(editdeck,WorkWithData.TsConnection);
                ad.Parameters.AddWithValue("@p0", tbName_ru.Text);
                ad.Parameters.AddWithValue("@p1", tbName_en.Text);
                ad.Parameters.AddWithValue("@p2", tbCode.Text);
                ad.Parameters.AddWithValue("@p3", tbDeck_nomber.Text);
                ad.Parameters.AddWithValue("@p4", dgvDeck.SelectedRows[0].Cells["id"].Value);
                ad.ExecuteNonQuery();
            }
            else
            {
                if (gbInfo.Text == "Добавление палубы")
                {
                    string insdeck = @"insert into Decks(name_ru,name_en,code,Deck_nomber,ship_id) values(@p0,@p1,@p2,@p3,@p4)";
                    SqlCommand ad = new SqlCommand(insdeck, WorkWithData.TsConnection);
                    ad.Parameters.AddWithValue("@p0", tbName_ru.Text);
                    ad.Parameters.AddWithValue("@p1", tbName_en.Text);
                    ad.Parameters.AddWithValue("@p2", tbCode.Text);
                    ad.Parameters.AddWithValue("@p3", tbDeck_nomber.Text);
                    ad.Parameters.AddWithValue("@p4", _shipId);
                    ad.ExecuteNonQuery();  
                }
            }
            dgvDeck.Enabled = true;
            gbInfo.Enabled = false;
            GetDate();
        }

        private void btnCabins_Click(object sender, EventArgs e)
        {
            if (dgvDeck.SelectedRows.Count > 0)
            {
                int deckid = Convert.ToInt32(dgvDeck.SelectedRows[0].Cells["id"].Value);
                FormCabinByDeck form = new FormCabinByDeck(_shipId,deckid);
                form.ShowDialog();
            }
            else
            {
                Messages.Error("Сначало выберете палубу!");}
            
        }
    }
}
