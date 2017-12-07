namespace secret_true_version
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSD = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSMI_EA = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_RU = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_FR = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ES = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_DE = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_POL = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_UA = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // SS
            // 
            this.SS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TSSD});
            resources.ApplyResources(this.SS, "SS");
            this.SS.Name = "SS";
            this.SS.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SS_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // TSSD
            // 
            this.TSSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSSD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_EA,
            this.TSMI_RU,
            this.TSMI_FR,
            this.TSMI_ES,
            this.TSMI_DE,
            this.TSMI_POL,
            this.TSMI_UA});
            resources.ApplyResources(this.TSSD, "TSSD");
            this.TSSD.Name = "TSSD";
            // 
            // TSMI_EA
            // 
            this.TSMI_EA.Image = global::secret_true_version.Properties.Resources.flag_of_United_States_of_America;
            this.TSMI_EA.Name = "TSMI_EA";
            resources.ApplyResources(this.TSMI_EA, "TSMI_EA");
            this.TSMI_EA.Click += new System.EventHandler(this.TSMI_EA_Click);
            // 
            // TSMI_RU
            // 
            this.TSMI_RU.Image = global::secret_true_version.Properties.Resources.flag_of_Russia;
            this.TSMI_RU.Name = "TSMI_RU";
            resources.ApplyResources(this.TSMI_RU, "TSMI_RU");
            this.TSMI_RU.Click += new System.EventHandler(this.TSMI_RU_Click);
            // 
            // TSMI_FR
            // 
            this.TSMI_FR.Image = global::secret_true_version.Properties.Resources.flag_of_France;
            this.TSMI_FR.Name = "TSMI_FR";
            resources.ApplyResources(this.TSMI_FR, "TSMI_FR");
            this.TSMI_FR.Click += new System.EventHandler(this.TSMI_FR_Click);
            // 
            // TSMI_ES
            // 
            this.TSMI_ES.Image = global::secret_true_version.Properties.Resources.flag_of_Spain;
            this.TSMI_ES.Name = "TSMI_ES";
            resources.ApplyResources(this.TSMI_ES, "TSMI_ES");
            this.TSMI_ES.Click += new System.EventHandler(this.TSMI_ES_Click);
            // 
            // TSMI_DE
            // 
            this.TSMI_DE.Image = global::secret_true_version.Properties.Resources.flag_of_Germany;
            this.TSMI_DE.Name = "TSMI_DE";
            resources.ApplyResources(this.TSMI_DE, "TSMI_DE");
            this.TSMI_DE.Click += new System.EventHandler(this.TSMI_DE_Click);
            // 
            // TSMI_POL
            // 
            this.TSMI_POL.Image = global::secret_true_version.Properties.Resources.flag_of_Poland;
            this.TSMI_POL.Name = "TSMI_POL";
            resources.ApplyResources(this.TSMI_POL, "TSMI_POL");
            this.TSMI_POL.Click += new System.EventHandler(this.TSMI_POL_Click);
            // 
            // TSMI_UA
            // 
            this.TSMI_UA.Image = global::secret_true_version.Properties.Resources.flag_of_Ukraine;
            this.TSMI_UA.Name = "TSMI_UA";
            resources.ApplyResources(this.TSMI_UA, "TSMI_UA");
            this.TSMI_UA.Click += new System.EventHandler(this.TSMI_UA_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.Name = "richTextBox2";
            // 
            // richTextBox4
            // 
            resources.ApplyResources(this.richTextBox4, "richTextBox4");
            this.richTextBox4.Name = "richTextBox4";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // richTextBox3
            // 
            resources.ApplyResources(this.richTextBox3, "richTextBox3");
            this.richTextBox3.Name = "richTextBox3";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SS);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SS.ResumeLayout(false);
            this.SS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.StatusStrip SS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton TSSD;
        private System.Windows.Forms.ToolStripMenuItem TSMI_EA;
        private System.Windows.Forms.ToolStripMenuItem TSMI_RU;
        private System.Windows.Forms.ToolStripMenuItem TSMI_FR;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ES;
        private System.Windows.Forms.ToolStripMenuItem TSMI_DE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem TSMI_POL;
        private System.Windows.Forms.ToolStripMenuItem TSMI_UA;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

