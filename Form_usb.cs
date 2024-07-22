using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using Spooler_Universal;


namespace universal
{
    public partial class Form_usb : System.Windows.Forms.Form
    {
        public bool valid1 = false;
        public bool valid2 = false;

        public Spooler_Universal.Form f1;
        public string cmd;
        public RegistryKey printer;

        public Form_usb()
        {
            InitializeComponent();
        }
        public Form_usb(Spooler_Universal.Form f, string cmd)
        {
            InitializeComponent();

            f1 = f;
            this.cmd = cmd;

            label1.Text = f1.traduction[f1.langue]["printer_name"];
            label2.Text = f1.traduction[f1.langue]["spooler_path"];
            button2.Text = f1.traduction[f1.langue]["cancel_btn"];


            if (cmd == "modify" || cmd == "delete")
            {

                textBox1.Text = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("Name").ToString()));
                textBox2.Text = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("path").ToString()));

                if (cmd == "modify")
                {

                    this.Text = f1.traduction[f1.langue]["edit_usb_printer"];
                    label3.Visible = false;
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    button1.Enabled = false;
                    button3.Enabled = true;
                    valid1 = valid2 = true;
                }
                else
                    if (cmd == "delete")
                {
                    this.Text = f1.traduction[f1.langue]["delete_usb_printer"];
                    label2.Text = f1.traduction[f1.langue]["confirm_delete_printer"];
                    label3.Visible = true;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    button1.Enabled = true;
                    button3.Enabled = false;
                    valid1 = valid2 = true;
                }

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (f1.comboBox1.Items.Contains(textBox1.Text.Trim()))
                {
                    errorProvider1.SetError(textBox1, f1.traduction[f1.langue]["printer_name_error"]);
                    valid1 = false;
                }
                else
                {
                    errorProvider1.Clear();
                    valid1 = true;
                }

            }
            else
            {
                valid1 = false;
            }

            if (valid1 && valid2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox2, f1.traduction[f1.langue]["spooler_path_error"]);
                valid2 = false;
            }
            else
            {
                errorProvider1.Clear();
                valid2 = true;
            }

            if (valid1 && valid2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ouvrir = new FolderBrowserDialog();

            ouvrir.SelectedPath = @textBox2.Text;

            if (ouvrir.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ouvrir.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmd == "modify")
            {

                printer = f1.printer;
                printer.SetValue("Name", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox1.Text.Trim())));
                printer.SetValue("path", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox2.Text)));
                f1.comboBox1.Items[f1.comboBox1.SelectedIndex] = textBox1.Text.Trim();
            }
            else
                if (cmd == "delete")
            {
                f1.settings.DeleteSubKey(f1.cbval[f1.comboBox1.SelectedIndex]);
                f1.cbval.RemoveAt(f1.comboBox1.SelectedIndex);
                f1.comboBox1.Items.RemoveAt(f1.comboBox1.SelectedIndex);

                if (f1.comboBox1.Items.Count > 0)
                {
                    f1.comboBox1.SelectedIndex = 0;
                }
                else
                {
                    f1.dataGridView1.Rows.Clear();
                    f1.dataGridView1.Refresh();
                }

                string path = "";

                if (Environment.Is64BitOperatingSystem)
                {
                    if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE", EnvironmentVariableTarget.Machine) == "AMD64")
                    {
                        path = Path.GetDirectoryName(Application.ExecutablePath) + "\\install-filter-winx64.exe";
                    }
                    else
                    {
                        path = Path.GetDirectoryName(Application.ExecutablePath) + "\\install-filter-winIA64.exe";
                    }
                }
                else
                {
                    path = Path.GetDirectoryName(Application.ExecutablePath) + "\\install-filter-winx86.exe";
                }

                System.Diagnostics.Process.Start(path);

            }

            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
