using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfflineRadio.Models;




namespace OfflineRadio.Forms
{
    public partial class AddProgramForm : Form
    {
        public RadioProgram NewProgram { get; private set; }

        public AddProgramForm()
        {
            InitializeComponent();
        }

        public static class DurationParser
        {
            public static TimeSpan Parse(string input)
            {
                // Define regex patterns for "hours", "minutes", and "seconds"
                var hoursPattern = new Regex(@"(\d+)\s*hour", RegexOptions.IgnoreCase);
                var minutesPattern = new Regex(@"(\d+)\s*min", RegexOptions.IgnoreCase);
                var secondsPattern = new Regex(@"(\d+)\s*sec", RegexOptions.IgnoreCase);

                int hours = 0, minutes = 0, seconds = 0;

                // Match hours
                var hoursMatch = hoursPattern.Match(input);
                if (hoursMatch.Success)
                {
                    hours = int.Parse(hoursMatch.Groups[1].Value);
                }

                // Match minutes
                var minutesMatch = minutesPattern.Match(input);
                if (minutesMatch.Success)
                {
                    minutes = int.Parse(minutesMatch.Groups[1].Value);
                }

                // Match seconds
                var secondsMatch = secondsPattern.Match(input);
                if (secondsMatch.Success)
                {
                    seconds = int.Parse(secondsMatch.Groups[1].Value);
                }

                // Convert to TimeSpan
                return new TimeSpan(hours, minutes, seconds);
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtURL.Text))
            {
                MessageBox.Show("Please fill all fields.", "Error");
                return;
            }

            TimeSpan duration;
            try
            {
                duration = DurationParser.Parse(txtDuration.Text); // Use the custom parser
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid duration format. Please use formats like '15 mins' or '1 hour'.", "Error");
                return;
            }

            NewProgram = new RadioProgram
            {
                Title = txtTitle.Text,
                URL = txtURL.Text,
                Duration = duration,
                LastDownloaded = DateTime.MinValue,
                FilePath = string.Empty
            };

            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
