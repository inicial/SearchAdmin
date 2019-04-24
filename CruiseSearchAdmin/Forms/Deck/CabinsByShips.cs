using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Deck
{
    public partial class CabinsByShips : ProjectForm
    {
        private int _ship,_deck;
        private DataTable _cabis;
        public CabinsByShips(int id_ship,int id_deck)
        {
            InitializeComponent();
            _deck = id_deck;
            _ship = id_ship;
            GetDate();
        }

        void GetDate()
        {
            _cabis = WorkWithData.GetDataTable(@"Select id,code from CabinCategories where ship_id = " +_ship.ToString());
            lbCabins.DataSource = _cabis;
            lbCabins.DisplayMember = "code";
            lbCabins.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbCabins.SelectedItems.Count < 1)
            {
                Messages.Error("Сначало выберете категорию!");
                return;
            }
            try
            {
                SqlCommand com = new SqlCommand(@"insert into Cabins_By_Deck(ship_id,deck_id,cabin_id) values(@p0,@p1,@p2)",WorkWithData.TsConnection);
                com.Parameters.AddWithValue("@p0", _ship);
                com.Parameters.AddWithValue("@p1", _deck);
                com.Parameters.AddWithValue("@p2", lbCabins.SelectedValue.ToString());
                com.ExecuteNonQuery();

            }
            catch (Exception)
            {

                Messages.Error("Данная категория уже добавлена на эту палубу!");
            }
        }
        
        
    }
}
