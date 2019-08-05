namespace TimeStar_Terminations
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkAll_chkBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setonline_BTN = new System.Windows.Forms.Button();
            this.readwrite_BTN = new System.Windows.Forms.Button();
            this.setoffline_BTN = new System.Windows.Forms.Button();
            this.backup_BTN = new System.Windows.Forms.Button();
            this.readonly_BTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.drop_BTN = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.checkAll_chkBox);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(209, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1471, 578);
            this.panel3.TabIndex = 3;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel3_MouseDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 555);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1471, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // checkAll_chkBox
            // 
            this.checkAll_chkBox.AutoSize = true;
            this.checkAll_chkBox.Location = new System.Drawing.Point(1308, 45);
            this.checkAll_chkBox.Name = "checkAll_chkBox";
            this.checkAll_chkBox.Size = new System.Drawing.Size(18, 17);
            this.checkAll_chkBox.TabIndex = 1;
            this.checkAll_chkBox.UseVisualStyleBackColor = true;
            this.checkAll_chkBox.CheckedChanged += new System.EventHandler(this.CheckAll_chkBox_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(33, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1403, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImage = global::TimeStar_Terminations.Properties.Resources.green_to_blue;
            this.panel1.Controls.Add(this.drop_BTN);
            this.panel1.Controls.Add(this.setonline_BTN);
            this.panel1.Controls.Add(this.readwrite_BTN);
            this.panel1.Controls.Add(this.setoffline_BTN);
            this.panel1.Controls.Add(this.backup_BTN);
            this.panel1.Controls.Add(this.readonly_BTN);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 578);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // setonline_BTN
            // 
            this.setonline_BTN.BackColor = System.Drawing.Color.Transparent;
            this.setonline_BTN.FlatAppearance.BorderSize = 0;
            this.setonline_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.setonline_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setonline_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setonline_BTN.ForeColor = System.Drawing.Color.White;
            this.setonline_BTN.Location = new System.Drawing.Point(0, 423);
            this.setonline_BTN.Name = "setonline_BTN";
            this.setonline_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.setonline_BTN.Size = new System.Drawing.Size(207, 41);
            this.setonline_BTN.TabIndex = 6;
            this.setonline_BTN.Text = "Set Online";
            this.setonline_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setonline_BTN.UseVisualStyleBackColor = false;
            this.setonline_BTN.Visible = false;
            this.setonline_BTN.Click += new System.EventHandler(this.Setonline_BTN_Click);
            // 
            // readwrite_BTN
            // 
            this.readwrite_BTN.BackColor = System.Drawing.Color.Transparent;
            this.readwrite_BTN.FlatAppearance.BorderSize = 0;
            this.readwrite_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.readwrite_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readwrite_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readwrite_BTN.ForeColor = System.Drawing.Color.White;
            this.readwrite_BTN.Location = new System.Drawing.Point(0, 373);
            this.readwrite_BTN.Name = "readwrite_BTN";
            this.readwrite_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.readwrite_BTN.Size = new System.Drawing.Size(207, 41);
            this.readwrite_BTN.TabIndex = 5;
            this.readwrite_BTN.Text = "Set Read/Write";
            this.readwrite_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.readwrite_BTN.UseVisualStyleBackColor = false;
            this.readwrite_BTN.Visible = false;
            this.readwrite_BTN.Click += new System.EventHandler(this.Readwrite_BTN_Click);
            // 
            // setoffline_BTN
            // 
            this.setoffline_BTN.BackColor = System.Drawing.Color.Transparent;
            this.setoffline_BTN.FlatAppearance.BorderSize = 0;
            this.setoffline_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.setoffline_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setoffline_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setoffline_BTN.ForeColor = System.Drawing.Color.White;
            this.setoffline_BTN.Location = new System.Drawing.Point(0, 250);
            this.setoffline_BTN.Name = "setoffline_BTN";
            this.setoffline_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.setoffline_BTN.Size = new System.Drawing.Size(207, 41);
            this.setoffline_BTN.TabIndex = 4;
            this.setoffline_BTN.Text = "Set Offline";
            this.setoffline_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setoffline_BTN.UseVisualStyleBackColor = false;
            this.setoffline_BTN.Click += new System.EventHandler(this.Setoffline_BTN_Click);
            // 
            // backup_BTN
            // 
            this.backup_BTN.BackColor = System.Drawing.Color.Transparent;
            this.backup_BTN.FlatAppearance.BorderSize = 0;
            this.backup_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.backup_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backup_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backup_BTN.ForeColor = System.Drawing.Color.White;
            this.backup_BTN.Location = new System.Drawing.Point(0, 202);
            this.backup_BTN.Name = "backup_BTN";
            this.backup_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.backup_BTN.Size = new System.Drawing.Size(207, 41);
            this.backup_BTN.TabIndex = 3;
            this.backup_BTN.Text = "Backup";
            this.backup_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backup_BTN.UseVisualStyleBackColor = false;
            this.backup_BTN.Click += new System.EventHandler(this.Backup_BTN_Click);
            // 
            // readonly_BTN
            // 
            this.readonly_BTN.BackColor = System.Drawing.Color.Transparent;
            this.readonly_BTN.FlatAppearance.BorderSize = 0;
            this.readonly_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.readonly_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readonly_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readonly_BTN.ForeColor = System.Drawing.Color.White;
            this.readonly_BTN.Location = new System.Drawing.Point(0, 154);
            this.readonly_BTN.Name = "readonly_BTN";
            this.readonly_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.readonly_BTN.Size = new System.Drawing.Size(207, 41);
            this.readonly_BTN.TabIndex = 2;
            this.readonly_BTN.Text = "Set Read Only";
            this.readonly_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.readonly_BTN.UseVisualStyleBackColor = false;
            this.readonly_BTN.Click += new System.EventHandler(this.Readonly_BTN_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 477);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(207, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 106);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(207, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // drop_BTN
            // 
            this.drop_BTN.BackColor = System.Drawing.Color.Transparent;
            this.drop_BTN.FlatAppearance.BorderSize = 0;
            this.drop_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.drop_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drop_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drop_BTN.ForeColor = System.Drawing.Color.White;
            this.drop_BTN.Location = new System.Drawing.Point(1, 298);
            this.drop_BTN.Name = "drop_BTN";
            this.drop_BTN.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.drop_BTN.Size = new System.Drawing.Size(207, 41);
            this.drop_BTN.TabIndex = 7;
            this.drop_BTN.Text = "Drop Database";
            this.drop_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drop_BTN.UseVisualStyleBackColor = false;
            this.drop_BTN.Click += new System.EventHandler(this.Drop_BTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 578);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setoffline_BTN;
        private System.Windows.Forms.Button backup_BTN;
        private System.Windows.Forms.Button readonly_BTN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkAll_chkBox;
        private System.Windows.Forms.Button readwrite_BTN;
        private System.Windows.Forms.Button setonline_BTN;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button drop_BTN;
    }
}

