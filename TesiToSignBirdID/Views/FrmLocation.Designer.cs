namespace SignBirdID.Views
{
    partial class frmLocation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxShowLocation = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.gbxAllButtons = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHalfRight = new System.Windows.Forms.Button();
            this.btnHalfLeft = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBottomCenter = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.btnTopCenter = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxAllButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o local para a assinatura no documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxShowLocation);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Location = new System.Drawing.Point(12, 593);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxShowLocation
            // 
            this.cbxShowLocation.AutoSize = true;
            this.cbxShowLocation.Checked = true;
            this.cbxShowLocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxShowLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbxShowLocation.Location = new System.Drawing.Point(11, 15);
            this.cbxShowLocation.Name = "cbxShowLocation";
            this.cbxShowLocation.Size = new System.Drawing.Size(270, 17);
            this.cbxShowLocation.TabIndex = 1;
            this.cbxShowLocation.Text = "Sempre perguntar o local para a assinatura";
            this.cbxShowLocation.UseVisualStyleBackColor = true;
            this.cbxShowLocation.CheckedChanged += new System.EventHandler(this.cbxShowLocation_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOk.Location = new System.Drawing.Point(362, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(138, 39);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Assinar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gbxAllButtons
            // 
            this.gbxAllButtons.BackColor = System.Drawing.Color.White;
            this.gbxAllButtons.Controls.Add(this.button1);
            this.gbxAllButtons.Controls.Add(this.btnHalfRight);
            this.gbxAllButtons.Controls.Add(this.btnHalfLeft);
            this.gbxAllButtons.Controls.Add(this.label2);
            this.gbxAllButtons.Controls.Add(this.btnBottomCenter);
            this.gbxAllButtons.Controls.Add(this.btnBottomRight);
            this.gbxAllButtons.Controls.Add(this.btnBottomLeft);
            this.gbxAllButtons.Controls.Add(this.btnTopCenter);
            this.gbxAllButtons.Controls.Add(this.btnTopRight);
            this.gbxAllButtons.Controls.Add(this.btnTopLeft);
            this.gbxAllButtons.Location = new System.Drawing.Point(12, 75);
            this.gbxAllButtons.Name = "gbxAllButtons";
            this.gbxAllButtons.Size = new System.Drawing.Size(511, 516);
            this.gbxAllButtons.TabIndex = 2;
            this.gbxAllButtons.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(170, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 93);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnHalfRight
            // 
            this.btnHalfRight.BackColor = System.Drawing.Color.Transparent;
            this.btnHalfRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHalfRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnHalfRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHalfRight.ForeColor = System.Drawing.Color.Transparent;
            this.btnHalfRight.Location = new System.Drawing.Point(340, 329);
            this.btnHalfRight.Name = "btnHalfRight";
            this.btnHalfRight.Size = new System.Drawing.Size(170, 93);
            this.btnHalfRight.TabIndex = 9;
            this.btnHalfRight.Text = "385:680";
            this.btnHalfRight.UseVisualStyleBackColor = false;
            this.btnHalfRight.Click += new System.EventHandler(this.btnHalfRight_Click);
            // 
            // btnHalfLeft
            // 
            this.btnHalfLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnHalfLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHalfLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnHalfLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHalfLeft.ForeColor = System.Drawing.Color.Transparent;
            this.btnHalfLeft.Location = new System.Drawing.Point(1, 329);
            this.btnHalfLeft.Name = "btnHalfLeft";
            this.btnHalfLeft.Size = new System.Drawing.Size(170, 93);
            this.btnHalfLeft.TabIndex = 8;
            this.btnHalfLeft.Text = "5:680";
            this.btnHalfLeft.UseVisualStyleBackColor = false;
            this.btnHalfLeft.Click += new System.EventHandler(this.btnHalfLeft_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(107, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 46);
            this.label2.TabIndex = 7;
            this.label2.Text = "DOCUMENTO";
            // 
            // btnBottomCenter
            // 
            this.btnBottomCenter.BackColor = System.Drawing.Color.Transparent;
            this.btnBottomCenter.Enabled = false;
            this.btnBottomCenter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBottomCenter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBottomCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBottomCenter.Location = new System.Drawing.Point(170, 422);
            this.btnBottomCenter.Name = "btnBottomCenter";
            this.btnBottomCenter.Size = new System.Drawing.Size(170, 93);
            this.btnBottomCenter.TabIndex = 6;
            this.btnBottomCenter.UseVisualStyleBackColor = false;
            this.btnBottomCenter.Click += new System.EventHandler(this.btnBottomCenter_Click);
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.BackColor = System.Drawing.Color.Transparent;
            this.btnBottomRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBottomRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBottomRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBottomRight.ForeColor = System.Drawing.Color.Transparent;
            this.btnBottomRight.Location = new System.Drawing.Point(340, 422);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(170, 93);
            this.btnBottomRight.TabIndex = 5;
            this.btnBottomRight.Text = "385:780";
            this.btnBottomRight.UseVisualStyleBackColor = false;
            this.btnBottomRight.Click += new System.EventHandler(this.btnBottomRight_Click);
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnBottomLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBottomLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBottomLeft.ForeColor = System.Drawing.Color.Transparent;
            this.btnBottomLeft.Location = new System.Drawing.Point(1, 422);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(170, 93);
            this.btnBottomLeft.TabIndex = 4;
            this.btnBottomLeft.Text = "5:780";
            this.btnBottomLeft.UseVisualStyleBackColor = false;
            this.btnBottomLeft.Click += new System.EventHandler(this.btnBottomLeft_Click);
            // 
            // btnTopCenter
            // 
            this.btnTopCenter.BackColor = System.Drawing.Color.Transparent;
            this.btnTopCenter.Enabled = false;
            this.btnTopCenter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTopCenter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTopCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopCenter.Location = new System.Drawing.Point(170, 5);
            this.btnTopCenter.Name = "btnTopCenter";
            this.btnTopCenter.Size = new System.Drawing.Size(170, 93);
            this.btnTopCenter.TabIndex = 3;
            this.btnTopCenter.UseVisualStyleBackColor = false;
            this.btnTopCenter.Click += new System.EventHandler(this.btnTopCenter_Click);
            // 
            // btnTopRight
            // 
            this.btnTopRight.BackColor = System.Drawing.Color.Transparent;
            this.btnTopRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTopRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTopRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopRight.ForeColor = System.Drawing.Color.Transparent;
            this.btnTopRight.Location = new System.Drawing.Point(340, 5);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(170, 93);
            this.btnTopRight.TabIndex = 2;
            this.btnTopRight.Text = "385:5";
            this.btnTopRight.UseVisualStyleBackColor = false;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnTopLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTopLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopLeft.ForeColor = System.Drawing.Color.Transparent;
            this.btnTopLeft.Location = new System.Drawing.Point(1, 5);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(170, 93);
            this.btnTopLeft.TabIndex = 0;
            this.btnTopLeft.Text = "5:5";
            this.btnTopLeft.UseVisualStyleBackColor = false;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 666);
            this.Controls.Add(this.gbxAllButtons);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignatureLocation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxAllButtons.ResumeLayout(false);
            this.gbxAllButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxShowLocation;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbxAllButtons;
        private System.Windows.Forms.Button btnTopCenter;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnBottomCenter;
        private System.Windows.Forms.Button btnBottomRight;
        private System.Windows.Forms.Button btnBottomLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHalfRight;
        private System.Windows.Forms.Button btnHalfLeft;
    }
}