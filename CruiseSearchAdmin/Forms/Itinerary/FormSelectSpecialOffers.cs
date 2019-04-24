using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Itinerary
{
    public partial class FormSelectSpecialOffers : ProjectForm
    {
        public FormSelectSpecialOffers()
        {
            InitializeComponent();
            btnOK.Click += (s, e) =>
                               {
                                   DialogResult = DialogResult.OK;
                                   Close();
                               };
            btnCancel.Click += (s, e) =>
                             {
                                 DialogResult = DialogResult.Cancel;
                                 Close();
                             };
        }
        public static int GetSpecialOffer(List<SpecialOffer> specialOffers)
        {
            using(var f = new FormSelectSpecialOffers())
            {
                f.cbSpecOffers.DataSource = specialOffers;
                f.cbSpecOffers.ValueMember = "Id";
                f.cbSpecOffers.DisplayMember = "Text";
                if (f.ShowDialog() == DialogResult.OK) return (int)f.cbSpecOffers.SelectedValue;
                else return -1;
            }
        }
    }
}
