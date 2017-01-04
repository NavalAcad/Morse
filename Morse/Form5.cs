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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
