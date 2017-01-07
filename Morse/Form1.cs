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
    /// Class for the main menu
    /// </summary>
    public partial class Form1 : Form
    {
        private Form backForm;
        private MorseCode morseCode;
        private Database database;

        public Form1(MorseCode morseCode, Database database)
        {
            InitializeComponent();
            this.morseCode = morseCode;
            this.database = database;
        }

        public Form1(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;
        }

        public Form1(Form otherForm, MorseCode morseCode, Database database)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
            this.database = database;
        }

        /// <summary>
        /// Gets into Send Morse Code option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form2(this, this.morseCode, this.database, string.Empty);
            form.Show();
            this.Hide();
            
        }

        /// <summary>
        /// Gets into Settings option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form3(this, this.morseCode, this.database);
            form.Show();
            this.Hide();
        }

        /// <summary>
        /// Gets into Saved Data option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form4(this, this.morseCode, this.database);
            form.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
