namespace WindowsForms
{
    partial class PlayerCtrl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerCtrl));
            this.lblName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblNumb = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.cmAvatar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picFavorite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.cmAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFavorite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblNumb
            // 
            resources.ApplyResources(this.lblNumb, "lblNumb");
            this.lblNumb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNumb.Name = "lblNumb";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.Name = "lblCaptain";
            // 
            // picPlayer
            // 
            this.picPlayer.ContextMenuStrip = this.cmAvatar;
            resources.ApplyResources(this.picPlayer, "picPlayer");
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.TabStop = false;
            // 
            // cmAvatar
            // 
            this.cmAvatar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadImageToolStripMenuItem,
            this.deleteImageToolStripMenuItem});
            this.cmAvatar.Name = "cmAvatar";
            resources.ApplyResources(this.cmAvatar, "cmAvatar");
            // 
            // uploadImageToolStripMenuItem
            // 
            this.uploadImageToolStripMenuItem.Name = "uploadImageToolStripMenuItem";
            resources.ApplyResources(this.uploadImageToolStripMenuItem, "uploadImageToolStripMenuItem");
            this.uploadImageToolStripMenuItem.Click += new System.EventHandler(this.uploadImageToolStripMenuItem_Click);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            resources.ApplyResources(this.deleteImageToolStripMenuItem, "deleteImageToolStripMenuItem");
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // picFavorite
            // 
            this.picFavorite.Image = global::WindowsForms.Properties.Resources.star_regular;
            resources.ApplyResources(this.picFavorite, "picFavorite");
            this.picFavorite.Name = "picFavorite";
            this.picFavorite.TabStop = false;
            // 
            // PlayerCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picFavorite);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblNumb);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblName);
            this.Name = "PlayerCtrl";
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.cmAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFavorite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblNumb;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.PictureBox picFavorite;
        private System.Windows.Forms.ContextMenuStrip cmAvatar;
        private System.Windows.Forms.ToolStripMenuItem uploadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
    }
}
