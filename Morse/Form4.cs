﻿using System;
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
    /// Class for the Saved Data option.
    /// Displays the keys for the saved records.
    /// Options for reading and deleting the saved records.
    /// </summary>
    public partial class Form4 : Form
    {
        private Form backForm;
        private MorseCode morseCode;
        private Database database;

        public Form4(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;

        }

        public Form4(Form otherForm, MorseCode morseCode, Database database)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
            this.database = database;
        }

        /// <summary>
        /// Gets all the data from the database and displays it
        /// </summary>
        public void ShowDatabase()
        {
            var list = new List<string>();
            foreach (KeyValuePair<string, string> pair  in this.database.GetAllRecords())
            {
                list.Add(pair.Key);
            }

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
        private void button1_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Read button.
        /// Opens a new Form where the text behind the key is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string key = listBox1.SelectedItem.ToString();
            Form6 dialog = new Form6(this, this.morseCode ,this.database, key);
            dialog.Show();
            this.Hide();
        }

        /// <summary>
        /// Delete button.
        /// Deletes the saved record from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string key = listBox1.SelectedItem.ToString();
            this.database.DeleteRecord(key);
            ShowDatabase();
        }

        /// <summary>
        /// Displays the content of the database when the Form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            ShowDatabase();
        }

    }
}