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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Main form with menu
        /// </summary>
        private Form backForm;
        private MorseCode morseCode;

        public Form1(MorseCode morseCode)
        {
            InitializeComponent();
            this.morseCode = morseCode;
        }

        public Form1(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;
        }

        public Form1(Form otherForm, MorseCode morseCode)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form2(this, this.morseCode);
            form.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form3(this, this.morseCode);
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form4(this, this.morseCode);
            form.Show();
            this.Hide();
        }
    }
}
