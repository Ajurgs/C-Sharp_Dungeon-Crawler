namespace DungeonCrawler
{
    partial class TargetButton
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
            this.targetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(0, 0);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(100, 30);
            this.targetBtn.TabIndex = 0;
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.targetBtn_Click);
            // 
            // TargetButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.targetBtn);
            this.Name = "TargetButton";
            this.Size = new System.Drawing.Size(100, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button targetBtn;
    }
}
