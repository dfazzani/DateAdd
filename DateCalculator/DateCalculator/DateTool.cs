using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DateCalculator
{
    public partial class DateTool : Form
    {
        public DateTool()
        {
            InitializeComponent();
        }

        private void butCalculate_Click(object sender, EventArgs e)
        {
            ValidateDays();
        }

        private void ValidateDays()
        {
            int daysInt;
            if (Int32.TryParse(txtDaysToAdd.Text, out daysInt))
                ValidateDate();
            else
                MessageBox.Show("Please enter a valid number of days");
        }

        private void ValidateDate()
        {
            if (!string.IsNullOrEmpty(txtDateInput.Text))
            {
                DateTime entryDate;
                if (DateTime.TryParseExact(txtDateInput.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out entryDate))
                {
                    ConvertToUnix();
                }
                else
                {
                    MessageBox.Show("Please enter a valid date");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid date");
            }
        }

        public void ConvertToUnix()
        {
            DateTime cDate = Convert.ToDateTime(txtDateInput.Text);
            Int32 unixTimestamp = (Int32)(cDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            int secs = (24 * 60 * 60) * Convert.ToInt32(txtDaysToAdd.Text);

            unixTimestamp = unixTimestamp + secs;
            ConvertToCalendar(unixTimestamp);
        }

        public void ConvertToCalendar(double unixTimeStamp)
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            dateTime = dateTime.AddSeconds(unixTimeStamp);

            string printDate = dateTime.ToShortDateString();

            txtResults.Text = printDate;
        }

      }

}
