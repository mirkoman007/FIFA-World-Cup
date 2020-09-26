namespace WindowsForms
{
    partial class FavoritePlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritePlayers));
            this.flpOtherPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmToFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.cmToOthers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmToFavorites.SuspendLayout();
            this.cmToOthers.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpOtherPlayers
            // 
            resources.ApplyResources(this.flpOtherPlayers, "flpOtherPlayers");
            this.flpOtherPlayers.AllowDrop = true;
            this.flpOtherPlayers.Name = "flpOtherPlayers";
            this.flpOtherPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpOtherPlayers_DragDrop);
            this.flpOtherPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpPlayers_DragEnter);
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpPlayers_DragEnter);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmToFavorites
            // 
            resources.ApplyResources(this.cmToFavorites, "cmToFavorites");
            this.cmToFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavorites});
            this.cmToFavorites.Name = "cmToFavorites";
            this.cmToFavorites.Opened += new System.EventHandler(this.cmPlayer_Opened);
            // 
            // addToFavorites
            // 
            resources.ApplyResources(this.addToFavorites, "addToFavorites");
            this.addToFavorites.Name = "addToFavorites";
            this.addToFavorites.Click += new System.EventHandler(this.addToFavorites_Click);
            // 
            // cmToOthers
            // 
            resources.ApplyResources(this.cmToOthers, "cmToOthers");
            this.cmToOthers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToOthers});
            this.cmToOthers.Name = "cmToFavorite";
            this.cmToOthers.Opened += new System.EventHandler(this.cmPlayer_Opened);
            // 
            // addToOthers
            // 
            resources.ApplyResources(this.addToOthers, "addToOthers");
            this.addToOthers.Name = "addToOthers";
            this.addToOthers.Click += new System.EventHandler(this.addToOthers_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // FavoritePlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpOtherPlayers);
            this.Name = "FavoritePlayers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FavoritePlayers_FormClosing);
            this.Load += new System.EventHandler(this.FavoritePlayers_Load);
            this.cmToFavorites.ResumeLayout(false);
            this.cmToOthers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpOtherPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmToFavorites;
        private System.Windows.Forms.ToolStripMenuItem addToFavorites;
        private System.Windows.Forms.ContextMenuStrip cmToOthers;
        private System.Windows.Forms.ToolStripMenuItem addToOthers;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
    }
}