namespace Spooler_Universal
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imprimanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneImprimanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ethernetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sérieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parallèleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierUneImprimanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerUneImprimanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectivitéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ethernetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parallèleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anglaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.aProposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nom,
            this.taille,
            this.date});
            this.dataGridView1.Location = new System.Drawing.Point(15, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(648, 176);
            this.dataGridView1.TabIndex = 3;
            // 
            // nom
            // 
            this.nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nom.HeaderText = "Nom du fichier";
            this.nom.MinimumWidth = 360;
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nom.Width = 360;
            // 
            // taille
            // 
            this.taille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.taille.HeaderText = "Taille du fichier";
            this.taille.MinimumWidth = 110;
            this.taille.Name = "taille";
            this.taille.ReadOnly = true;
            this.taille.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.taille.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.taille.Width = 110;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.date.HeaderText = "Date de création";
            this.date.MinimumWidth = 145;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Width = 145;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.OnChanged);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.OnChanged);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.OnChanged);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.OnChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(130, 295);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(387, 31);
            this.progressBar1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Imprimer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "0 étiquettes restantes";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(526, 262);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Impression automatique";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(15, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "Annuler";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 260);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimanteToolStripMenuItem,
            this.connectivitéToolStripMenuItem,
            this.langueToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(678, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imprimanteToolStripMenuItem
            // 
            this.imprimanteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneImprimanteToolStripMenuItem,
            this.modifierUneImprimanteToolStripMenuItem,
            this.supprimerUneImprimanteToolStripMenuItem});
            this.imprimanteToolStripMenuItem.Name = "imprimanteToolStripMenuItem";
            this.imprimanteToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.imprimanteToolStripMenuItem.Text = "Imprimante";
            // 
            // ajouterUneImprimanteToolStripMenuItem
            // 
            this.ajouterUneImprimanteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBToolStripMenuItem1,
            this.ethernetToolStripMenuItem1,
            this.sérieToolStripMenuItem1,
            this.parallèleToolStripMenuItem1});
            this.ajouterUneImprimanteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ajouterUneImprimanteToolStripMenuItem.Image")));
            this.ajouterUneImprimanteToolStripMenuItem.Name = "ajouterUneImprimanteToolStripMenuItem";
            this.ajouterUneImprimanteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ajouterUneImprimanteToolStripMenuItem.Text = "Ajouter une imprimante...";
            // 
            // uSBToolStripMenuItem1
            // 
            this.uSBToolStripMenuItem1.Name = "uSBToolStripMenuItem1";
            this.uSBToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.uSBToolStripMenuItem1.Text = "USB";
            this.uSBToolStripMenuItem1.Click += new System.EventHandler(this.uSBToolStripMenuItem1_Click);
            // 
            // ethernetToolStripMenuItem1
            // 
            this.ethernetToolStripMenuItem1.Name = "ethernetToolStripMenuItem1";
            this.ethernetToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.ethernetToolStripMenuItem1.Text = "Ethernet";
            this.ethernetToolStripMenuItem1.Click += new System.EventHandler(this.ethernetToolStripMenuItem1_Click);
            // 
            // sérieToolStripMenuItem1
            // 
            this.sérieToolStripMenuItem1.Name = "sérieToolStripMenuItem1";
            this.sérieToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.sérieToolStripMenuItem1.Text = "Série";
            this.sérieToolStripMenuItem1.Click += new System.EventHandler(this.sérieToolStripMenuItem1_Click);
            // 
            // parallèleToolStripMenuItem1
            // 
            this.parallèleToolStripMenuItem1.Name = "parallèleToolStripMenuItem1";
            this.parallèleToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.parallèleToolStripMenuItem1.Text = "Parallèle";
            this.parallèleToolStripMenuItem1.Click += new System.EventHandler(this.parallèleToolStripMenuItem1_Click);
            // 
            // modifierUneImprimanteToolStripMenuItem
            // 
            this.modifierUneImprimanteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modifierUneImprimanteToolStripMenuItem.Image")));
            this.modifierUneImprimanteToolStripMenuItem.Name = "modifierUneImprimanteToolStripMenuItem";
            this.modifierUneImprimanteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.modifierUneImprimanteToolStripMenuItem.Text = "Modifier une imprimante...";
            this.modifierUneImprimanteToolStripMenuItem.Click += new System.EventHandler(this.modifierUneImprimanteToolStripMenuItem_Click);
            // 
            // supprimerUneImprimanteToolStripMenuItem
            // 
            this.supprimerUneImprimanteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supprimerUneImprimanteToolStripMenuItem.Image")));
            this.supprimerUneImprimanteToolStripMenuItem.Name = "supprimerUneImprimanteToolStripMenuItem";
            this.supprimerUneImprimanteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.supprimerUneImprimanteToolStripMenuItem.Text = "Supprimer une imprimante...";
            this.supprimerUneImprimanteToolStripMenuItem.Click += new System.EventHandler(this.supprimerUneImprimanteToolStripMenuItem_Click);
            // 
            // connectivitéToolStripMenuItem
            // 
            this.connectivitéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBToolStripMenuItem,
            this.ethernetToolStripMenuItem,
            this.sérieToolStripMenuItem,
            this.parallèleToolStripMenuItem,
            this.toutesToolStripMenuItem});
            this.connectivitéToolStripMenuItem.Name = "connectivitéToolStripMenuItem";
            this.connectivitéToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.connectivitéToolStripMenuItem.Text = "Connectivité";
            // 
            // uSBToolStripMenuItem
            // 
            this.uSBToolStripMenuItem.Name = "uSBToolStripMenuItem";
            this.uSBToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.uSBToolStripMenuItem.Text = "USB";
            this.uSBToolStripMenuItem.Click += new System.EventHandler(this.uSBToolStripMenuItem_Click);
            // 
            // ethernetToolStripMenuItem
            // 
            this.ethernetToolStripMenuItem.Name = "ethernetToolStripMenuItem";
            this.ethernetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ethernetToolStripMenuItem.Text = "Ethernet";
            this.ethernetToolStripMenuItem.Click += new System.EventHandler(this.ethernetToolStripMenuItem_Click);
            // 
            // sérieToolStripMenuItem
            // 
            this.sérieToolStripMenuItem.Name = "sérieToolStripMenuItem";
            this.sérieToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.sérieToolStripMenuItem.Text = "Série";
            this.sérieToolStripMenuItem.Click += new System.EventHandler(this.sérieToolStripMenuItem_Click);
            // 
            // parallèleToolStripMenuItem
            // 
            this.parallèleToolStripMenuItem.Name = "parallèleToolStripMenuItem";
            this.parallèleToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.parallèleToolStripMenuItem.Text = "Parallèle";
            this.parallèleToolStripMenuItem.Click += new System.EventHandler(this.parallèleToolStripMenuItem_Click);
            // 
            // toutesToolStripMenuItem
            // 
            this.toutesToolStripMenuItem.Name = "toutesToolStripMenuItem";
            this.toutesToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.toutesToolStripMenuItem.Text = "Toutes";
            this.toutesToolStripMenuItem.Click += new System.EventHandler(this.toutesToolStripMenuItem_Click);
            // 
            // langueToolStripMenuItem
            // 
            this.langueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.françaisToolStripMenuItem,
            this.anglaisToolStripMenuItem});
            this.langueToolStripMenuItem.Name = "langueToolStripMenuItem";
            this.langueToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.langueToolStripMenuItem.Text = "Langue";
            // 
            // françaisToolStripMenuItem
            // 
            this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
            this.françaisToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.françaisToolStripMenuItem.Text = "Français";
            this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
            // 
            // anglaisToolStripMenuItem
            // 
            this.anglaisToolStripMenuItem.Name = "anglaisToolStripMenuItem";
            this.anglaisToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.anglaisToolStripMenuItem.Text = "English";
            this.anglaisToolStripMenuItem.Click += new System.EventHandler(this.anglaisToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuelToolStripMenuItem,
            this.aProposToolStripMenuItem,
            this.aProposToolStripMenuItem1});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // manuelToolStripMenuItem
            // 
            this.manuelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manuelToolStripMenuItem.Image")));
            this.manuelToolStripMenuItem.Name = "manuelToolStripMenuItem";
            this.manuelToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.manuelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.manuelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.manuelToolStripMenuItem.Text = "Manuel";
            this.manuelToolStripMenuItem.Click += new System.EventHandler(this.manuelToolStripMenuItem_Click_1);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(130, 6);
            // 
            // aProposToolStripMenuItem1
            // 
            this.aProposToolStripMenuItem1.Name = "aProposToolStripMenuItem1";
            this.aProposToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.aProposToolStripMenuItem1.Text = "A propos";
            this.aProposToolStripMenuItem1.Click += new System.EventHandler(this.aProposToolStripMenuItem1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(243, 260);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(553, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 30);
            this.button4.TabIndex = 26;
            this.button4.Text = "Vider la liste";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Spooler Universal";
            this.Disposed += new System.EventHandler(this.Form1_Close);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn taille;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imprimanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneImprimanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierUneImprimanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerUneImprimanteToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem connectivitéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ethernetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sérieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parallèleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anglaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ethernetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sérieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parallèleToolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    
    }
}

