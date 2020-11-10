namespace Vector_Point_Array
{
    partial class Form2
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
            this.lblRotationAngle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMomentumVelocity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMomentumAngle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // lblRotationAngle
            // 
            this.lblRotationAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRotationAngle.AutoSize = true;
            this.lblRotationAngle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRotationAngle.Location = new System.Drawing.Point(41, 445);
            this.lblRotationAngle.Name = "lblRotationAngle";
            this.lblRotationAngle.Size = new System.Drawing.Size(22, 13);
            this.lblRotationAngle.TabIndex = 1;
            this.lblRotationAngle.Text = "0.0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(23, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ra";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(23, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mv";
            // 
            // lblMomentumVelocity
            // 
            this.lblMomentumVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMomentumVelocity.AutoSize = true;
            this.lblMomentumVelocity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMomentumVelocity.Location = new System.Drawing.Point(41, 432);
            this.lblMomentumVelocity.Name = "lblMomentumVelocity";
            this.lblMomentumVelocity.Size = new System.Drawing.Size(22, 13);
            this.lblMomentumVelocity.TabIndex = 5;
            this.lblMomentumVelocity.Text = "0.0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(23, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ma";
            // 
            // lblMomentumAngle
            // 
            this.lblMomentumAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMomentumAngle.AutoSize = true;
            this.lblMomentumAngle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMomentumAngle.Location = new System.Drawing.Point(41, 419);
            this.lblMomentumAngle.Name = "lblMomentumAngle";
            this.lblMomentumAngle.Size = new System.Drawing.Size(22, 13);
            this.lblMomentumAngle.TabIndex = 7;
            this.lblMomentumAngle.Text = "0.0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(114, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ms";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTime.Location = new System.Drawing.Point(69, 445);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "0.0";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(618, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMomentumAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMomentumVelocity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRotationAngle);
            this.Controls.Add(this.picDisplayArea);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form2";
            this.Text = "Font Test";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplayArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplayArea;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRotationAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMomentumVelocity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMomentumAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
    }
}

