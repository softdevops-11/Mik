namespace Minesweeper.GUI
{
    partial class OptionsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMines = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxColums = new System.Windows.Forms.TextBox();
            this.textBoxRows = new System.Windows.Forms.TextBox();
            this.textBoxMines = new System.Windows.Forms.TextBox();
            this.labelCloums = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.43356F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.56643F));
            this.tableLayoutPanel1.Controls.Add(this.labelMines, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRows, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOk, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColums, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRows, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMines, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCloums, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelMines
            // 
            this.labelMines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMines.AutoSize = true;
            this.labelMines.Location = new System.Drawing.Point(3, 84);
            this.labelMines.Name = "labelMines";
            this.labelMines.Size = new System.Drawing.Size(183, 26);
            this.labelMines.TabIndex = 6;
            this.labelMines.Text = "Количество мин (от 0 до 99, но не более 30% игрового поля)";
            // 
            // labelRows
            // 
            this.labelRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(3, 52);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(183, 13);
            this.labelRows.TabIndex = 5;
            this.labelRows.Text = "Количество строк (от 9 до 30)";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(192, 120);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 35);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // textBoxColums
            // 
            this.textBoxColums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxColums.Location = new System.Drawing.Point(192, 9);
            this.textBoxColums.Name = "textBoxColums";
            this.textBoxColums.Size = new System.Drawing.Size(91, 20);
            this.textBoxColums.TabIndex = 1;
            this.textBoxColums.Text = "9";
            this.textBoxColums.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRows
            // 
            this.textBoxRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRows.Location = new System.Drawing.Point(192, 48);
            this.textBoxRows.Name = "textBoxRows";
            this.textBoxRows.Size = new System.Drawing.Size(91, 20);
            this.textBoxRows.TabIndex = 2;
            this.textBoxRows.Text = "9";
            this.textBoxRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMines
            // 
            this.textBoxMines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMines.Location = new System.Drawing.Point(192, 87);
            this.textBoxMines.Name = "textBoxMines";
            this.textBoxMines.Size = new System.Drawing.Size(91, 20);
            this.textBoxMines.TabIndex = 3;
            this.textBoxMines.Text = "10";
            this.textBoxMines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCloums
            // 
            this.labelCloums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCloums.AutoSize = true;
            this.labelCloums.Location = new System.Drawing.Point(3, 13);
            this.labelCloums.Name = "labelCloums";
            this.labelCloums.Size = new System.Drawing.Size(183, 13);
            this.labelCloums.TabIndex = 4;
            this.labelCloums.Text = "Количество столбцов (от 9 до 30)";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 160);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Параметры";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelMines;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.TextBox textBoxColums;
        private System.Windows.Forms.TextBox textBoxRows;
        private System.Windows.Forms.TextBox textBoxMines;
        private System.Windows.Forms.Label labelCloums;
    }
}