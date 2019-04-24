using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseSearchAdmin.Controls
{
    public partial class ExtendedMonthCalendar : MonthCalendar
    {
        private readonly List<DateTime> _selectedDates = new List<DateTime>();
        public ExtendedMonthCalendar()
        {
            InitializeComponent();
            
            DateSelected += CustomSelection;
        }

        private void CustomSelection(object sender, DateRangeEventArgs e)
        {
           
        }

       
        
    }
}
