namespace NickGenerator
{
    partial class WorsForm
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
            this.Solution = new System.Windows.Forms.Label();
            this.ForceCheck = new System.Windows.Forms.Button();
            this.textInPut = new System.Windows.Forms.TextBox();
            this.textInPut2 = new System.Windows.Forms.TextBox();
            this.Solution2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MixNick = new System.Windows.Forms.ListBox();
            this.help = new System.Windows.Forms.Label();
            this.Dictonery = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Solution
            // 
            this.Solution.AutoSize = true;
            this.Solution.Location = new System.Drawing.Point(264, 24);
            this.Solution.Name = "Solution";
            this.Solution.Size = new System.Drawing.Size(35, 13);
            this.Solution.TabIndex = 0;
            this.Solution.Text = "label1";
            // 
            // ForceCheck
            // 
            this.ForceCheck.Location = new System.Drawing.Point(25, 97);
            this.ForceCheck.Name = "ForceCheck";
            this.ForceCheck.Size = new System.Drawing.Size(131, 24);
            this.ForceCheck.TabIndex = 1;
            this.ForceCheck.Text = "Creat Nicks";
            this.ForceCheck.UseVisualStyleBackColor = true;
            this.ForceCheck.Click += new System.EventHandler(this.ForceCheck_Click);
            // 
            // textInPut
            // 
            this.textInPut.Location = new System.Drawing.Point(25, 24);
            this.textInPut.Name = "textInPut";
            this.textInPut.Size = new System.Drawing.Size(230, 20);
            this.textInPut.TabIndex = 2;
            this.textInPut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInPut_KeyPress);
            // 
            // textInPut2
            // 
            this.textInPut2.Location = new System.Drawing.Point(25, 61);
            this.textInPut2.Name = "textInPut2";
            this.textInPut2.Size = new System.Drawing.Size(230, 20);
            this.textInPut2.TabIndex = 3;
            this.textInPut2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInPut2_KeyPress);
            // 
            // Solution2
            // 
            this.Solution2.AutoSize = true;
            this.Solution2.Location = new System.Drawing.Point(264, 61);
            this.Solution2.Name = "Solution2";
            this.Solution2.Size = new System.Drawing.Size(35, 13);
            this.Solution2.TabIndex = 4;
            this.Solution2.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.Controls.Add(this.Dictonery);
            this.panel1.Controls.Add(this.MixNick);
            this.panel1.Location = new System.Drawing.Point(25, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 177);
            this.panel1.TabIndex = 6;
            // 
            // MixNick
            // 
            this.MixNick.FormattingEnabled = true;
            this.MixNick.Location = new System.Drawing.Point(6, 3);
            this.MixNick.Name = "MixNick";
            this.MixNick.Size = new System.Drawing.Size(161, 160);
            this.MixNick.TabIndex = 6;
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Location = new System.Drawing.Point(28, 8);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(231, 13);
            this.help.TabIndex = 7;
            this.help.Text = "można również zatwierdzić po przez guzik Enter";
            // 
            // Dictonery
            // 
            this.Dictonery.FormattingEnabled = true;
            this.Dictonery.Location = new System.Drawing.Point(206, 4);
            this.Dictonery.Name = "Dictonery";
            this.Dictonery.Size = new System.Drawing.Size(203, 160);
            this.Dictonery.TabIndex = 7;
            // 
            // WorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(464, 336);
            this.Controls.Add(this.help);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Solution2);
            this.Controls.Add(this.textInPut2);
            this.Controls.Add(this.textInPut);
            this.Controls.Add(this.ForceCheck);
            this.Controls.Add(this.Solution);
            this.Name = "WorsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "WorsForm";
            this.ResizeBegin += new System.EventHandler(this.WorsForm_Resize);
            this.Resize += new System.EventHandler(this.WorsForm_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Solution;
        private System.Windows.Forms.Button ForceCheck;
        private System.Windows.Forms.TextBox textInPut;
        private System.Windows.Forms.TextBox textInPut2;
        private System.Windows.Forms.Label Solution2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox MixNick;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.ListBox Dictonery;
    }
}