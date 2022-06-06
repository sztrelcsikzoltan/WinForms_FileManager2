using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace _211104_FileManager
{
    public partial class WinForms_FileManager2 : Form
    {
        string currentDir = Directory.GetCurrentDirectory();
        bool addRootDirs = false;
        string selectedItem;
        readonly string firstItem = "← GO UP ONE DIRECTORY";
        ListBox listBox_currentDir;

        DataGridView dgv;
        int column0CustomWidth = -1;
        int column1CustomWidth = -1;
        int column2CustomWidth = -1;
        int column3CustomWidth = -1;
        readonly List<string> ColumnNameList = new List<string> { "Name", "Ext", "Size",  "Date" }; // list of column names

        public WinForms_FileManager2()
        {
            InitializeComponent();
            dgv_L.SelectionChanged -= new System.EventHandler(Dgv_L_SelectionChanged);
            dgv_R.SelectionChanged -= new System.EventHandler(Dgv_R_SelectionChanged);

            dgv = dgv_R;
            ChangeSelectionColor(); // remove blue highlight from dgv_R
            dgv.RowHeadersVisible = false;

            listBox_currentDir = listBox_currentDirR;
            ShowData();
            
            
            
            dgv = dgv_L;
            dgv.RowHeadersVisible = false;
            column0CustomWidth = -1;
            column1CustomWidth = -1;
            column2CustomWidth = -1;
            column3CustomWidth = -1;

            listBox_currentDir = listBox_currentDirL;
            ShowData();
            SelectNewRow();
            dgv_L.SelectionChanged += new System.EventHandler(Dgv_L_SelectionChanged);
            dgv_R.SelectionChanged += new System.EventHandler(Dgv_R_SelectionChanged);

            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                MessageBox.Show("Press Enter to move up/down one directory, or use the arrow keys to make your choice.", caption: "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }, DispatcherPriority.Render);
        }


        private void ShowData() {

            ResetDatagridview();

            // add first item IF there is any parent

            int row_index = 0;
            if (addRootDirs == false) {
                dgv.Rows.Add(firstItem); // does it need all column values?
                row_index++;
            }

            // display currentDirectory
            listBox_currentDir.Items.Clear();
            listBox_currentDir.Items.Add(currentDir);
            listBox_currentDir.Items.Add(currentDir);
            float fontSize = (currentDir.Length > 100) ? 8.00F : 9.00F;
            listBox_currentDir.Font = new Font("Tahoma", fontSize, FontStyle.Regular);

            // add root directories except for the current one
            if (addRootDirs == true)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (currentDir != drive.Name)
                    {
                        dgv.Rows.Add(drive.Name);
                    }
                }
            }

            // display directories
            // listBox_view.Items.Add("A megadott mappa könyvtárai:");
            try // to avoid Device is not ready error
            {
                string[] directories = Directory.GetDirectories(currentDir);
                foreach (var dir in directories)
                {
                    try
                    {
                        string[] splits = dir.Split('\\');
                        string dirName = $"{splits[splits.Length - 1]}\\";
                        string creationTime = Directory.GetCreationTime(dir).ToString();
                        string[] row = { dirName, "", "<DIR>", creationTime };
                        dgv.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), caption: "Error message");
                    }

                }
            }
            catch (Exception)
            {
            }

            // add division line
            dgv.Rows.Add("------------------------------------------", "----------", "----------", "----------");
            

            // display files
            // listBox_view.Items.Add("A megadott mappa fájlai:");
            try // to avoid Device is not ready error
            {
                string[] files = Directory.GetFiles(currentDir);
                foreach (var file in files)
                {
                    try
                    {
                        string[] splits = file.Split('\\');
                        string fileName = splits[splits.Length - 1]; // only the file name without path
                        string fileExt = Path.GetExtension(file);
                        string fileSize = new FileInfo(file).Length.ToString() + " bytes";
                        string creationTime = File.GetCreationTime(file).ToString();
                        string[] row = { fileName, fileExt, fileSize, creationTime };
                        dgv.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), caption: "Error message");
                    }

                }
            }
            catch (Exception)
            {
            }
            addRootDirs = false; // reset to false
            dgv.CurrentCell = dgv.Rows[0].Cells[0];
            selectedItem = dgv.CurrentCell.Value.ToString();
        }

        private void ResetDatagridview()
        {
            column0CustomWidth = column0CustomWidth > -1 ? dgv.Columns[0].Width : 300; // keep column width if changed by the user, total: 620
            column1CustomWidth = column1CustomWidth > -1 ? dgv.Columns[1].Width : 90;
            column2CustomWidth = column2CustomWidth > -1 ? dgv.Columns[2].Width : 90;
            column3CustomWidth = column3CustomWidth > -1 ? dgv.Columns[3].Width : 140;
            dgv.AllowUserToAddRows = false; // hide last empty row
            dgv.AllowUserToResizeRows = false;

            dgv.Columns.Clear();
            dgv.ColumnCount = ColumnNameList.Count;

            // setting up columns
            int[] column_width = { column0CustomWidth, column1CustomWidth, column2CustomWidth, column3CustomWidth }; // setting various column width
            int column_index = 0;
            foreach (var columnName in ColumnNameList)
            {
                dgv.Columns[column_index].Name = columnName;
                dgv.Columns[column_index].Width = column_width[column_index];
                dgv.Columns[column_index].HeaderCell.Style.BackColor = Color.Salmon;
                dgv.Columns[column_index].HeaderCell.Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                column_index++;
            }
        }

        private void Dgv_L_SelectionChanged(object sender, EventArgs e)
        {
                // dgv.ClearSelection();
                
                if (dgv != (DataGridView)sender) ChangeSelectionColor();
                dgv = (DataGridView)sender; // select new gdv
                dgv.CurrentCell = dgv.CurrentRow.Cells[0]; // force current cell to column 0
                // string currentcell = dgv.CurrentCell.Value.ToString();
                RemoveHandler();
                SelectNewRow();
                // if(dgv.CurrentCell != null) dgv.Rows[dgv.CurrentCell.RowIndex].Selected = true;
                AddHandler();
        }

        private void Dgv_R_SelectionChanged(object sender, EventArgs e)
        {
                // dgv.ClearSelection();
                if (dgv != (DataGridView)sender) ChangeSelectionColor();
                dgv = (DataGridView)sender; // select new gdv
                dgv.CurrentCell = dgv.CurrentRow.Cells[0]; // force current cell to column 0
                // string currentcell = dgv.CurrentCell.Value.ToString();
                RemoveHandler();
                SelectNewRow();
                // if (dgv.CurrentCell != null) dgv.Rows[dgv.CurrentCell.RowIndex].Selected = true;
                AddHandler();
        }

        private void ChangeSelectionColor()
        {
            dgv.DefaultCellStyle.SelectionBackColor = Color.White; // remove blue selection highlight
            dgv.DefaultCellStyle.SelectionForeColor = Color.Navy;
            if (dgv == dgv_L)
            {
                dgv_R.DefaultCellStyle.SelectionBackColor = Color.Blue; // restore blue selection highlight
                dgv_R.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                dgv_L.DefaultCellStyle.SelectionBackColor = Color.Blue; // restore blue selection highlight
                dgv_L.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void SelectNewRow()
        {
            // dgv.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Blue;
            // dgv.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.White;
            // dgv.DefaultCellStyle.SelectionBackColor = Color.Blue; // restore blue selection highlight
            // dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            // if (dgv.CurrentCell != null) dgv.Rows[dgv.CurrentCell.RowIndex].Selected = true;
            string test = dgv.CurrentCell.Value.ToString();
            dgv.CurrentRow.Selected = true;
            selectedItem = dgv.CurrentCell.Value.ToString();
            listBox_currentDir = dgv == dgv_L ? listBox_currentDirL : listBox_currentDirR; // update listBox_currentDir
            currentDir = listBox_currentDir.Items[0].ToString(); // update currentDir
        }

        private void dgv_L_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // the KeyPreview property of the form must be True!
            {
                RemoveHandler();
                SelectDgv((DataGridView)sender);
                e.SuppressKeyPress = true;
                AddHandler();
            }
            else if (e.KeyCode == Keys.Home)
            {
                RemoveHandler();
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
                AddHandler();
            }
            else if (e.KeyCode == Keys.End)
            {
                RemoveHandler();
                dgv.CurrentCell = dgv.Rows[dgv.RowCount-1].Cells[0];
                AddHandler();
            }
        }

        private void dgv_R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // the KeyPreview property of the form must be True!
            {
                RemoveHandler();
                SelectDgv((DataGridView)sender);
                e.SuppressKeyPress = true;
                AddHandler();
            }
            else if (e.KeyCode == Keys.Home)
            {
                RemoveHandler();
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
                AddHandler();
            }
            else if (e.KeyCode == Keys.End)
            {
                RemoveHandler();
                dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];
                AddHandler();
            }
        }



        private void SelectDgv(DataGridView sender)
        {
            // Go up on directory
            if (dgv.CurrentCell.RowIndex == 0 && selectedItem.Substring(0, 1) == "←")
            {
                if (Directory.GetParent(currentDir) != null) // if there are parents
                {
                    currentDir = Directory.GetParent(currentDir).FullName;
                }
                else // if there are no more parents
                {
                    addRootDirs = true;
                }
                ShowData();
            }
            else
            {
                // if a root drive is selected, make it the new currentDirectory
                if (selectedItem.Substring(selectedItem.Length - 2, 2) == ":\\")
                {
                    currentDir = selectedItem;
                    ShowData();
                }
                // if a directory is selected, then go down (make it the new currentDirectory)
                else if (selectedItem.Substring(selectedItem.Length - 1, 1) == "\\")
                {
                    currentDir += "\\" + selectedItem.Substring(0, selectedItem.Length - 1);
                    ShowData();
                }
            }
        }
        
        private void Button_createDir_Click(object sender, EventArgs e)
        {
            string directory = textBox_createDir.Text;

            if (directory != "")
            {
                if (directory.Contains("\\") || directory.Contains("*"))
                {
                    MessageBox.Show("Directory name must contain special characters!", caption: "Message");
                }
                else
                {
                    directory = $"{currentDir}\\{directory}";
                    if (Directory.Exists(directory) == false)
                    {
                        Directory.CreateDirectory(directory);
                    }
                    else
                    {
                        MessageBox.Show("Directory already exists!");
                        return;
                    }
                    RemoveHandler();
                    ShowData();
                    AddHandler();
                    // if both sides are the same, update both sides
                    if (listBox_currentDirL.Items[0] == listBox_currentDirR.Items[0])
                    {
                        dgv = dgv == dgv_L ? dgv_R : dgv_L;
                        // listBox_view = listBox_view == listBox_viewL ? listBox_viewR : listBox_viewL;
                        RemoveHandler();
                        ShowData();
                        AddHandler();
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Please enter the name of the directory!", caption: "Message");
            }

        }

        private void Button_deleteDir_Click(object sender, EventArgs e)
        {
            string directory = textBox_deleteDir.Text;

            if (directory != "")
            {
                if (directory.Contains("\\") || directory.Contains("*"))
                {
                    MessageBox.Show("Directory name must not contain special characters!", caption: "Message");
                }
                else
                {
                    directory = $"{currentDir}\\{directory}";
                    if (Directory.Exists(directory) == false)
                    { MessageBox.Show("Directory does not exist!", caption: "Message"); }
                    else if (UserAnswer($"Are you sure to DELETE the directory {directory}?", "Question") == true)
                    {
                        try
                        {
                            Directory.Delete(directory);
                            RemoveHandler();
                            ShowData();
                            AddHandler();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), caption: "Error message");
                        }
                    }
                    
                }
                
                // if both sides are the same, update both sides
                if (listBox_currentDirL.Items[0] == listBox_currentDirR.Items[0])
                {
                    dgv = dgv == dgv_L ? dgv_R : dgv_L;
                    // listBox_view = listBox_view == listBox_viewL ? listBox_viewR : listBox_viewL;
                    RemoveHandler();
                    ShowData();
                    AddHandler();
                }

            }
            else
            {
                MessageBox.Show("Please enter the name of the directory!", caption: "Message");
            }
        }

        private void Button_copyFile_Click(object sender, EventArgs e)
        {
            MoveOrCopyFile((Button)sender);
        }

        private void Button_moveFile_Click(object sender, EventArgs e)
        {
            MoveOrCopyFile((Button)sender);
        }

        private void MoveOrCopyFile(Button sender)
        {
            if (selectedItem == null || selectedItem.Substring(selectedItem.Length - 1, 1) == "\\" || selectedItem == "------------------------------------------" || selectedItem == firstItem)
            {
                MessageBox.Show("Please select a file to copy!", caption: "Message");
            }
            else if (listBox_currentDirL.Items[0] == listBox_currentDirR.Items[0])
            {
                MessageBox.Show("Source and target directories are identical. Please choose a different target.", caption: "Message");
            }
            else
            {
                string fileName = $"{currentDir}\\{selectedItem}";
                string targetName = dgv == dgv_L ? listBox_currentDirR.Items[0].ToString() : listBox_currentDirL.Items[0].ToString();
                targetName += $"\\{selectedItem}";
                bool fileOperation = true;
                if (File.Exists(targetName))
                {
                    if (UserAnswer("File already exists. Are you sure to overwrite ?", "Question") == false) fileOperation = false;
                }
                if (fileOperation == true)
                {
                    try
                    {
                        if (sender.Text == "Copy file")
                        {
                            File.Copy(fileName, targetName, true);
                            SwithDgvMultiple();

                        }
                        else if (sender.Text == "Move file")
                        {
                            if (File.Exists(targetName)) File.Delete(targetName); // target must be deleted first, otherwise Move give exception
                            File.Move(fileName, targetName);
                            SwithDgvMultiple();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), caption: "Error message");
                    }
                    
                }
            }
        }

        private bool UserAnswer(string question, string caption)
        {
            bool answer = false;
            DialogResult result_MessageBox = MessageBox.Show(question, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result_MessageBox == DialogResult.Yes) answer = true;
            return answer;

        }

        private void SwitchDgv()
        {

            dgv = dgv == dgv_L ? dgv_R : dgv_L;
            listBox_currentDir = dgv == dgv_L ? listBox_currentDirL : listBox_currentDirR; // update listBox_currentDir
            currentDir = listBox_currentDir.Items[0].ToString(); // update currentDir
        }

        private void SwithDgvMultiple()
        {
            SwitchDgv(); // when copying to the other Dgv, switch is required to display the new file copied
            RemoveHandler();
            ShowData(); // display other Listbox
            AddHandler();
            SwitchDgv(); // switch back
            RemoveHandler();
            ShowData();
            SelectNewRow();
            AddHandler();
        }

        private void Button_deleteFile_Click(object sender, EventArgs e)
        {

            string fileName = $"{currentDir}\\{selectedItem}";
            if (File.Exists(fileName)== false)
            {
                MessageBox.Show("First select a file to delete.", caption: "Message");
                return;
            }
            if (UserAnswer($"Are you sure to DELETE the file {fileName}?", "Question") == true)
            {
                try
                {
                    File.Delete(fileName);
                    RemoveHandler();
                    ShowData();
                    SelectNewRow();
                    AddHandler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), caption: "Error message");
                }
            }
        }

        private void RemoveHandler()
        {
            if (dgv == dgv_L) dgv.SelectionChanged -= new System.EventHandler(Dgv_L_SelectionChanged);
            else dgv.SelectionChanged -= new System.EventHandler(Dgv_R_SelectionChanged);
        }

        private void AddHandler()
        {
            if (dgv == dgv_L) dgv.SelectionChanged += new System.EventHandler(Dgv_L_SelectionChanged);
            else dgv.SelectionChanged += new System.EventHandler(Dgv_R_SelectionChanged);
        }


    }
}
