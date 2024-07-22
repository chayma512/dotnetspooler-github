using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Security.Permissions;
using System.Net;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.DeviceNotify;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using universal;
using System.Threading.Tasks;




namespace Spooler_Universal
{
    public partial class Form1 : Form
    {

        public List<string> files;
        public List<string> cbval = new List<string>();
        public int nbbuffer = 0;
        public int printindex = 0;
        public int nbtotal;
        public string slinb;
        public int pause_stat = 0;
        public int bytesRead;
        public int bytesWritten;
        public bool annul = false;
        public bool deleted = false;
        public bool print_state = false;
        public static byte[] state = Encoding.UTF8.GetBytes("~HS\r\n");
        public static byte[] pause = Encoding.UTF8.GetBytes("~PP\r\n");
        public static byte[] resume = Encoding.UTF8.GetBytes("~PS\r\n");
        public static byte[] cancel = Encoding.UTF8.GetBytes("~JA\r\n");
        public static byte[] readBuffer = new byte[255];
        public RegistryKey settings;
        public RegistryKey printer;
        string[] printers;
        public int vitesse = 0;
        public string address = "";
        public string port = "";
        public string con = "";
        public string serial = "";
        public SerialPort sp;
        public FileStream stream;
        public TcpClient client = null;
        public NetworkStream nstream;
        public SafeFileHandle hParallelPort;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint OPEN_EXISTING = 3;
        const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        public Dictionary<string, string> francais = new Dictionary<string, string>();
        public Dictionary<string, string> anglais = new Dictionary<string, string>();
        public Dictionary<string, Dictionary<string, string>> traduction = new Dictionary<string, Dictionary<string, string>>();

        public static UsbDevice MyUsbDevice;
        private UsbRegDeviceList mRegDevices;
        public IUsbDevice wholeUsbDevice;
        public ErrorCode ec = ErrorCode.None;
        public UsbEndpointReader reader;
        public UsbEndpointWriter writer;
        //public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();

        public string langue = "";
        public string auto_print_file = "";



