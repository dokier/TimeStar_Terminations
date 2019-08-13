using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security;
using System.Runtime.InteropServices;
using DataLayer;
using System.Reflection;
using DataLayer.HelperClasses;
using TimeStar_Terminations.UtilityClasses;
using System.Threading;
using System.Linq.Expressions;
using System.Configuration;

namespace TimeStar_Terminations
{
    public partial class Form1 : Form
    {
        //property and dlls required for moving the form around
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //Backround worker for progress bar
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        int rowcount = 0;

        //create a new table to load the text file read
        DataTable dataTable1 = new DataTable();

        public Form1()
        {
            InitializeComponent();
            checkAll_chkBox.Visible = false;
            //Add Headers
            AddColumns();
            

        }

        private void AddColumns()
        {
            dataTable1.Columns.Add("ServerName");
            dataTable1.Columns.Add("DatabaseName");
            dataTable1.Columns.Add("ReadOnly");
            dataTable1.Columns.Add("Status");
            dataTable1.Columns.Add("BackupDate");
            var column = new DataColumn("Select", typeof(bool))
            {
                DefaultValue = false
            };
            dataTable1.Columns.Add(column);
        }
        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            //routine to move form around
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //routine to move form around
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

            DisableButtons();
            this.dataTable1.Clear();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Read the data from text file
                    string[] textData = System.IO.File.ReadAllLines(openFileDialog1.FileName);

                    //Populate Data Table split by comma
                    for (int i = 0; i < textData.Length; i++)
                        dataTable1.Rows.Add(textData[i].Split(','));

                    //Trim cell values in case text file had spaces
                    Utility.trimData(dataTable1);

                    //dataTable1.Rows.Clear();
                    dataTable1 = Utility.RefreshDataGrid(dataTable1);
                    if (dataTable1.Rows.Count > 0)
                    {
                        var column = new DataColumn("Select", typeof(bool))
                        {
                            DefaultValue = false
                        };
                        dataTable1.Columns.Add(column);

                        dataGridView1.DataSource = dataTable1;
                        dataGridView1.Sort(this.dataGridView1.Columns["ServerName"], ListSortDirection.Ascending);
                        dataGridView1.Columns["ReadOnly"].ReadOnly = true;
                        checkAll_chkBox.Visible = true;
                    }
                    else { MessageBox.Show("No rows returned");
                        AddColumns();
                        dataGridView1.DataSource = dataTable1;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            EnableButtons();
        }

        void bw_DoAsyncWork(object sender, DoWorkEventArgs e)
        {
            string method = (string)e.Argument; //Read the method name that was passed as a parameter

            rowcount = 0;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[5];
                    if (cell.Value is true)
                    {
                        rowcount += 1;
                        string serverName = item.Cells[0].Value.ToString();
                        DatabaseLayer objDataLayer = new DatabaseLayer();
                        MethodInfo methodInfo = typeof(DatabaseLayer).GetMethod(method);
                        objDataLayer.ServerName = serverName;
                        objDataLayer.ConnString = objDataLayer.CreateConnectionString(serverName);
                        var thisParameter = Expression.Constant(objDataLayer);
                        ParameterExpression param = Expression.Parameter(typeof(string), item.Cells[1].Value.ToString());
                        MethodCallExpression methodCall = Expression.Call(thisParameter, methodInfo, param);

                        //This was tough! You made it! :)
                        Expression.Lambda(methodCall, param).Compile().DynamicInvoke(item.Cells[1].Value.ToString());
                    }
                }
                if (rowcount == 0)
                {
                    MessageBox.Show("Now rows were selected");
                }
                else
                {
                    if (method == "TakeBackup")
                    { MessageBox.Show("Backup operation completed\n\nBackup Location: " + ConfigurationManager.AppSettings["BackupLocation"]); }
                    dataTable1 = Utility.RefreshDataGrid(dataTable1);
                }
        }

        private void Readonly_BTN_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {
                DisableButtons();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
                string method = "SetReadOnly";
                BackgroundWorker bw = new BackgroundWorker();
                //bw.DoWork += bw_DoSetReadOnlyWork;
                bw.DoWork += bw_DoAsyncWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(argument: method); //correct way of passing a parameter to a BackgroundWorker
            }
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dataTable1.Rows.Count > 0)
            {
                var column = new DataColumn("Select", typeof(bool))
                {
                    DefaultValue = false
                };
                dataTable1.Columns.Add(column);

                dataGridView1.DataSource = dataTable1;
                dataGridView1.Sort(this.dataGridView1.Columns["ServerName"], ListSortDirection.Ascending);
                checkAll_chkBox.Checked = false;
            }
            else
            {
                MessageBox.Show("No rows returned");
                dataGridView1.DataSource = dataTable1;
                AddColumns();
                checkAll_chkBox.Checked = false;
            }
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;

            EnableButtons();
        }
            //Refresh DataGridView
            //if (rowcount > 0)
            //{ 
            
        //}

        private void CheckAll_chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll_chkBox.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];
                    chk.Value = false;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                // Write your code for what you want for this shortcut (Ctrl+N) here
                readwrite_BTN.Visible = true;
                setonline_BTN.Visible = true;

            }*/
        }

        private void Readwrite_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {
                DisableButtons();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
                string method = "SetReadWrite";
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoAsyncWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(argument: method);
            }
        }

        private void Setoffline_BTN_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {
                DisableButtons();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
                string method = "SetOffline";
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoAsyncWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(argument: method);
            }
        }
        private void Setonline_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {
                DisableButtons();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
                string method = "SetOnline";
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoAsyncWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(argument: method);
            }
        }
        public void DisableButtons()
        {
            button1.Enabled = false;
            setoffline_BTN.Enabled = false;
            setonline_BTN.Enabled = false;
            backup_BTN.Enabled = false;
            readonly_BTN.Enabled = false;
            readwrite_BTN.Enabled = false;
            drop_BTN.Enabled = false;
            checkAll_chkBox.Enabled = false;
            dataGridView1.Enabled = false;
        }

        public void EnableButtons()
        {
            button1.Enabled = true;
            setoffline_BTN.Enabled = true;
            setonline_BTN.Enabled = true;
            backup_BTN.Enabled = true;
            readonly_BTN.Enabled = true;
            readwrite_BTN.Enabled = true;
            drop_BTN.Enabled = true;
            checkAll_chkBox.Visible = true;
            checkAll_chkBox.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void Backup_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {
                DisableButtons();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
                string method = "TakeBackup";
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoAsyncWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(argument: method);
            }
        }

        private void Drop_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string message = "Load a txt file first";
                MessageBox.Show(message);
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to drop the database(s)?", "Drop Database(s)", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DisableButtons();

                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 40;
                    string method = "DropDatabase";
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoAsyncWork;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync(argument: method);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                
            }
        }
    }
}

/*
void bw_DoSetReadOnlyWork(object sender, DoWorkEventArgs e)
{
    rowcount = 0;
    foreach (DataGridViewRow item in dataGridView1.Rows)
    {
        DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[4];
        if (cell.Value is true)
        {
            rowcount += 1;
            string serverName = item.Cells[0].Value.ToString();
            DatabaseLayer objDataLayer = new DatabaseLayer();
            objDataLayer.ServerName = serverName;
            objDataLayer.ConnString = objDataLayer.CreateConnectionString(serverName);
            objDataLayer.SetReadOnly(item.Cells[1].Value.ToString());
        }
    }
    if (rowcount == 0) {
        MessageBox.Show("Now rows were selected");
    }
    else
    {
        dataTable1 = Utility.RefreshDataGrid(dataTable1);
    }

}*/
