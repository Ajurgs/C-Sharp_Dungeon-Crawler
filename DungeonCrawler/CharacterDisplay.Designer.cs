namespace DungeonCrawler
{
    partial class CharacterDisplay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.healthLbl = new System.Windows.Forms.Label();
            this.SpriteBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpriteBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.healthLbl);
            this.panel1.Controls.Add(this.SpriteBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            // 
            // healthLbl
            // 
            this.healthLbl.Location = new System.Drawing.Point(5, 80);
            this.healthLbl.Name = "healthLbl";
            this.healthLbl.Size = new System.Drawing.Size(90, 17);
            this.healthLbl.TabIndex = 1;
            // 
            // SpriteBox
            // 
            this.SpriteBox.Location = new System.Drawing.Point(5, 5);
            this.SpriteBox.Name = "SpriteBox";
            this.SpriteBox.Size = new System.Drawing.Size(90, 69);
            this.SpriteBox.TabIndex = 0;
            this.SpriteBox.TabStop = false;
            // 
            // CharacterDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CharacterDisplay";
            this.Size = new System.Drawing.Size(100, 100);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpriteBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox SpriteBox;
        private System.Windows.Forms.Label healthLbl;
    }
}
