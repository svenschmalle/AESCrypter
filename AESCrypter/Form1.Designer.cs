namespace AESCrypter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.textBox_crypt = new System.Windows.Forms.TextBox();
            this.button_generieren = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_anzahlspecial = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_laenge = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_special = new System.Windows.Forms.CheckBox();
            this.checkBox_09 = new System.Windows.Forms.CheckBox();
            this.checkBox_AZgross = new System.Windows.Forms.CheckBox();
            this.checkBox_azklein = new System.Windows.Forms.CheckBox();
            this.button_copyklartext = new System.Windows.Forms.Button();
            this.button_copycrypt = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_crypt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_anzahlspecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_laenge)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klartext:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verschlüsselt:";
            // 
            // textBox_text
            // 
            this.textBox_text.Location = new System.Drawing.Point(81, 113);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(296, 20);
            this.textBox_text.TabIndex = 3;
            this.textBox_text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_text_KeyUp);
            this.textBox_text.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox_text_MouseUp);
            // 
            // textBox_crypt
            // 
            this.textBox_crypt.Location = new System.Drawing.Point(81, 137);
            this.textBox_crypt.Name = "textBox_crypt";
            this.textBox_crypt.Size = new System.Drawing.Size(296, 20);
            this.textBox_crypt.TabIndex = 4;
            this.textBox_crypt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_crypt_KeyUp);
            this.textBox_crypt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox_crypt_MouseUp);
            // 
            // button_generieren
            // 
            this.button_generieren.Location = new System.Drawing.Point(204, 66);
            this.button_generieren.Name = "button_generieren";
            this.button_generieren.Size = new System.Drawing.Size(182, 23);
            this.button_generieren.TabIndex = 11;
            this.button_generieren.Text = "Generieren";
            this.button_generieren.UseVisualStyleBackColor = true;
            this.button_generieren.Click += new System.EventHandler(this.button_generieren_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_anzahlspecial);
            this.groupBox1.Controls.Add(this.button_generieren);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_laenge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox_special);
            this.groupBox1.Controls.Add(this.checkBox_09);
            this.groupBox1.Controls.Add(this.checkBox_AZgross);
            this.groupBox1.Controls.Add(this.checkBox_azklein);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Passwort einstellungen";
            // 
            // numericUpDown_anzahlspecial
            // 
            this.numericUpDown_anzahlspecial.Location = new System.Drawing.Point(323, 41);
            this.numericUpDown_anzahlspecial.Name = "numericUpDown_anzahlspecial";
            this.numericUpDown_anzahlspecial.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown_anzahlspecial.TabIndex = 11;
            this.numericUpDown_anzahlspecial.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Anzahl Sonderzeichen:";
            this.label3.Visible = false;
            // 
            // numericUpDown_laenge
            // 
            this.numericUpDown_laenge.Location = new System.Drawing.Point(323, 18);
            this.numericUpDown_laenge.Name = "numericUpDown_laenge";
            this.numericUpDown_laenge.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown_laenge.TabIndex = 10;
            this.numericUpDown_laenge.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Länge Gesamt:";
            // 
            // checkBox_special
            // 
            this.checkBox_special.AutoSize = true;
            this.checkBox_special.Location = new System.Drawing.Point(6, 42);
            this.checkBox_special.Name = "checkBox_special";
            this.checkBox_special.Size = new System.Drawing.Size(146, 17);
            this.checkBox_special.TabIndex = 7;
            this.checkBox_special.Text = "!@#$%^&*()_-+=[{]};:<>|./?";
            this.checkBox_special.UseVisualStyleBackColor = true;
            this.checkBox_special.CheckedChanged += new System.EventHandler(this.checkBox_special_CheckedChanged);
            // 
            // checkBox_09
            // 
            this.checkBox_09.AutoSize = true;
            this.checkBox_09.Location = new System.Drawing.Point(101, 19);
            this.checkBox_09.Name = "checkBox_09";
            this.checkBox_09.Size = new System.Drawing.Size(41, 17);
            this.checkBox_09.TabIndex = 6;
            this.checkBox_09.Text = "0-9";
            this.checkBox_09.UseVisualStyleBackColor = true;
            // 
            // checkBox_AZgross
            // 
            this.checkBox_AZgross.AutoSize = true;
            this.checkBox_AZgross.Location = new System.Drawing.Point(52, 19);
            this.checkBox_AZgross.Name = "checkBox_AZgross";
            this.checkBox_AZgross.Size = new System.Drawing.Size(43, 17);
            this.checkBox_AZgross.TabIndex = 5;
            this.checkBox_AZgross.Text = "A-Z";
            this.checkBox_AZgross.UseVisualStyleBackColor = true;
            // 
            // checkBox_azklein
            // 
            this.checkBox_azklein.AutoSize = true;
            this.checkBox_azklein.Checked = true;
            this.checkBox_azklein.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_azklein.Location = new System.Drawing.Point(6, 19);
            this.checkBox_azklein.Name = "checkBox_azklein";
            this.checkBox_azklein.Size = new System.Drawing.Size(40, 17);
            this.checkBox_azklein.TabIndex = 4;
            this.checkBox_azklein.Text = "a-z";
            this.checkBox_azklein.UseVisualStyleBackColor = true;
            // 
            // button_copyklartext
            // 
            this.button_copyklartext.Image = global::AESCrypter.Properties.Resources.copy16;
            this.button_copyklartext.Location = new System.Drawing.Point(380, 111);
            this.button_copyklartext.Name = "button_copyklartext";
            this.button_copyklartext.Size = new System.Drawing.Size(27, 24);
            this.button_copyklartext.TabIndex = 10;
            this.button_copyklartext.UseVisualStyleBackColor = true;
            this.button_copyklartext.Click += new System.EventHandler(this.button_copyklartext_Click);
            // 
            // button_copycrypt
            // 
            this.button_copycrypt.Image = global::AESCrypter.Properties.Resources.copy16;
            this.button_copycrypt.Location = new System.Drawing.Point(380, 135);
            this.button_copycrypt.Name = "button_copycrypt";
            this.button_copycrypt.Size = new System.Drawing.Size(27, 24);
            this.button_copycrypt.TabIndex = 11;
            this.button_copycrypt.UseVisualStyleBackColor = true;
            this.button_copycrypt.Click += new System.EventHandler(this.button_copycrypt_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_datum,
            this.column_text,
            this.column_crypt});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 165);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(417, 285);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // column_datum
            // 
            this.column_datum.Text = "Datum";
            this.column_datum.Width = 113;
            // 
            // column_text
            // 
            this.column_text.Text = "Klartext";
            this.column_text.Width = 116;
            // 
            // column_crypt
            // 
            this.column_crypt.Text = "Verschlüsselt";
            this.column_crypt.Width = 184;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_copycrypt);
            this.Controls.Add(this.button_copyklartext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_crypt);
            this.Controls.Add(this.textBox_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AESGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_anzahlspecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_laenge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.TextBox textBox_crypt;
        private System.Windows.Forms.Button button_generieren;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_anzahlspecial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_laenge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_special;
        private System.Windows.Forms.CheckBox checkBox_09;
        private System.Windows.Forms.CheckBox checkBox_AZgross;
        private System.Windows.Forms.CheckBox checkBox_azklein;
        private System.Windows.Forms.Button button_copyklartext;
        private System.Windows.Forms.Button button_copycrypt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_datum;
        private System.Windows.Forms.ColumnHeader column_text;
        private System.Windows.Forms.ColumnHeader column_crypt;
    }
}

