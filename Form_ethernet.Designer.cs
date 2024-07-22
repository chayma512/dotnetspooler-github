namespace universal
{
    partial class Form_ethernet
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 28);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 0;
            label1.Text = "Nom de l'imprimante :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 81);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "Adresse IP :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 135);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Port :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 186);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 3;
            label4.Text = "Répertoire Spooler :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 238);
            label5.Name = "label5";
            label5.Size = new Size(349, 20);
            label5.TabIndex = 4;
            label5.Text = "Voulez vous vraiment supprimer cette imprimante ?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(199, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(261, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(199, 78);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(261, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(199, 135);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(261, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(199, 188);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(261, 27);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(288, 285);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 9;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(396, 285);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Annuler";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(472, 186);
            button3.Name = "button3";
            button3.Size = new Size(31, 29);
            button3.TabIndex = 11;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form_ethernet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 331);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form_ethernet";
            Text = "Ajouter une imprimante";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private ErrorProvider errorProvider1;
    }
}