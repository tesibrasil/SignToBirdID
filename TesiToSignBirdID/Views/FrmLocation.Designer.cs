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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTopCenter = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnBottomCenter = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 612);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxShowLocation
            // 
            this.cbxShowLocation.AutoSize = true;
            this.cbxShowLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxShowLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbxShowLocation.Location = new System.Drawing.Point(11, 15);
            this.cbxShowLocation.Name = "cbxShowLocation";
            this.cbxShowLocation.Size = new System.Drawing.Size(270, 17);
            this.cbxShowLocation.TabIndex = 1;
            this.cbxShowLocation.Text = "Sempre perguntar o local para a assinatura";
            this.cbxShowLocation.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOk.Location = new System.Drawing.Point(362, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(138, 39);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Aceitar";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnBottomCenter);
            this.groupBox3.Controls.Add(this.btnBottomRight);
            this.groupBox3.Controls.Add(this.btnBottomLeft);
            this.groupBox3.Controls.Add(this.btnTopCenter);
            this.groupBox3.Controls.Add(this.btnTopRight);
            this.groupBox3.Controls.Add(this.btnTopLeft);
            this.groupBox3.Location = new System.Drawing.Point(12, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 516);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnTopCenter
            // 
            this.btnTopCenter.BackColor = System.Drawing.Color.Transparent;
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
            this.btnTopRight.Location = new System.Drawing.Point(340, 5);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(170, 93);
            this.btnTopRight.TabIndex = 2;
            this.btnTopRight.UseVisualStyleBackColor = false;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnTopLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTopLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopLeft.Location = new System.Drawing.Point(1, 5);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(170, 93);
            this.btnTopLeft.TabIndex = 0;
            this.btnTopLeft.UseVisualStyleBackColor = false;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnBottomCenter
            // 
            this.btnBottomCenter.BackColor = System.Drawing.Color.Transparent;
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
            this.btnBottomRight.Location = new System.Drawing.Point(340, 422);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(170, 93);
            this.btnBottomRight.TabIndex = 5;
            this.btnBottomRight.UseVisualStyleBackColor = false;
            this.btnBottomRight.Click += new System.EventHandler(this.btnBottomRight_Click);
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnBottomLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBottomLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBottomLeft.Location = new System.Drawing.Point(1, 422);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(170, 93);
            this.btnBottomLeft.TabIndex = 4;
            this.btnBottomLeft.UseVisualStyleBackColor = false;
            this.btnBottomLeft.Click += new System.EventHandler(this.btnBottomLeft_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(104, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 46);
            this.label2.TabIndex = 7;
            this.label2.Text = "DOCUMENTO";
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 680);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignatureLocation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxShowLocation;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTopCenter;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnBottomCenter;
        private System.Windows.Forms.Button btnBottomRight;
        private System.Windows.Forms.Button btnBottomLeft;
        private System.Windows.Forms.Label label2;
    }
}