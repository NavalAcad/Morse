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
    public partial class Form2 : Form
    {
        private Form backForm;
        private MorseCode morseCode;
        private Database database;

        public Form2(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;
           
        }

        public Form2(Form otherForm, MorseCode morseCode, Database database)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
            this.database = database;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            this.morseCode.SendCode(text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 dialog = new Form5(this.database, richTextBox1.Text);
            dialog.Show();
            //MessageBox.Show("The calculations are complete", "My Application",
            //MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
    }
}
