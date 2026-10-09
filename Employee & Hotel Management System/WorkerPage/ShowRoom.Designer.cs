using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.WorkerPage
{
    partial class ShowRoom
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            labelTitle = new Label();
            panelMain = new Panel();
            panelTop = new Panel();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            btnShow = new Button();
            dataGridView1 = new DataGridView();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1371, 93);
            panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1320, 24);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 47);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(52, 73, 94);
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1269, 24);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 47);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(34, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(225, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Show Rooms";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(panelTop);
            panelMain.Controls.Add(dataGridView1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(34, 40, 34, 40);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblRoomType);
            panelTop.Controls.Add(cmbRoomType);
            panelTop.Controls.Add(btnShow);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(34, 40);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1303, 133);
            panelTop.TabIndex = 0;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRoomType.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomType.Location = new Point(400, 51);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(134, 30);
            lblRoomType.TabIndex = 0;
            lblRoomType.Text = "Room Type:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.BackColor = Color.FromArgb(245, 247, 250);
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.FlatStyle = FlatStyle.Flat;
            cmbRoomType.Font = new Font("Segoe UI", 13F);
            cmbRoomType.Items.AddRange(new object[] { "Single", "Double", "Suite" });
            cmbRoomType.Location = new Point(537, 47);
            cmbRoomType.Margin = new Padding(3, 4, 3, 4);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(228, 38);
            cmbRoomType.TabIndex = 1;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.FromArgb(52, 152, 219);
            btnShow.Cursor = Cursors.Hand;
            btnShow.FlatAppearance.BorderSize = 0;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnShow.ForeColor = Color.White;
            btnShow.Location = new Point(811, 37);
            btnShow.Margin = new Padding(3, 4, 3, 4);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(206, 60);
            btnShow.TabIndex = 2;
            btnShow.Text = "Show Rooms";
            btnShow.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 247, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.Padding = new Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 5, 10, 5);
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new Font("Segoe UI", 11F);
            dataGridView1.GridColor = Color.FromArgb(236, 240, 243);
            dataGridView1.Location = new Point(34, 40);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1303, 827);
            dataGridView1.TabIndex = 1;
            dataGridView1.Visible = false;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ShowRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ShowRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Show Rooms";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;
        
        private Panel panelMain;
        private Panel panelTop;
        private Label lblRoomType;
        private ComboBox cmbRoomType;
        private Button btnShow;
        private DataGridView dataGridView1;
    }
}