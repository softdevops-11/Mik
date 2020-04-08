namespace Temperature
{
    partial class TemperatureForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputComboBoxLabel = new System.Windows.Forms.Label();
            this.inputComboBox = new System.Windows.Forms.ComboBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputComboBoxLabel = new System.Windows.Forms.Label();
            this.outputComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.21995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.78005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.inputComboBoxLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.convertButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.outputTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.outputComboBoxLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.outputComboBox, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(49, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.69388F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.30612F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 195);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputComboBoxLabel
            // 
            this.inputComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxLabel.AutoSize = true;
            this.inputComboBoxLabel.Location = new System.Drawing.Point(3, 0);
            this.inputComboBoxLabel.Name = "inputComboBoxLabel";
            this.inputComboBoxLabel.Size = new System.Drawing.Size(195, 33);
            this.inputComboBoxLabel.TabIndex = 7;
            this.inputComboBoxLabel.Text = "Шкала преобразуемой температуры";
            this.inputComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputComboBox
            // 
            this.inputComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputComboBox.FormattingEnabled = true;
            this.inputComboBox.Items.AddRange(new object[] {
            "Градус Цельсия",
            "Кельвин",
            "Градус Фаренгейта"});
            this.inputComboBox.Location = new System.Drawing.Point(3, 54);
            this.inputComboBox.Name = "inputComboBox";
            this.inputComboBox.Size = new System.Drawing.Size(195, 21);
            this.inputComboBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(3, 116);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(195, 20);
            this.inputTextBox.TabIndex = 4;
            // 
            // convertButton
            // 
            this.convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertButton.Location = new System.Drawing.Point(204, 159);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(164, 33);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Перевести";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(374, 116);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(209, 20);
            this.outputTextBox.TabIndex = 3;
            // 
            // outputComboBoxLabel
            // 
            this.outputComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputComboBoxLabel.AutoSize = true;
            this.outputComboBoxLabel.Location = new System.Drawing.Point(374, 0);
            this.outputComboBoxLabel.Name = "outputComboBoxLabel";
            this.outputComboBoxLabel.Size = new System.Drawing.Size(209, 33);
            this.outputComboBoxLabel.TabIndex = 8;
            this.outputComboBoxLabel.Text = "Шкала преобразованной температуры";
            this.outputComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // outputComboBox
            // 
            this.outputComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputComboBox.FormattingEnabled = true;
            this.outputComboBox.Items.AddRange(new object[] {
            "Градус Цельсия",
            "Кельвин",
            "Градус Фаренгейта"});
            this.outputComboBox.Location = new System.Drawing.Point(374, 54);
            this.outputComboBox.Name = "outputComboBox";
            this.outputComboBox.Size = new System.Drawing.Size(209, 21);
            this.outputComboBox.TabIndex = 9;
            // 
            // TemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TemperatureForm";
            this.Text = "Конвертор температур";
            this.Load += new System.EventHandler(this.TemperatureForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox inputComboBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label inputComboBoxLabel;
        private System.Windows.Forms.Label outputComboBoxLabel;
        private System.Windows.Forms.ComboBox outputComboBox;
    }
}

