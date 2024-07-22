using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace universal
{
    public partial class Form_serial : Form
    {
        public bool valid1 = false;
        public bool valid2 = false;
        public bool valid3 = true;
        public bool valid4 = false;
        public Form1 f1;
        public string cmd;
        public RegistryKey printer;

        public Form_serial()
        {
            InitializeComponent();
        }
        public Form_serial(Form1 f, string cmd)
        {
            InitializeComponent();

            f1 = f;
            this.cmd = cmd;

            label1.Text = f1.traduction[f1.langue]["printer_name"];
            label2.Text = f1.traduction[f1.langue]["com_port"];
            label3.Text = f1.traduction[f1.langue]["com_speed"];
            label4.Text = f1.traduction[f1.langue]["spooler_path"];
            button2.Text = f1.traduction[f1.langue]["cancel_btn"];


            if (cmd == "create")
            {
                this.Text = f1.traduction[f1.langue]["add_serial_printer"];
                comboBox1.SelectedIndex = 0;
                label5.Visible = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                textBox4.ReadOnly = false;
                button1.Enabled = false;
                button3.Enabled = true;
            }
            else
                if (cmd == "modify" || cmd == "delete")
            {

                textBox1.Text = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("Name").ToString()));
                textBox2.Text = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("Port").ToString()));
                comboBox1.SelectedItem = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("Speed").ToString()));
                textBox4.Text = new UTF8Encoding(true).GetString(Convert.FromBase64String(f1.printer.GetValue("path").ToString()));

                if (cmd == "modify")
                {
                    this.Text = f1.traduction[f1.langue]["edit_serial_printer"];
                    label5.Visible = false;
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    button1.Enabled = false;
                    button3.Enabled = true;
                    valid1 = valid2 = valid3 = true;
                }
                else
                    if (cmd == "delete")
                {
                    this.Text = f1.traduction[f1.langue]["delete_serial_printer"];
                    label5.Text = f1.traduction[f1.langue]["confirm_delete_printer"];
                    label5.Visible = true;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    comboBox1.Enabled = false;
                    textBox4.ReadOnly = true;
                    button1.Enabled = true;
                    button3.Enabled = false;
                    valid1 = valid2 = valid3 = true;
                }

            }
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

            if (valid1 && valid2 && valid3 && valid4)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            if (textBox2.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox2, f1.traduction[f1.langue]["printer_port_error"]);
                valid2 = false;
            }
            else
            {
                errorProvider1.Clear();
                valid2 = true;
            }


            if (valid1 && valid2 && valid3 && valid4)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox4, f1.traduction[f1.langue]["spooler_path_error"]);
                valid4 = false;
            }
            else
            {
                errorProvider1.Clear();
                valid4 = true;
            }

            if (valid1 && valid2 && valid3 && valid4)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog ouvrir = new FolderBrowserDialog();

            ouvrir.SelectedPath = @textBox4.Text;

            if (ouvrir.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ouvrir.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmd == "create")
            {

                f1.settings.CreateSubKey(f1.string_to_hex(textBox1.Text.Trim()));
                printer = f1.settings.OpenSubKey(f1.string_to_hex(textBox1.Text.Trim()), true);
                printer.SetValue("Name", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox1.Text.Trim())));
                printer.SetValue("Connectivity", Convert.ToBase64String(Encoding.UTF8.GetBytes("S")));
                printer.SetValue("Port", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox2.Text.Trim())));
                printer.SetValue("Speed", Convert.ToBase64String(Encoding.UTF8.GetBytes(comboBox1.SelectedItem.ToString())));
                printer.SetValue("path", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox4.Text)));
                printer.SetValue("auto", Convert.ToBase64String(Encoding.UTF8.GetBytes("false")));
                f1.SearchForDevices();
            }
            else
                if (cmd == "modify")
            {
                if (Encoding.UTF8.GetString(Convert.FromBase64String(f1.printer.GetValue("Name").ToString())) == textBox1.Text.Trim())
                {
                    printer = f1.settings.OpenSubKey(f1.string_to_hex(textBox1.Text.Trim()), true);
                }
                else
                {
                    f1.settings.CreateSubKey(f1.string_to_hex(textBox1.Text.Trim()));
                    printer = f1.settings.OpenSubKey(f1.string_to_hex(textBox1.Text.Trim()), true);
                    f1.settings.DeleteSubKey(f1.string_to_hex(Encoding.UTF8.GetString(Convert.FromBase64String(f1.printer.GetValue("Name").ToString()))));
                    f1.printer = printer;
                }


                printer.SetValue("Name", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox1.Text.Trim())));
                printer.SetValue("Connectivity", Convert.ToBase64String(Encoding.UTF8.GetBytes("S")));
                printer.SetValue("Port", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox2.Text.Trim())));
                printer.SetValue("Speed", Convert.ToBase64String(Encoding.UTF8.GetBytes(comboBox1.SelectedItem.ToString())));
                printer.SetValue("path", Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox4.Text)));
                f1.cbval[f1.comboBox1.SelectedIndex] = f1.string_to_hex(textBox1.Text.Trim());
                f1.comboBox1.Items[f1.comboBox1.SelectedIndex] = textBox1.Text.Trim();
            }

            else
                    if (cmd == "delete")
            {
                f1.settings.DeleteSubKey(f1.string_to_hex(textBox1.Text));
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

            }

            this.Close();
        }
    }
}


