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
    public partial class FormCabinByDeck : ProjectForm
    {
        private int _ship, _deck;
        private DataTable _cabins = new DataTable();
        public FormCabinByDeck(int ship,int deck)
        {
            InitializeComponent();
            _deck = deck;
            _ship = ship;
            GetDate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetDate()
        {
            SqlCommand com = new SqlCommand(@"select id,code from Cabins_By_Deck inner join CabinCategories on cabin_id = id 
                                            where Cabins_By_Deck.ship_id =@p0 and Cabins_By_Deck.deck_id = @p1",WorkWithData.TsConnection);
            com.Parameters.AddWithValue("@p0", _ship);
            com.Parameters.AddWithValue("@p1", _deck);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            _cabins.Clear();
            adapter.Fill(_cabins);
            lbCabins.DataSource = _cabins;
            lbCabins.DisplayMember = "code";
            lbCabins.ValueMember = "id";


        } 

        private void btnAddCabin_Click(object sender, EventArgs e)
        {
           CabinsByShips form = new CabinsByShips(_ship,_deck);
            form.ShowDialog();
            GetDate();
        }

        private void btnRemoveCabin_Click(object sender, EventArgs e)
        {
            if (lbCabins.SelectedItems.Count > 0)
            {
                DataRowView row = lbCabins.SelectedItem as DataRowView;
                if (Messages.Question("Вы уверены что хотите удалить категорию  " + row.Row.Field<string>("code") + " с этой палубы?"))
                {
                    SqlCommand com = new SqlCommand(@"delete from Cabins_By_Deck where ship_id = @p0 and deck_id = @p1 and cabin_id = @p2", WorkWithData.TsConnection);
                    com.Parameters.AddWithValue("@p0", _ship);
                    com.Parameters.AddWithValue("@p1", _deck);
                    com.Parameters.AddWithValue("@p2", lbCabins.SelectedValue.ToString());
                    com.ExecuteNonQuery();
                    GetDate();
                }
            }
            else
            {
                Messages.Error("Сначало нужно выбрать категорию!");

            }
        }

     }
}
