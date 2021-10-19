namespace thermo
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.displayTemp = new System.Windows.Forms.TextBox();
            this.OnorOff = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(604, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // displayTemp
            // 
            this.displayTemp.AccessibleName = "";
            this.displayTemp.Location = new System.Drawing.Point(625, 222);
            this.displayTemp.Name = "displayTemp";
            this.displayTemp.Size = new System.Drawing.Size(100, 29);
            this.displayTemp.TabIndex = 3;
            this.displayTemp.TextChanged += new System.EventHandler(this.displayTemp_TextChanged);
            // 
            // OnorOff
            // 
            this.OnorOff.FormattingEnabled = true;
            this.OnorOff.ItemHeight = 24;
            this.OnorOff.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.OnorOff.Location = new System.Drawing.Point(95, 285);
            this.OnorOff.Name = "OnorOff";
            this.OnorOff.Size = new System.Drawing.Size(120, 76);
            this.OnorOff.TabIndex = 4;
            this.OnorOff.SelectedIndexChanged += new System.EventHandler(this.OnorOff_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OnorOff);
            this.Controls.Add(this.displayTemp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox displayTemp;
        private System.Windows.Forms.ListBox OnorOff;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}