        public Form1()
        {
            InitializeComponent();

            //UsbDeviceNotifier.OnDeviceNotify = USBPort_Event;

            try
            {

                ////////////////////////////////


                francais.Add("menu_imp", "Imprimante");
                francais.Add("menu_con", "Connectivité");
                francais.Add("menu_langue", "Langue");
                francais.Add("menu_aide", "Aide");
                francais.Add("sous_menu_ajout_imp", "Ajouter une imprimante...");
                francais.Add("sous_menu_modif_imp", "Modifier une imprimante...");
                francais.Add("sous_menu_supp_imp", "Supprimer une imprimante...");
                francais.Add("sous_menu_serie", "Série");
                francais.Add("sous_menu_parallele", "Parallèle");
                francais.Add("sous_menu_all", "Toutes");
                francais.Add("sous_menu_manuel", "Manuel");
                francais.Add("sous_menu_propos", "A propos");

                francais.Add("grid_col1", "Nom du fichier");
                francais.Add("grid_col2", "Taille du fichier");
                francais.Add("grid_col3", "Date de création");

                francais.Add("impression_auto", "Impression automatique");
                francais.Add("bouton_imprimer", "Imprimer");
                francais.Add("bouton_pause_impression", "Pause");
                francais.Add("bouton_reprendre_impression", "Reprendre");
                francais.Add("bouton_annuler_impression", "Annuler");
                francais.Add("etiquettes_restantes", "étiquette restantes");

                francais.Add("info_usb", "Imprimante USB");
                francais.Add("info_ethernet", "Imprimante Ethernet sur l'adresse ");
                francais.Add("info_serie", "Imprimante série sur le port ");
                francais.Add("info_parallele", "Imprimante parallèle sur le port ");

                francais.Add("printer_name", "Nom de l'imprimante :");
                francais.Add("printer_address", "Adresse IP :");
                francais.Add("spooler_path", "Répertoire Spooler :");
                francais.Add("cancel_btn", "Annuler");
                francais.Add("add_ethernet_printer", "Ajouter une imprimante Ethernet");
                francais.Add("edit_ethernet_printer", "Modifier une imprimante Ethernet");
                francais.Add("delete_ethernet_printer", "Supprimer une imprimante Ethernet");
                francais.Add("confirm_delete_printer", "Voulez vous vraiment supprimer cette imprimante ?");
                francais.Add("printer_name_error", "ce nom existe déjà");
                francais.Add("printer_port_error", "port non valide");
                francais.Add("spooler_path_error", "chemin non valide");

                francais.Add("com_port", "Nom du port :");
                francais.Add("add_parallel_printer", "Ajouter une imprimante parallèle");
                francais.Add("edit_parallel_printer", "Modifier une imprimante parallèle");
                francais.Add("delete_parallel_printer", "Supprimer une imprimante parallèle");

                francais.Add("com_speed", "Vitesse (Bauds) :");
                francais.Add("add_serial_printer", "Ajouter une imprimante série");
                francais.Add("edit_serial_printer", "Modifier une imprimante série");
                francais.Add("delete_serial_printer", "Supprimer une imprimante série");

                francais.Add("add_usb_printer", "Ajouter une imprimante USB");
                francais.Add("edit_usb_printer", "Modifier une imprimante USB");
                francais.Add("delete_usb_printer", "Supprimer une imprimante USB");

                francais.Add("error_fichier", "Sélectionner un fichier");
                francais.Add("error_pause", "Imprimante en pause");
                francais.Add("error_ruban", "Fin ruban");
                francais.Add("error_tete", "Tête ouverte");

                francais.Add("error", "Erreur");

                francais.Add("cancel_all", "Annuler tout");
                francais.Add("vider", "Vider la liste");

                francais.Add("form3_marque", "Spooler Universal est une marque déposée\r\npropriété de Etic Europe.Tous droits résérvés.");

                //////////////////////////////////////////////////////////////////////


                anglais.Add("menu_imp", "Printer");
                anglais.Add("menu_con", "Connectivity");
                anglais.Add("menu_langue", "Language");
                anglais.Add("menu_aide", "Help");
                anglais.Add("sous_menu_ajout_imp", "Add a printer...");
                anglais.Add("sous_menu_modif_imp", "Edit a printer...");
                anglais.Add("sous_menu_supp_imp", "Delete a printer...");
                anglais.Add("sous_menu_serie", "Serial");
                anglais.Add("sous_menu_parallele", "Parallel");
                anglais.Add("sous_menu_all", "All");
                anglais.Add("sous_menu_manuel", "Manual");
                anglais.Add("sous_menu_propos", "About");

                anglais.Add("grid_col1", "File name");
                anglais.Add("grid_col2", "File size");
                anglais.Add("grid_col3", "Creation date");

                anglais.Add("impression_auto", "Automatic printing");
                anglais.Add("bouton_imprimer", "Print");
                anglais.Add("bouton_pause_impression", "Pause");
                anglais.Add("bouton_reprendre_impression", "Resume");
                anglais.Add("bouton_annuler_impression", "Cancel");
                anglais.Add("etiquettes_restantes", "remaining labels");

                anglais.Add("info_usb", "USB printer");
                anglais.Add("info_ethernet", "Ethernet printer on the address ");
                anglais.Add("info_serie", "Serial printer on the port ");
                anglais.Add("info_parallele", "Parallel printer on the port ");

                anglais.Add("printer_name", "Printer name :");
                anglais.Add("printer_address", "IP address :");
                anglais.Add("spooler_path", "Spooler directory :");
                anglais.Add("cancel_btn", "Cancel");
                anglais.Add("add_ethernet_printer", "Add Ethernet printer");
                anglais.Add("edit_ethernet_printer", "Edit Ethernet printer");
                anglais.Add("delete_ethernet_printer", "Delete Ethernet printer");
                anglais.Add("confirm_delete_printer", "Do you really want to delete this printer ?");
                anglais.Add("printer_name_error", "This name already exists");
                anglais.Add("printer_port_error", "Invalid Port");
                anglais.Add("spooler_path_error", "Invalid Path");

                anglais.Add("com_port", "Port name :");
                anglais.Add("add_parallel_printer", "Add parallel printer");
                anglais.Add("edit_parallel_printer", "Edit parallel printer");
                anglais.Add("delete_parallel_printer", "Delete parallel printer");

                anglais.Add("com_speed", "Speed (Bauds) :");
                anglais.Add("add_serial_printer", "Add serial printer");
                anglais.Add("edit_serial_printer", "Edit serial printer");
                anglais.Add("delete_serial_printer", "Delete serial printer");

                anglais.Add("add_usb_printer", "Add USB printer");
                anglais.Add("edit_usb_printer", "Edit USB printer");
                anglais.Add("delete_usb_printer", "Delete USB printer");

                anglais.Add("error_fichier", "Select a File");
                anglais.Add("error_pause", "Printer in pause");
                anglais.Add("error_ruban", "Ribbon end");
                anglais.Add("error_tete", "Print head open");

                anglais.Add("error", "Error");

                anglais.Add("vider", "Clear list");

                anglais.Add("form3_marque", "Spooler Universal is a registered trademark\r\nowned by Etic Europe.All rights reserved.");

                //////////////////////////////////////////////////////////////////////


                traduction.Add("Français", francais);
                traduction.Add("English", anglais);


                settings = Registry.CurrentUser.OpenSubKey("Software\\Etic Europe Dev\\Spooler Universal\\Settings", true);

                langue = settings.GetValue("langue").ToString();

                if (langue == "Français")
                {
                    françaisToolStripMenuItem.Checked = true;
                }
                else
                    if (langue == "English")
                    {
                        anglaisToolStripMenuItem.Checked = true;
                    }



                if (settings.GetValue("connectivity").ToString() == "usb")
                {
                    uSBToolStripMenuItem.Checked = true;
                }
                else
                    if (settings.GetValue("connectivity").ToString() == "ethernet")
                    {
                        ethernetToolStripMenuItem.Checked = true;
                    }
                    else
                        if (settings.GetValue("connectivity").ToString() == "serial")
                        {
                            sérieToolStripMenuItem.Checked = true;
                        }
                        else
                            if (settings.GetValue("connectivity").ToString() == "parallel")
                            {
                                parallèleToolStripMenuItem.Checked = true;
                            }
                            else
                                if (settings.GetValue("connectivity").ToString() == "all")
                                {
                                    toutesToolStripMenuItem.Checked = true;
                                }




                changer_langue(langue);
                SearchForDevices();


                string[] args = Environment.GetCommandLineArgs();
                bool arg2 = false;


                if (args.Length >= 2)
                {

                    switch (args[1])
                    {
                        case "1":
                            this.BackColor = Color.FromArgb(63, 196, 241);
                            break;
                        case "2":
                            this.BackColor = Color.FromArgb(59, 185, 141);
                            break;
                        case "3":
                            this.BackColor = Color.FromArgb(245, 130, 31);
                            break;
                        case "4":
                            this.BackColor = Color.FromArgb(241, 242, 142);
                            break;
                        case "5":
                            this.BackColor = Color.FromArgb(241, 142, 242);
                            break;
                    }

                }


                if (args.Length >= 3 && comboBox1.Items.Contains(args[2]))
                {
                    arg2 = true;
                    comboBox1.SelectedItem = args[2];
                }



                if (comboBox1.Items.Count > 0 && arg2 == false)
                {
                    comboBox1.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, traduction[langue]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }






        private void changer_langue(string langue)
        {
           
            imprimanteToolStripMenuItem.Text = traduction[langue]["menu_imp"];
            connectivitéToolStripMenuItem.Text = traduction[langue]["menu_con"];
            langueToolStripMenuItem.Text = traduction[langue]["menu_langue"];
            aideToolStripMenuItem.Text = traduction[langue]["menu_aide"];
            ajouterUneImprimanteToolStripMenuItem.Text = traduction[langue]["sous_menu_ajout_imp"];
            modifierUneImprimanteToolStripMenuItem.Text = traduction[langue]["sous_menu_modif_imp"];
            supprimerUneImprimanteToolStripMenuItem.Text = traduction[langue]["sous_menu_supp_imp"];
            sérieToolStripMenuItem1.Text = traduction[langue]["sous_menu_serie"];
            parallèleToolStripMenuItem1.Text = traduction[langue]["sous_menu_parallele"];
            sérieToolStripMenuItem.Text = traduction[langue]["sous_menu_serie"];
            parallèleToolStripMenuItem.Text = traduction[langue]["sous_menu_parallele"];
            toutesToolStripMenuItem.Text = traduction[langue]["sous_menu_all"];
            manuelToolStripMenuItem.Text = traduction[langue]["sous_menu_manuel"];
            aProposToolStripMenuItem1.Text = traduction[langue]["sous_menu_propos"];
            dataGridView1.Columns[0].HeaderText = traduction[langue]["grid_col1"];
            dataGridView1.Columns[1].HeaderText = traduction[langue]["grid_col2"];
            dataGridView1.Columns[2].HeaderText = traduction[langue]["grid_col3"];
            checkBox1.Text = traduction[langue]["impression_auto"];
            button2.Text = traduction[langue]["bouton_imprimer"];
            button3.Text = traduction[langue]["bouton_annuler_impression"];
            button4.Text = traduction[langue]["vider"];
            label3.Text = "0 " + traduction[langue]["etiquettes_restantes"];
            comboBox1_SelectedIndexChanged(null, EventArgs.Empty);
            
        }




        private WriteEndpointID GetWriteEndpointID(UsbDevice device)
        {

            byte epid = device.Configs.First().InterfaceInfoList.First().EndpointInfoList.Where(o => o.Descriptor.EndpointID <= 15).OrderBy(o => o.Descriptor.EndpointID).First().Descriptor.EndpointID;

            WriteEndpointID wep = WriteEndpointID.Ep01;

            switch (epid)
            {
                case 1: wep = WriteEndpointID.Ep01;
                    break;

                case 2: wep = WriteEndpointID.Ep02;
                    break;

                case 3: wep = WriteEndpointID.Ep03;
                    break;

                case 4: wep = WriteEndpointID.Ep04;
                    break;

                case 5: wep = WriteEndpointID.Ep05;
                    break;

                case 6: wep = WriteEndpointID.Ep06;
                    break;

                case 7: wep = WriteEndpointID.Ep07;
                    break;

                case 8: wep = WriteEndpointID.Ep08;
                    break;

                case 9: wep = WriteEndpointID.Ep09;
                    break;

                case 10: wep = WriteEndpointID.Ep10;
                    break;

                case 11: wep = WriteEndpointID.Ep11;
                    break;

                case 12: wep = WriteEndpointID.Ep12;
                    break;

                case 13: wep = WriteEndpointID.Ep13;
                    break;

                case 14: wep = WriteEndpointID.Ep14;
                    break;

                case 15: wep = WriteEndpointID.Ep15;
                    break;

                default: wep = WriteEndpointID.Ep01;
                    break;

            }

            return wep;
        }




        private ReadEndpointID GetReadEndpointID(UsbDevice device)
        {

            byte epid = device.Configs.First().InterfaceInfoList.First().EndpointInfoList.Where(o => o.Descriptor.EndpointID >= 129).OrderBy(o => o.Descriptor.EndpointID).First().Descriptor.EndpointID;

            ReadEndpointID rep = ReadEndpointID.Ep01;

            switch (epid)
            {
                case 129: rep = ReadEndpointID.Ep01;
                    break;

                case 130: rep = ReadEndpointID.Ep02;
                    break;

                case 131: rep = ReadEndpointID.Ep03;
                    break;

                case 132: rep = ReadEndpointID.Ep04;
                    break;

                case 133: rep = ReadEndpointID.Ep05;
                    break;

                case 134: rep = ReadEndpointID.Ep06;
                    break;

                case 135: rep = ReadEndpointID.Ep07;
                    break;

                case 136: rep = ReadEndpointID.Ep08;
                    break;

                case 137: rep = ReadEndpointID.Ep09;
                    break;

                case 138: rep = ReadEndpointID.Ep10;
                    break;

                case 139: rep = ReadEndpointID.Ep11;
                    break;

                case 140: rep = ReadEndpointID.Ep12;
                    break;

                case 141: rep = ReadEndpointID.Ep13;
                    break;

                case 142: rep = ReadEndpointID.Ep14;
                    break;

                case 143: rep = ReadEndpointID.Ep15;
                    break;

                default: rep = ReadEndpointID.Ep01;
                    break;

            }

            return rep;
        }




        private void USBPort_Event(object sender, DeviceNotifyEventArgs e)
        {
            SearchForDevices();
        }




        public void SearchForDevices()
        {


            string cbis = "";

            if (comboBox1.Items.Count > 0)
            {
                cbis = comboBox1.SelectedItem.ToString();
            }


            mRegDevices = UsbDevice.AllDevices;
            var devices = mRegDevices.Where(r => r.Vid == 2655 || r.Vid == 6495);


            foreach (UsbRegistry regDevice in devices)
            {

                //System.Diagnostics.Debug.WriteLine(regDevice.Device.Info.Descriptor.SerialStringIndex.ToString());
                //System.Diagnostics.Debug.WriteLine(regDevice.Device.Info.SerialString);

                if (regDevice.Device.Info.SerialString.Length > 0)
                {
                    string pn = string_to_hex("printer" + regDevice.Device.Info.SerialString);

                    if (settings.GetSubKeyNames().Contains(pn) == false)
                    {
                        settings.CreateSubKey(pn);
                        settings.OpenSubKey(pn, true).SetValue("Name", Convert.ToBase64String(Encoding.UTF8.GetBytes(regDevice.Device.Info.ProductString)));
                        settings.OpenSubKey(pn, true).SetValue("path", Convert.ToBase64String(Encoding.UTF8.GetBytes(" ")));
                        settings.OpenSubKey(pn, true).SetValue("serial", Convert.ToBase64String(Encoding.UTF8.GetBytes(regDevice.Device.Info.SerialString)));
                        settings.OpenSubKey(pn, true).SetValue("Connectivity", Convert.ToBase64String(Encoding.UTF8.GetBytes("U")));
                        settings.OpenSubKey(pn, true).SetValue("auto", Convert.ToBase64String(Encoding.UTF8.GetBytes("false")));
                    }
                }
            }


            printers = settings.GetSubKeyNames();
            comboBox1.Items.Clear();
            cbval.Clear();
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();


            if (toutesToolStripMenuItem.Checked)
            {
                foreach (var item in printers)
                {

                    if (settings.OpenSubKey(item, true).ValueCount >= 4)
                    {
                        if (Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Connectivity").ToString())) == "U")
                        {
                            string serial = Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("serial").ToString()));
                            if (UsbDevice.AllDevices.Count(r => (r.Vid == 2655 || r.Vid == 6495) && r.Device.Info.SerialString == serial && r.IsAlive == true) > 0)
                            {
                                comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                                cbval.Add(item);
                            }
                        }
                        else
                        {
                            comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                            cbval.Add(item);
                        }

                    }
                }
            }
            else
                if (uSBToolStripMenuItem.Checked)
                {
                    foreach (var item in printers)
                    {
                        if (settings.OpenSubKey(item, true).ValueCount >= 4)
                        {

                            if (new UTF8Encoding(true).GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Connectivity").ToString())) == "U")
                            {
                                string serial = Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("serial").ToString()));
                                if (UsbDevice.AllDevices.Count(r => (r.Vid == 2655 || r.Vid == 6495) && r.Device.Info.SerialString == serial && r.IsAlive == true) > 0)
                                {
                                    comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                                    cbval.Add(item);
                                }
                            }

                        }
                    }
                }
                else
                    if (ethernetToolStripMenuItem.Checked)
                    {
                        foreach (var item in printers)
                        {
                            if (settings.OpenSubKey(item, true).ValueCount >= 4)
                            {

                                if (new UTF8Encoding(true).GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Connectivity").ToString())) == "E")
                                {
                                    comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                                    cbval.Add(item);
                                }

                            }
                        }
                    }
                    else
                        if (sérieToolStripMenuItem.Checked)
                        {
                            foreach (var item in printers)
                            {

                                if (settings.OpenSubKey(item, true).ValueCount >= 4)
                                {
                                    if (new UTF8Encoding(true).GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Connectivity").ToString())) == "S")
                                    {
                                        comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                                        cbval.Add(item);
                                    }

                                }
                            }
                        }
                        else
                            if (parallèleToolStripMenuItem.Checked)
                            {
                                foreach (var item in printers)
                                {

                                    if (settings.OpenSubKey(item, true).ValueCount >= 4)
                                    {
                                        if (new UTF8Encoding(true).GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Connectivity").ToString())) == "P")
                                        {
                                            comboBox1.Items.Add(Encoding.UTF8.GetString(Convert.FromBase64String(settings.OpenSubKey(item, true).GetValue("Name").ToString())));
                                            cbval.Add(item);
                                        }

                                    }
                                }
                            }



            if (comboBox1.Items.Count > 0)
            {
                if (comboBox1.Items.Contains(cbis))
                {
                    comboBox1.SelectedItem = cbis;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        
        
        
        }




        private void Form1_Close(object sender, EventArgs e)
        {
            try
            {
                if (printer != null)
                {
                    printer.Close();
                }

                settings.Close();
            }

            catch
            {

            }

        }



        private void Update_grid()
        {

            try
            {

                fileSystemWatcher1.Path = @Encoding.UTF8.GetString(Convert.FromBase64String(printer.GetValue("path").ToString()));
                files = Directory.GetFiles(fileSystemWatcher1.Path, "*.*", SearchOption.TopDirectoryOnly).Where(file => (file.ToLower().EndsWith("txt") || file.ToLower().EndsWith("zpl") || file.ToLower().EndsWith("twi") || file.ToLower().EndsWith("prn")) && ((double)(new FileInfo(@file).Length)) / 1024D > 0).OrderBy(file => new FileInfo(@file).CreationTime).ToList();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.AllowUserToAddRows = true;

                foreach (var item in files)
                {
                    FileInfo file = new FileInfo(@item);

                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = file.Name;
                    row.Cells[1].Value = file.Length / 1024 + " KB";
                    row.Cells[2].Value = file.CreationTime;

                    dataGridView1.Rows.Add(row);
                }

                dataGridView1.AllowUserToAddRows = false;
                Application.DoEvents();

            }

            catch (Exception ex)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                Application.DoEvents();
                MessageBox.Show(ex.Message, traduction[langue]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
            {
                Thread.Sleep(1000);
                Update_grid();
            }

            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                Thread.Sleep(500);
                if (checkBox1.Checked)
                {
                    if (dataGridView1.Rows.Count == 1 && auto_print_file != e.Name && print_state == false)
                    {
                        auto_print_file = e.Name;
                        button2.Text = traduction[langue]["bouton_imprimer"];
                        button2_Click(null, EventArgs.Empty);
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count == 0)
                        {
                            button3.Enabled = false;
                        }
                    }
                }

            }


            if (e.ChangeType == WatcherChangeTypes.Deleted && deleted)
            {
                Thread.Sleep(500);
                if (checkBox1.Checked)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        button2.Text = traduction[langue]["bouton_imprimer"];
                        button2_Click(null, EventArgs.Empty);
                    }
                    else
                    {
                        button3.Enabled = false;
                        comboBox1.Enabled = true;
                        button4.Enabled = true;
                        imprimanteToolStripMenuItem.Enabled = true;
                        connectivitéToolStripMenuItem.Enabled = true;
                        langueToolStripMenuItem.Enabled = true;
                        button2.Text = traduction[langue]["bouton_imprimer"];
                    }
                }
                else
                {
                    button2.Text = traduction[langue]["bouton_imprimer"];
                    button2.Enabled = true;
                    button3.Enabled = false;
                    comboBox1.Enabled = true;
                    button4.Enabled = true;
                    imprimanteToolStripMenuItem.Enabled = true;
                    connectivitéToolStripMenuItem.Enabled = true;
                    langueToolStripMenuItem.Enabled = true;
                }

            }

        }




        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);



        private void PrintJob()
        {

            StreamReader fs = File.OpenText(@files[printindex]);
            string text = fs.ReadToEnd();
            fs.Close();
            byte[] print = Encoding.UTF8.GetBytes(text);

            nbtotal = 0;
            int startind = 0;
            string numb;

            while (text.IndexOf("^PQ", startind) > 0)
            {
                int sind = text.IndexOf("^PQ", startind);
                int i = sind + 3;
                numb = "";

                while (Char.IsNumber(text[i]) || text[i] == '-')
                {
                    numb = numb + text[i];
                    i++;
                }

                nbtotal = nbtotal + int.Parse(numb.Trim());
                startind = i;
            }


            if (nbtotal == 0)
            {
                nbtotal = 1;
            }

            progressBar1.Maximum = nbtotal;
            progressBar1.Value = 0;
            nbbuffer = 0;
            int prog = nbbuffer;
            int nbc = 0;


            if (con == "U")
            {

                mRegDevices.Where(u => (u.Vid == 2655 || u.Vid == 6495) && u.Device.Info.SerialString == serial).First().Open(out MyUsbDevice); ;

                wholeUsbDevice = MyUsbDevice as IUsbDevice;
                wholeUsbDevice.SetConfiguration(MyUsbDevice.Configs.First().Descriptor.ConfigID);
                wholeUsbDevice.ClaimInterface(MyUsbDevice.Configs.First().InterfaceInfoList.First().Descriptor.InterfaceID);
                reader = MyUsbDevice.OpenEndpointReader(GetReadEndpointID(MyUsbDevice));
                writer = MyUsbDevice.OpenEndpointWriter(GetWriteEndpointID(MyUsbDevice));
                ec = writer.Write(print, 10000, out bytesWritten);

            }
            else
                if (con == "E")
                {
                    client = new TcpClient(address, int.Parse(port));
                    nstream = client.GetStream();
                    nstream.ReadTimeout = Timeout.Infinite;
                    nstream.WriteTimeout = Timeout.Infinite;
                    nstream.Write(print, 0, print.Length);
                }
                else
                    if (con == "S")
                    {
                        sp = new SerialPort(port, vitesse, System.IO.Ports.Parity.Even, 8, StopBits.One);
                        sp.Handshake = Handshake.XOnXOff;
                        sp.ReadTimeout = SerialPort.InfiniteTimeout;
                        sp.WriteTimeout = SerialPort.InfiniteTimeout;
                        sp.Open();
                        sp.Write(print, 0, print.Length);
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                        if (con == "P")
                        {
                            hParallelPort = CreateFile(port, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
                            stream = new FileStream(hParallelPort, FileAccess.ReadWrite);

                            if (stream.CanTimeout)
                            {
                                stream.ReadTimeout = Timeout.Infinite;
                                stream.WriteTimeout = Timeout.Infinite;
                            }

                            stream.Write(print, 0, print.Length);
                            stream.Flush();
                            System.Threading.Thread.Sleep(50);
                        }


            
            do
            {

                Read_printer_buffer();

                if (prog != nbbuffer)
                {
                    prog = nbbuffer;
                    if (progressBar1.Value < progressBar1.Maximum)
                    {
                        progressBar1.Value = progressBar1.Value + 1;
                    }
                }
                else
                {
                    if (nbbuffer == 0)
                    {
                        nbc++;
                    }
                }

                Application.DoEvents();
            }
            while (annul == false && (progressBar1.Value < progressBar1.Maximum || nbbuffer > 0) && nbc < 20);
            


            progressBar1.Value = progressBar1.Maximum;
            label3.Text = "0 " + traduction[langue]["etiquettes_restantes"];
            errorProvider1.Clear();

            if (nbc >= 20 || annul)
            {
                button2.Text = traduction[langue]["bouton_imprimer"];
                button3.Enabled = false;
            }

            print_state = false;
            File.Delete(@files[printindex]);
            deleted = true;


            if (con == "U")
            {
                wholeUsbDevice.ReleaseInterface(MyUsbDevice.Configs.First().InterfaceInfoList.First().Descriptor.InterfaceID);
            }
            else
                if (con == "E")
                {
                    nstream.Close();
                    client.Close();
                }
                else
                    if (con == "S")
                    {
                        sp.Close();
                    }
                    else
                        if (con == "P")
                        {
                            stream.Close();
                            hParallelPort.Close();
                        }


        }




        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                if (button2.Text == traduction[langue]["bouton_pause_impression"])
                {

                    if (con == "U")
                    {
                        ec = writer.Write(pause, 5000, out bytesWritten);
                    }
                    else
                        if (con == "E")
                        {
                            nstream.Write(pause, 0, pause.Length);
                        }
                        else
                            if (con == "S")
                            {
                                sp.Write(pause, 0, pause.Length);
                            }
                            else
                                if (con == "P")
                                {
                                    stream.Write(pause, 0, pause.Length);
                                }
                    button2.Text = traduction[langue]["bouton_reprendre_impression"];
                    if (errorProvider1.GetError(label3) == "")
                    {
                        errorProvider1.SetError(label3, traduction[langue]["error_pause"]);
                    }

                }
                else
                    if (button2.Text == traduction[langue]["bouton_reprendre_impression"])
                    {

                        if (con == "U")
                        {
                            ec = writer.Write(resume, 5000, out bytesWritten);
                        }
                        else
                            if (con == "E")
                            {
                                nstream.Write(resume, 0, pause.Length);
                            }
                            else
                                if (con == "S")
                                {
                                    sp.Write(resume, 0, resume.Length);
                                }
                                else
                                    if (con == "P")
                                    {
                                        stream.Write(resume, 0, resume.Length);
                                        stream.Flush();
                                    }
                        button2.Text = traduction[langue]["bouton_pause_impression"];
                        if (errorProvider1.GetError(label3) != "")
                        {
                            errorProvider1.Clear();
                        }
                    }
                    else
                    {
                        if (checkBox1.Checked)
                        {

                            errorProvider1.Clear();

                            if (dataGridView1.Rows.Count > 0)
                            {

                                errorProvider1.Clear();
                                deleted = false;
                                print_state = true;
                                printindex = 0;
                                button2.Text = traduction[langue]["bouton_pause_impression"];
                                annul = false;
                                button3.Enabled = true;
                                comboBox1.Enabled = false;
                                button4.Enabled = false;
                                imprimanteToolStripMenuItem.Enabled = false;
                                connectivitéToolStripMenuItem.Enabled = false;
                                langueToolStripMenuItem.Enabled = false;
                                Application.DoEvents();
                                PrintJob();

                            }

                        }
                        else
                        {

                            errorProvider1.Clear();

                            if (dataGridView1.SelectedRows.Count > 0)
                            {

                                errorProvider1.Clear();
                                deleted = false;
                                print_state = true;
                                printindex = dataGridView1.CurrentRow.Index;
                                button2.Text = traduction[langue]["bouton_pause_impression"];
                                annul = false;
                                button3.Enabled = true;
                                comboBox1.Enabled = false;
                                button4.Enabled = false;
                                imprimanteToolStripMenuItem.Enabled = false;
                                connectivitéToolStripMenuItem.Enabled = false;
                                langueToolStripMenuItem.Enabled = false;
                                Application.DoEvents();
                                PrintJob();
                            }
                            else
                            {
                                errorProvider1.SetIconAlignment(dataGridView1, ErrorIconAlignment.TopLeft);
                                errorProvider1.SetError(dataGridView1, traduction[langue]["error_fichier"]);
                            }

                        }
                    }
            }

            catch(Exception ex)
            {
                progressBar1.Value = 0;
                label3.Text = "0 " + traduction[langue]["etiquettes_restantes"];
                button2.Text = traduction[langue]["bouton_imprimer"];
                button3.Enabled = false;
                comboBox1.Enabled = true;
                button4.Enabled = true;
                imprimanteToolStripMenuItem.Enabled = true;
                connectivitéToolStripMenuItem.Enabled = true;
                langueToolStripMenuItem.Enabled = true;
                annul = true;
                deleted = true;
                print_state = false;
                errorProvider1.Clear();
                if (con == "U")
                {
                    wholeUsbDevice = null;
                    MyUsbDevice = null;
                }
                else
                    if (con == "E")
                    {
                        nstream = null;
                        client = null;
                    }
                    else
                        if (con == "S")
                        {
                            sp = null;
                        }
                        else
                            if (con == "P")
                            {
                                stream = null;
                            }
                Application.DoEvents();
                MessageBox.Show(ex.Message, traduction[langue]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void Read_printer_buffer()
        {

            do
            {

                if (con == "U")
                {
                    ec = writer.Write(state, 5000, out bytesWritten);
                    ec = reader.Read(readBuffer, 5000, out bytesRead);
                    Application.DoEvents();
                }
                else
                    if (con == "E")
                    {
                        nstream.Write(state, 0, state.Length);
                        bytesRead = nstream.Read(readBuffer, 0, readBuffer.Length);
                        Application.DoEvents();
                    }
                    else
                        if (con == "S")
                        {
                            sp.Write(state, 0, state.Length);
                            bytesRead = sp.Read(readBuffer, 0, readBuffer.Length);
                            Application.DoEvents();
                        }
                        else
                            if (con == "P")
                            {
                                stream.Write(state, 0, state.Length);
                                stream.Flush();
                                bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
                                Application.DoEvents();
                            }


                System.Threading.Thread.Sleep(100);

            }
            while (bytesRead < 82);

            
            char STX = (char)2;
            char ETX = (char)3;
            string status = Encoding.UTF8.GetString(readBuffer);
            status = status.Replace(STX.ToString(), "");
            status = status.Replace(ETX.ToString(), "");
            string[][] ssa = new string[3][];
            string[] rc = new string[1] { "\r\n" };
            ssa[0] = status.Split(rc, StringSplitOptions.None)[0].Split(',');
            ssa[1] = status.Split(rc, StringSplitOptions.None)[1].Split(',');
            ssa[2] = status.Split(rc, StringSplitOptions.None)[2].Split(',');

            /*
            string status = System.Text.UTF8Encoding.Default.GetString(readBuffer);
            slinb = status.Substring(55, 8);
            nbbuffer = int.Parse(slinb);
            pause_stat = int.Parse(status.Substring(7, 1));
            int fin_ruban = int.Parse(status.Substring(45, 1));
            int tete_up = int.Parse(status.Substring(43, 1));
            */

            nbbuffer = int.Parse(ssa[1][8]);

            //File.AppendAllText("C:/spooler/buffer.txt", nbbuffer.ToString() + Environment.NewLine);

            if (ssa[0][1] == "1")
            {
                if (errorProvider1.GetError(label3) != traduction[langue]["error_ruban"])
                {
                    errorProvider1.SetIconAlignment(label3, ErrorIconAlignment.MiddleRight);
                    errorProvider1.SetError(label3, traduction[langue]["error_ruban"]);
                    button2.Text = traduction[langue]["bouton_reprendre_impression"];
                }
            }
            else
                if (ssa[1][2] == "1")
                {
                    if (errorProvider1.GetError(label3) != traduction[langue]["error_tete"])
                    {
                        errorProvider1.SetIconAlignment(label3, ErrorIconAlignment.MiddleRight);
                        errorProvider1.SetError(label3, traduction[langue]["error_tete"]);
                        button2.Text = traduction[langue]["bouton_reprendre_impression"];
                    }
                }
                else
                    if (ssa[0][2] == "1")
                    {
                        if (errorProvider1.GetError(label3) != traduction[langue]["error_pause"])
                        {
                            errorProvider1.SetIconAlignment(label3, ErrorIconAlignment.MiddleRight);
                            errorProvider1.SetError(label3, traduction[langue]["error_pause"]);
                            button2.Text = traduction[langue]["bouton_reprendre_impression"];
                        }
                    }
                    else
                    {
                        errorProvider1.Clear();
                        button2.Text = traduction[langue]["bouton_pause_impression"];
                    }

            label3.Text = nbbuffer + " " + traduction[langue]["etiquettes_restantes"];

        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                annul = true;
                button3.Enabled = false;

                if (con == "U")
                {
                    ec = writer.Write(cancel, 5000, out bytesWritten);
                }
                else
                    if (con == "E")
                    {
                        nstream.Write(cancel, 0, cancel.Length);
                    }
                    else
                        if (con == "S")
                        {
                            sp.Write(cancel, 0, cancel.Length);
                        }
                        else
                            if (con == "P")
                            {
                                stream.Write(cancel, 0, cancel.Length);
                                stream.Flush();
                            }

            }
            catch
            {

            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                annul = true;
                button3.Enabled = false;

                if (con == "U")
                {
                    ec = writer.Write(cancel, 5000, out bytesWritten);
                }
                else
                    if (con == "E")
                    {
                        nstream.Write(cancel, 0, cancel.Length);
                    }
                    else
                        if (con == "S")
                        {
                            sp.Write(cancel, 0, cancel.Length);
                        }
                        else
                            if (con == "P")
                            {
                                stream.Write(cancel, 0, cancel.Length);
                                stream.Flush();
                            }

            }
            catch
            {

            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                fileSystemWatcher1.EnableRaisingEvents = false;
                
                foreach (var item in files)
                {
                    File.Delete(item);
                }

                fileSystemWatcher1.EnableRaisingEvents = true;
                Update_grid();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, traduction[langue]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0)
            {

                printer = settings.OpenSubKey(cbval[comboBox1.SelectedIndex], true);
                con = new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Connectivity").ToString()));

                if (con == "U")
                {
                    serial = Encoding.UTF8.GetString(Convert.FromBase64String(printer.GetValue("serial").ToString()));
                    textBox1.Text = traduction[langue]["info_usb"];
                }
                else
                    if (con == "E")
                    {
                        address = new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Address").ToString()));
                        port = new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Port").ToString()));
                        textBox1.Text = traduction[langue]["info_ethernet"] + address;
                    }
                    else
                        if (con == "S")
                        {
                            port = new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Port").ToString()));
                            vitesse = int.Parse(new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Speed").ToString())));
                            textBox1.Text = traduction[langue]["info_serie"] + port;
                        }
                        else
                            if (con == "P")
                            {
                                port = new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("Port").ToString()));
                                textBox1.Text = traduction[langue]["info_parallele"] + port;
                            }


                checkBox1.Checked = Convert.ToBoolean(new UTF8Encoding(true).GetString(Convert.FromBase64String(printer.GetValue("auto").ToString())));

                if (Encoding.UTF8.GetString(Convert.FromBase64String(printer.GetValue("path").ToString())).Trim().Length > 0)
                {
                    Update_grid();
                }
            }
            else
            {
                textBox1.Text = "";
            }

        }



        public string string_to_hex(string text)
        {

            string output = "";
            char[] values = text.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                output = output + value.ToString("X");
            }

            return output;
        }




        private void modifierUneImprimanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {

                if (con == "U")
                {
                    Form_usb f1 = new Form_usb(this, "modify");
                    f1.ShowDialog();
                }
                else
                    if (con == "E")
                    {
                        Form_ethernet f2 = new Form_ethernet(this, "modify");
                        f2.ShowDialog();
                    }
                    else
                        if (con == "S")
                        {
                            Form_serial f3 = new Form_serial(this, "modify");
                            f3.ShowDialog();
                        }
                        else
                            if (con == "P")
                            {
                                Form_parallel f4 = new Form_parallel(this, "modify");
                                f4.ShowDialog();
                            }
                
            }
        }



