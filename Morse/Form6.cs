using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morse
{
    /// <summary>
    /// Class for reading the saved data from database by key.
    /// Options for loading or deleting the records.
    /// </summary>
    public partial class Form6 : Form
    {
        private Form4 backForm;
        private string key;
        private Database database;
        private MorseCode morseCode;

        public Form6(Form4 otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;

        }

        public Form6(Form4 otherForm, MorseCode morseCode ,Database database, string key)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.database = database;
            this.key = key;
            this.morseCode = morseCode;

            var list = new List<string>();
            list.Add(this.database.GetRecord(key));
            listBox1.DataSource = list;
        }

        /// <summary>
        /// Saves the database in the text file when the windows is closed with the red cross
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    this.database.SaveDatabase();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Delete button.
        /// Deletes the saved record from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.database.DeleteRecord(this.key);
            this.backForm.Show();
            this.backForm.ShowDatabase();
            this.Hide();
        }

        /// <summary>
        /// Load button.
        /// Loads the text in the Send Morse Code option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string text = listBox1.Text;
            Form2 sendForm = new Form2(this, this.morseCode, this.database, text);
            sendForm.Show();
            this.Hide();
        }
    }
}
