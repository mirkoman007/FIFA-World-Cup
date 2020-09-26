namespace WindowsForms.User_Control
{
    partial class MatchCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumb = new System.Windows.Forms.Label();
            this.lblTeams = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumb
            // 
            this.lblNumb.AutoSize = true;
            this.lblNumb.BackColor = System.Drawing.Color.LightGreen;
            this.lblNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumb.Location = new System.Drawing.Point(142, 6);
            this.lblNumb.Name = "lblNumb";
            this.lblNumb.Size = new System.Drawing.Size(89, 31);
            this.lblNumb.TabIndex = 7;
            this.lblNumb.Text = "41064";
            // 
            // lblTeams
            // 
            this.lblTeams.AutoSize = true;
            this.lblTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTeams.Location = new System.Drawing.Point(6, 115);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(149, 18);
            this.lblTeams.TabIndex = 8;
            this.lblTeams.Text = "Tunisia vs England";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLocation.Location = new System.Drawing.Point(6, 83);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(106, 16);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Volgograd Arena";
            // 
            // picPlayer
            // 
            this.picPlayer.Image = global::WindowsForms.Properties.Resources.stadium;
            this.picPlayer.InitialImage = null;
            this.picPlayer.Location = new System.Drawing.Point(6, 6);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(120, 70);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 10;
            this.picPlayer.TabStop = false;
            // 
            // MatchCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTeams);
            this.Controls.Add(this.lblNumb);
            this.Name = "MatchCtrl";
            this.Size = new System.Drawing.Size(244, 148);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumb;
        private System.Windows.Forms.Label lblTeams;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.PictureBox picPlayer;
    }
}