        private void supprimerUneImprimanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                if (con == "U")
                {
                    Form_usb f1 = new Form_usb(this, "delete");
                    f1.ShowDialog();
                }
                else
                    if (con == "E")
                    {
                        Form_ethernet f2 = new Form_ethernet(this, "delete");
                        f2.ShowDialog();
                    }
                    else
                        if (con == "S")
                        {
                            Form_serial f3 = new Form_serial(this, "delete");
                            f3.ShowDialog();
                        }
                        else
                            if (con == "P")
                            {
                                Form_parallel f4 = new Form_parallel(this, "delete");
                                f4.ShowDialog();
                            }

            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            printer.SetValue("auto", Convert.ToBase64String(Encoding.UTF8.GetBytes(checkBox1.Checked.ToString())));
        }



        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void uSBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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



        private void ethernetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_ethernet fe = new Form_ethernet(this, "create");
            fe.ShowDialog();
        }


        private void sérieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_serial fs = new Form_serial(this, "create");
            fs.ShowDialog();
        }


        private void parallèleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_parallel fp = new Form_parallel(this, "create");
            fp.ShowDialog();
        }




        private void uSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ethernetToolStripMenuItem.Checked = false;
            sérieToolStripMenuItem.Checked = false;
            parallèleToolStripMenuItem.Checked = false;
            toutesToolStripMenuItem.Checked = false;
            uSBToolStripMenuItem.Checked = true;
            settings.SetValue("connectivity", "usb");
            SearchForDevices();
        }

        private void ethernetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sérieToolStripMenuItem.Checked = false;
            parallèleToolStripMenuItem.Checked = false;
            toutesToolStripMenuItem.Checked = false;
            uSBToolStripMenuItem.Checked = false;
            ethernetToolStripMenuItem.Checked = true;
            settings.SetValue("connectivity", "ethernet");
            SearchForDevices();
        }

        private void sérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ethernetToolStripMenuItem.Checked = false;
            parallèleToolStripMenuItem.Checked = false;
            toutesToolStripMenuItem.Checked = false;
            uSBToolStripMenuItem.Checked = false;
            sérieToolStripMenuItem.Checked = true;
            settings.SetValue("connectivity", "serial");
            SearchForDevices();
        }

        private void parallèleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ethernetToolStripMenuItem.Checked = false;
            toutesToolStripMenuItem.Checked = false;
            uSBToolStripMenuItem.Checked = false;
            sérieToolStripMenuItem.Checked = false;
            parallèleToolStripMenuItem.Checked = true;
            settings.SetValue("connectivity", "parallel");
            SearchForDevices();
        }

        private void toutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ethernetToolStripMenuItem.Checked = false;
            uSBToolStripMenuItem.Checked = false;
            sérieToolStripMenuItem.Checked = false;
            parallèleToolStripMenuItem.Checked = false;
            toutesToolStripMenuItem.Checked = true;
            settings.SetValue("connectivity", "all");
            SearchForDevices();
        }



        private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settings.GetValue("langue").ToString() != françaisToolStripMenuItem.Text)
            {
                anglaisToolStripMenuItem.Checked = false;
                françaisToolStripMenuItem.Checked = true;
                settings.SetValue("langue", françaisToolStripMenuItem.Text);
                langue = françaisToolStripMenuItem.Text;
                changer_langue(françaisToolStripMenuItem.Text);
            }
        }


        private void anglaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settings.GetValue("langue").ToString() != anglaisToolStripMenuItem.Text)
            {
                françaisToolStripMenuItem.Checked = false;
                anglaisToolStripMenuItem.Checked = true;
                settings.SetValue("langue", anglaisToolStripMenuItem.Text);
                langue = anglaisToolStripMenuItem.Text;
                changer_langue(anglaisToolStripMenuItem.Text);
            }
        }



        private void manuelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (françaisToolStripMenuItem.Checked)
                {
                    string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Manual_FR.pdf";
                    System.Diagnostics.Process.Start(path);
                }
                else
                    if (anglaisToolStripMenuItem.Checked)
                    {
                        string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Manual_EN.pdf";
                        System.Diagnostics.Process.Start(path);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, traduction[langue]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void aProposToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.ShowDialog();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] localByName = Process.GetProcessesByName("Spooler Universal");

            foreach (var item in localByName)
            {
                if (item.Id != currentProcess.Id)
                {
                    item.Kill();
                }
            }
        }

        

        

       



    }
}
