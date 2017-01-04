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

        private void button1_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Hide();
        }
    }
}