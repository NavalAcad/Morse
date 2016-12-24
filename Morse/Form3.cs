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
    public partial class Form3 : Form
    {
        private Form backForm;
        private MorseCode morseCode;

        public Form3(Form otherForm)
        {
            InitializeComponent();
            this.backForm = otherForm;

        }

        public Form3(Form otherForm, MorseCode morseCode)
        {
            InitializeComponent();
            this.backForm = otherForm;
            this.morseCode = morseCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backForm.Show();
            this.Hide();
        }
    }
}

