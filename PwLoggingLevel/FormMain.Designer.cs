namespace PwLoggingLevel
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            textBoxLogXmlFilePath = new TextBox();
            label1 = new Label();
            buttonXmlFilePath = new Button();
            dataGridView = new DataGridView();
            ColumnCategoryName = new DataGridViewTextBoxColumn();
            ColumnLoggingLevel = new DataGridViewComboBoxColumn();
            buttonSave = new Button();
            buttonRestore = new Button();
            comboBoxLoggingLevelForAll = new ComboBox();
            buttonApplyToAll = new Button();
            buttonRestoreFromBackupFile = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBoxLogXmlFilePath
            // 
            textBoxLogXmlFilePath.Font = new Font("Segoe UI", 12F);
            textBoxLogXmlFilePath.Location = new Point(21, 42);
            textBoxLogXmlFilePath.Name = "textBoxLogXmlFilePath";
            textBoxLogXmlFilePath.Size = new Size(517, 29);
            textBoxLogXmlFilePath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 18);
            label1.Name = "label1";
            label1.Size = new Size(180, 21);
            label1.TabIndex = 1;
            label1.Text = "dmskrnl.log.xml file path";
            // 
            // buttonXmlFilePath
            // 
            buttonXmlFilePath.Font = new Font("Segoe UI", 14F);
            buttonXmlFilePath.Location = new Point(544, 40);
            buttonXmlFilePath.Name = "buttonXmlFilePath";
            buttonXmlFilePath.Size = new Size(36, 34);
            buttonXmlFilePath.TabIndex = 2;
            buttonXmlFilePath.Text = "...";
            buttonXmlFilePath.UseVisualStyleBackColor = true;
            buttonXmlFilePath.Click += buttonXmlFilePath_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnCategoryName, ColumnLoggingLevel });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView.Location = new Point(21, 125);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(559, 284);
            dataGridView.TabIndex = 3;
            // 
            // ColumnCategoryName
            // 
            ColumnCategoryName.HeaderText = "Category";
            ColumnCategoryName.Name = "ColumnCategoryName";
            // 
            // ColumnLoggingLevel
            // 
            ColumnLoggingLevel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnLoggingLevel.HeaderText = "Logging Level";
            ColumnLoggingLevel.Items.AddRange(new object[] { "off", "trace", "info", "warn", "error" });
            ColumnLoggingLevel.Name = "ColumnLoggingLevel";
            ColumnLoggingLevel.Width = 150;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(21, 424);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(36, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save Changes";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonRestore
            // 
            buttonRestore.Location = new Point(328, 83);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(36, 34);
            buttonRestore.TabIndex = 5;
            buttonRestore.Text = "Restore";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += buttonRestore_Click;
            // 
            // comboBoxLoggingLevelForAll
            // 
            comboBoxLoggingLevelForAll.Font = new Font("Segoe UI", 12F);
            comboBoxLoggingLevelForAll.FormattingEnabled = true;
            comboBoxLoggingLevelForAll.Items.AddRange(new object[] { "off", "trace", "info", "warn", "error" });
            comboBoxLoggingLevelForAll.Location = new Point(21, 85);
            comboBoxLoggingLevelForAll.Name = "comboBoxLoggingLevelForAll";
            comboBoxLoggingLevelForAll.Size = new Size(259, 29);
            comboBoxLoggingLevelForAll.TabIndex = 9;
            comboBoxLoggingLevelForAll.Text = "Logging Level for all Categories";
            // 
            // buttonApplyToAll
            // 
            buttonApplyToAll.Location = new Point(286, 83);
            buttonApplyToAll.Name = "buttonApplyToAll";
            buttonApplyToAll.Size = new Size(36, 34);
            buttonApplyToAll.TabIndex = 10;
            buttonApplyToAll.Text = "Save Changes";
            buttonApplyToAll.UseVisualStyleBackColor = true;
            buttonApplyToAll.Click += buttonApplyToAll_Click;
            // 
            // buttonRestoreFromBackupFile
            // 
            buttonRestoreFromBackupFile.Location = new Point(63, 424);
            buttonRestoreFromBackupFile.Name = "buttonRestoreFromBackupFile";
            buttonRestoreFromBackupFile.Size = new Size(36, 34);
            buttonRestoreFromBackupFile.TabIndex = 11;
            buttonRestoreFromBackupFile.Text = "Restore From Backup";
            buttonRestoreFromBackupFile.UseVisualStyleBackColor = true;
            buttonRestoreFromBackupFile.Click += buttonRestoreFromBackupFile_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 488);
            Controls.Add(buttonRestoreFromBackupFile);
            Controls.Add(buttonApplyToAll);
            Controls.Add(comboBoxLoggingLevelForAll);
            Controls.Add(buttonRestore);
            Controls.Add(buttonSave);
            Controls.Add(dataGridView);
            Controls.Add(buttonXmlFilePath);
            Controls.Add(label1);
            Controls.Add(textBoxLogXmlFilePath);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PW Logging Level Adjustment";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogXmlFilePath;
        private Label label1;
        private Button buttonXmlFilePath;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ColumnCategoryName;
        private DataGridViewComboBoxColumn ColumnLoggingLevel;
        private Button buttonSave;
        private Button buttonRestore;
        private ComboBox comboBoxLoggingLevelForAll;
        private Button buttonApplyToAll;
        private Button buttonRestoreFromBackupFile;
    }
}
