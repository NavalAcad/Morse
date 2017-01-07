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
    /// Class for saved data. 
    /// Inquares from the user to write a key for the data he wants to save.
    /// </summary>
    public partial class Form5 : Form
    {
        private string text;
        private Database database;

        public Form5(Database database, string text)
        {
            InitializeComponent();
            this.database = database;
            this.text = text;
        }

        /// <summary>
        /// Cancel button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save button. 
        /// Saves the wanted text with the given key in the database if there is no other text with the same key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            try
            {
                this.database.AddRecord(name, text);
                MessageBox.Show("Text saved successfully!", "My Application",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch(DuplicateWaitObjectException ex)
            {
                MessageBox.Show(ex.Message, "My Application",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
