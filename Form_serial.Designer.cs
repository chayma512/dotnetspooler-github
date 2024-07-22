namespace universal
{
    partial class Form_serial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.comboBox1 = new System.Windows.Forms.ComboBox();
                this.label5 = new System.Windows.Forms.Label();
                this.button3 = new System.Windows.Forms.Button();
                this.textBox4 = new System.Windows.Forms.TextBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.button2 = new System.Windows.Forms.Button();
                this.button1 = new System.Windows.Forms.Button();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
                this.SuspendLayout();
                // 
                // comboBox1
                // 
                this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
                this.comboBox1.Location = new System.Drawing.Point(169, 89);
                this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(268, 24);
                this.comboBox1.TabIndex = 26;
                this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label5.ForeColor = System.Drawing.Color.Red;
                this.label5.Location = new System.Drawing.Point(19, 158);
                this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(393, 20);
                this.label5.TabIndex = 25;
                this.label5.Text = "Voulez vous vraiment supprimer cette imprimante ?";
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(444, 121);
                this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(37, 26);
                this.button3.TabIndex = 24;
                this.button3.Text = "...";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // textBox4
                // 
                this.textBox4.Location = new System.Drawing.Point(169, 122);
                this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.textBox4.Name = "textBox4";
                this.textBox4.Size = new System.Drawing.Size(265, 22);
                this.textBox4.TabIndex = 23;
                this.textBox4.TabStop = false;
                this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(19, 126);
                this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(128, 16);
                this.label4.TabIndex = 22;
                this.label4.Text = "Répertoire Spooler :";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(19, 92);
                this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(108, 16);
                this.label3.TabIndex = 21;
                this.label3.Text = "Vitesse (Bauds) :";
                // 
                // textBox2
                // 
                this.textBox2.Location = new System.Drawing.Point(169, 57);
                this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.textBox2.MaxLength = 15;
                this.textBox2.Name = "textBox2";
                this.textBox2.Size = new System.Drawing.Size(268, 22);
                this.textBox2.TabIndex = 17;
                this.textBox2.TabStop = false;
                this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(19, 60);
                this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(86, 16);
                this.label2.TabIndex = 19;
                this.label2.Text = "Nom du port :";
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(381, 193);
                this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(100, 28);
                this.button2.TabIndex = 20;
                this.button2.Text = "Annuler";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(273, 193);
                this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(100, 28);
                this.button1.TabIndex = 18;
                this.button1.Text = "Ok";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(169, 26);
                this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(268, 22);
                this.textBox1.TabIndex = 16;
                this.textBox1.TabStop = false;
                this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(19, 30);
                this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(136, 16);
                this.label1.TabIndex = 15;
                this.label1.Text = "Nom de l\'imprimante :";
                // 
                // errorProvider1
                // 
                this.errorProvider1.ContainerControl = this;
                // 
                // Form_serial
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(504, 236);
                this.Controls.Add(this.comboBox1);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.textBox4);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.textBox2);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.label1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "Form_serial";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Ajouter une imprimante";
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}