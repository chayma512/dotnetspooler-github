using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace universal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 f)
        {
            InitializeComponent();

            this.Text = f.traduction[f.langue]["sous_menu_propos"];
            label3.Text = f.traduction[f.langue]["form3_marque"];
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("http://www.eticeuropedev.com");
            System.Diagnostics.Process.Start(sInfo);

        }
    }
}
