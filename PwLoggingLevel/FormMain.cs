using System.Configuration;
using System.Drawing.Text;
using System.Xml.Linq;

namespace PwLoggingLevel
{
    public partial class FormMain : Form
    {
        private List<Category> _originalCategories;
        private Dictionary<string, string> _originalLoggingLevels;

        public struct Category
        {
            public string CategoryName { get; set; }
            public string LoggingLevel { get; set; }
        }

        public FormMain()
        {
            InitializeComponent();
            PrepareButtons();
            if (LoadDefaultLogXmlFilePath())
            {
                LoadXml();
            }
        }

        private bool LoadDefaultLogXmlFilePath()
        {
            string defaultXmlFilePath = "";
            try
            {
                defaultXmlFilePath = ConfigurationManager.AppSettings["DefaultDmskrnlLogXmlFilePath"];
                if (File.Exists(defaultXmlFilePath))
                {
                    textBoxLogXmlFilePath.Text = defaultXmlFilePath;
                    return true;
                }
            }
            catch
            {
                textBoxLogXmlFilePath.Text = "";
            }

            return false;
        }

        private void LoadXml()
        {
            dataGridView.Rows.Clear();

            XDocument xmlDoc = XDocument.Load(textBoxLogXmlFilePath.Text);
            var categories = xmlDoc.Descendants("category")
                                    .Select(x => new Category
                                    {
                                        CategoryName = x.Attribute("name").Value,
                                        LoggingLevel = x.Element("priority").Attribute("value").Value
                                    }).ToList();

            if (categories.Count == 0)
            {
                MessageBox.Show("No categories found in the XML file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Category category in categories)
            {
                int rowIndex = dataGridView.Rows.Add(); // Add a new row
                dataGridView.Rows[rowIndex].Cells["ColumnCategoryName"].Value = category.CategoryName; // Set the value for CategoryName column

                // Set the value for LoggingLevel column
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["ColumnLoggingLevel"];
                comboBoxCell.Value = category.LoggingLevel;

            }

            // Save original values for restore functionality
            _originalCategories = new List<Category>(categories);
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            await SaveXml();
        }

        private async Task SaveXml()
        {
            if (string.IsNullOrEmpty(textBoxLogXmlFilePath.Text))
            {
                MessageBox.Show("Please select a dmskrnl.log.xml file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (File.Exists(textBoxLogXmlFilePath.Text) == false)
            {
                MessageBox.Show("The selected file does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There are no categories to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LoggingSettingsUpdated() == false)
            {
                MessageBox.Show("No changes to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await Task.Run(() =>
            {
                try
                {
                    SaveCurrentLoggingSettings();

                    if (_originalLoggingLevels != null)
                    {
                        // Save the original logging levels to a backup file to app local data folder
                        string backupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PwLoggingLevelBackup");
                        if (Directory.Exists(backupFolderPath) == false)
                        {
                            Directory.CreateDirectory(backupFolderPath);
                        }
                        string backupFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PwLoggingLevelBackup", $"Backup_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt");
                        // save the original logging levels to the backup file
                        File.WriteAllLines(backupFilePath, _originalCategories.Select(x => $"{x.CategoryName}={x.LoggingLevel}"));
                    }

                    XDocument xmlDoc = XDocument.Load(textBoxLogXmlFilePath.Text);

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        string categoryName = row.Cells["ColumnCategoryName"].Value.ToString();
                        string loggingLevel = row.Cells["ColumnLoggingLevel"].Value.ToString();

                        XElement categoryElement = xmlDoc.Descendants("category")
                                                         .FirstOrDefault(x => x.Attribute("name").Value == categoryName);

                        if (categoryElement != null)
                        {
                            categoryElement.Element("priority").Attribute("value").Value = loggingLevel;
                        }
                    }

                    xmlDoc.Save(textBoxLogXmlFilePath.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            SaveCurrentLoggingSettings();

            MessageBox.Show("Logging settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void PrepareButtons()
        {
            addButtonsIcons();
            addButtonsTooltips();
        }

        private void addButtonsIcons()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("FontAwesome.otf");
            Font fontAwesome = new Font(pfc.Families[0], 16);

            // File path button icon
            buttonXmlFilePath.Font = fontAwesome;
            buttonXmlFilePath.Text = "\uf115";

            // Save button icon
            buttonSave.Font = fontAwesome;
            buttonSave.Text = "\uf0c7";

            // Restore button icon
            buttonRestore.Font = fontAwesome;
            buttonRestore.Text = "\uf0e2"; 

            // Apply to all button icon
            buttonApplyToAll.Font = fontAwesome;
            buttonApplyToAll.Text = "\uf0c5";

            // Restore from backup file button icon
            buttonRestoreFromBackupFile.Font = fontAwesome;
            buttonRestoreFromBackupFile.Text = "\uf0e2"; 

        }

        private void addButtonsTooltips()
        {
            // File path button tooltip
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.buttonXmlFilePath, "Select dmskrnl.log.xml file");

            // Save button tooltip
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.buttonSave, "Save Changes");

            // Restore button tooltip
            ToolTip toolTip3 = new ToolTip();
            toolTip3.AutoPopDelay = 3000;
            toolTip3.InitialDelay = 500;
            toolTip3.ReshowDelay = 500;
            toolTip3.ShowAlways = true;
            toolTip3.SetToolTip(this.buttonRestore, "Restore logging settings in Grid");

            // Apply to all button tooltip
            ToolTip toolTip4 = new ToolTip();
            toolTip4.AutoPopDelay = 3000;
            toolTip4.InitialDelay = 500;
            toolTip4.ReshowDelay = 500;
            toolTip4.ShowAlways = true;
            toolTip4.SetToolTip(this.buttonApplyToAll, "Apply logging setting to all categories");

            // Restore from backup file button tooltip
            ToolTip toolTip5 = new ToolTip();
            toolTip5.AutoPopDelay = 3000;
            toolTip5.InitialDelay = 500;
            toolTip5.ReshowDelay = 500;
            toolTip5.ShowAlways = true;
            toolTip5.SetToolTip(this.buttonRestoreFromBackupFile, "Restore logging settings from backup file");
        }

        private void buttonApplyToAll_Click(object sender, EventArgs e)
        {
            if (comboBoxLoggingLevelForAll.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a logging level to apply to all categories.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There are no categories to apply logging level.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveCurrentLoggingSettings();

            string selectedLoggingLevel = comboBoxLoggingLevelForAll.SelectedItem.ToString();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["ColumnLoggingLevel"].Value = selectedLoggingLevel;
            }
        }

        private void SaveCurrentLoggingSettings()
        {
            _originalLoggingLevels = dataGridView.Rows.Cast<DataGridViewRow>()
                                        .ToDictionary(row => row.Cells["ColumnCategoryName"].Value.ToString(),
                                                      row => row.Cells["ColumnLoggingLevel"].Value.ToString());
        }

        private bool LoggingSettingsUpdated()
        {
            var currentLoggingLevels = new List<Category>(dataGridView.Rows.Cast<DataGridViewRow>()
                                                            .Select(row => new Category
                                                            {
                                                                CategoryName = row.Cells["ColumnCategoryName"].Value.ToString(),
                                                                LoggingLevel = row.Cells["ColumnLoggingLevel"].Value.ToString()
                                                            }));
       
            return currentLoggingLevels.Except(_originalCategories).Any();
        }

        private void restoreLoggingSettings()
        {
            if (_originalLoggingLevels == null)
            {
                MessageBox.Show("There are no logging settings to restore.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string categoryName = row.Cells["ColumnCategoryName"].Value.ToString();
                if (_originalLoggingLevels.ContainsKey(categoryName))
                {
                    row.Cells["ColumnLoggingLevel"].Value = _originalLoggingLevels[categoryName];
                }
            }
        }

        private void restoreLoggingSettingsFromBackupFile(string backupFilePath)
        {
            if (File.Exists(backupFilePath) == false)
            {
                MessageBox.Show("The backup file does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] lines = File.ReadAllLines(backupFilePath);
            Dictionary<string, string> backupLoggingLevels = lines.Select(x => x.Split('='))
                                                                  .ToDictionary(x => x[0], x => x[1]);

            dataGridView.Rows.Clear();
            foreach (var loggingLevel in backupLoggingLevels)
            {
                
                int rowIndex = dataGridView.Rows.Add(); // Add a new row
                dataGridView.Rows[rowIndex].Cells["ColumnCategoryName"].Value = loggingLevel.Key; // Set the value for CategoryName column

                // Set the value for LoggingLevel column
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["ColumnLoggingLevel"];
                comboBoxCell.Value = loggingLevel.Value;
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            restoreLoggingSettings();
        }

        private void buttonXmlFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLogXmlFilePath.Text = openFileDialog.FileName;

                LoadXml();
            }
        }

        private void buttonRestoreFromBackupFile_Click(object sender, EventArgs e)
        {
            string backupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PwLoggingLevelBackup");
            if (Directory.Exists(backupFolderPath) == false)
            {
                Directory.CreateDirectory(backupFolderPath);
            }

            // open file dialog to select the backup file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = backupFolderPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    restoreLoggingSettingsFromBackupFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
