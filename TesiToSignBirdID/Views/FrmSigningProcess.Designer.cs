namespace SignBirdID.Views
{
    partial class FrmSigningProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSigningProcess));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbxLoad);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 179);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // pbxLoad
            // 
            this.pbxLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbxLoad.Image")));
            this.pbxLoad.Location = new System.Drawing.Point(346, 19);
            this.pbxLoad.Name = "pbxLoad";
            this.pbxLoad.Size = new System.Drawing.Size(150, 150);
            this.pbxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLoad.TabIndex = 2;
            this.pbxLoad.TabStop = false;
            this.pbxLoad.Click += new System.EventHandler(this.pbxLoad_Click);
            this.pbxLoad.DoubleClick += new System.EventHandler(this.pbxLoad_DoubleClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMessage.Location = new System.Drawing.Point(10, 74);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(333, 31);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Assinando Documento...";
            // 
            // FrmSigningProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 193);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSigningProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSigningProcess";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pbxLoad;
    }
}