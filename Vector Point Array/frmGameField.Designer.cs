namespace Vector_Point_Array
{
    partial class frmGameField
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
            this.picDisplayArea = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRotate = new System.Windows.Forms.Label();
            this.lblThrust = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplayArea)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplayArea
            // 
            this.picDisplayArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDisplayArea.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picDisplayArea.Location = new System.Drawing.Point(19, 18);
            this.picDisplayArea.Name = "picDisplayArea";
            this.picDisplayArea.Size = new System.Drawing.Size(582, 444);
            this.picDisplayArea.TabIndex = 0;
            this.picDisplayArea.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRotate
            // 
            this.lblRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRotate.AutoSize = true;
            this.lblRotate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRotate.Location = new System.Drawing.Point(41, 433);
            this.lblRotate.Name = "lblRotate";
            this.lblRotate.Size = new System.Drawing.Size(22, 13);
            this.lblRotate.TabIndex = 1;
            this.lblRotate.Text = "0.0";
            // 
            // lblThrust
            // 
            this.lblThrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThrust.AutoSize = true;
            this.lblThrust.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblThrust.Location = new System.Drawing.Point(41, 446);
            this.lblThrust.Name = "lblThrust";
            this.lblThrust.Size = new System.Drawing.Size(22, 13);
            this.lblThrust.TabIndex = 2;
            this.lblThrust.Text = "0.0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(23, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "T";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(23, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "R";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(23, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "V";
            // 
            // lblVelocity
            // 
            this.lblVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblVelocity.Location = new System.Drawing.Point(41, 420);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(22, 13);
            this.lblVelocity.TabIndex = 5;
            this.lblVelocity.Text = "0.0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(114, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "ms";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTime.Location = new System.Drawing.Point(69, 446);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "0.0";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(618, 484);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblThrust);
            this.Controls.Add(this.lblRotate);
            this.Controls.Add(this.picDisplayArea);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmGameField";
            this.Text = "Game Play";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmGameField_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGameField_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGameField_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplayArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplayArea;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRotate;
        private System.Windows.Forms.Label lblThrust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTime;
    }
}

