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
    /// Class for the Send Morse Code option.
    /// Options for sending text by morse code and saving the text in the database.
    /// </summary>
    public partial class Form2 : Form
    {
        private Form backForm;
        private MorseCode morseCode;
        private Database database;
        private string initialText;

        public Form2(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;
           
        }

        public Form2(Form otherForm, MorseCode morseCode, Database database, string initialText)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
            this.database = database;
            this.initialText = initialText;
            richTextBox1.Text = initialText;
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
        /// Send button.
        /// Sends the text by morse code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            this.morseCode.SendCode(text);
            
        }

        /// <summary>
        /// Save Data button.
        /// Saves the text in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Form5 dialog = new Form5(this.database, richTextBox1.Text);
            dialog.Show();
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
    }
}
