namespace Minesweeper.GUI
{
    partial class HightScoresForm
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
            this.hightScoresBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // hightScoresBox
            // 
            this.hightScoresBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hightScoresBox.Enabled = false;
            this.hightScoresBox.FormattingEnabled = true;
            this.hightScoresBox.Location = new System.Drawing.Point(0, 0);
            this.hightScoresBox.Name = "hightScoresBox";
            this.hightScoresBox.Size = new System.Drawing.Size(235, 245);
            this.hightScoresBox.TabIndex = 0;
            // 
            // HightScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 245);
            this.Controls.Add(this.hightScoresBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HightScoresForm";
            this.Text = "Таблица рекордов";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox hightScoresBox;
    }
}