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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSigningProcess));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tmpSign = new System.Windows.Forms.Timer(this.components);
            this.tmpClose = new System.Windows.Forms.Timer(this.components);
            this.pbxErro = new System.Windows.Forms.PictureBox();
            this.pbxOk = new System.Windows.Forms.PictureBox();
            this.pbxLoad = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxErro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbxErro);
            this.groupBox1.Controls.Add(this.pbxOk);
            this.groupBox1.Controls.Add(this.pbxLoad);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 179);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMessage.Location = new System.Drawing.Point(47, 78);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(333, 31);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Assinando Documento...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmpSign
            // 
            this.tmpSign.Interval = 2000;
            this.tmpSign.Tick += new System.EventHandler(this.tmpSign_TickAsync);
            // 
            // tmpClose
            // 
            this.tmpClose.Interval = 5000;
            this.tmpClose.Tick += new System.EventHandler(this.tmpClose_Tick);
            // 
            // pbxErro
            // 
            this.pbxErro.Image = ((System.Drawing.Image)(resources.GetObject("pbxErro.Image")));
            this.pbxErro.Location = new System.Drawing.Point(369, 43);
            this.pbxErro.Name = "pbxErro";
            this.pbxErro.Size = new System.Drawing.Size(102, 103);
            this.pbxErro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxErro.TabIndex = 4;
            this.pbxErro.TabStop = false;
            this.pbxErro.Visible = false;
            // 
            // pbxOk
            // 
            this.pbxOk.Image = ((System.Drawing.Image)(resources.GetObject("pbxOk.Image")));
            this.pbxOk.Location = new System.Drawing.Point(369, 43);
            this.pbxOk.Name = "pbxOk";
            this.pbxOk.Size = new System.Drawing.Size(102, 103);
            this.pbxOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOk.TabIndex = 3;
            this.pbxOk.TabStop = false;
            this.pbxOk.Visible = false;
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
            this.pbxLoad.DoubleClick += new System.EventHandler(this.pbxLoad_DoubleClick);
            // 
            // FrmSigningProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 193);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSigningProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSigningProcess";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxErro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pbxLoad;
        private System.Windows.Forms.Timer tmpSign;
        private System.Windows.Forms.Timer tmpClose;
        private System.Windows.Forms.PictureBox pbxOk;
        private System.Windows.Forms.PictureBox pbxErro;
    }
}