namespace Minesweeper.GUI
{
    partial class HighScoresForm
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
            this.highScoresBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // highScoresBox
            // 
            this.highScoresBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highScoresBox.Enabled = false;
            this.highScoresBox.FormattingEnabled = true;
            this.highScoresBox.Location = new System.Drawing.Point(0, 0);
            this.highScoresBox.Name = "highScoresBox";
            this.highScoresBox.Size = new System.Drawing.Size(235, 245);
            this.highScoresBox.TabIndex = 0;
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 245);
            this.Controls.Add(this.highScoresBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HighScoresForm";
            this.Text = "Таблица рекордов";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox highScoresBox;
    }
}