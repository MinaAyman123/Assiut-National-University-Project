using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.ManagerPage
{
    partial class ShowEmployee
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
            // Header Panel
            this.panelHeader = new Panel();
            this.btnClose = new Button();
            this.btnMinimize = new Button();
            this.labelTitle = new Label();

            // Main Panel
            this.panelMain = new Panel();
            this.groupBoxEmployees = new GroupBox();
            this.dataGridView1 = new DataGridView();

            // Suspend layout
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // ========== panelHeader ==========
            this.panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1200, 70);
            this.panelHeader.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.White;
            this.labelTitle.Location = new Point(30, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(227, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Show Employees";

            // btnMinimize
            this.btnMinimize.BackColor = Color.FromArgb(52, 73, 94);
            this.btnMinimize.Cursor = Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = FlatStyle.Flat;
            this.btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnMinimize.ForeColor = Color.White;
            this.btnMinimize.Location = new Point(1110, 18);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new Size(40, 35);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = false;

            // btnClose
            this.btnClose.BackColor = Color.FromArgb(192, 57, 43);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(1155, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(40, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;

            // ========== panelMain ==========
            this.panelMain.BackColor = Color.FromArgb(236, 240, 243);
            this.panelMain.Controls.Add(this.groupBoxEmployees);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(30);
            this.panelMain.Size = new Size(1200, 680);
            this.panelMain.TabIndex = 1;

            // ========== groupBoxEmployees ==========
            this.groupBoxEmployees.BackColor = Color.White;
            this.groupBoxEmployees.Controls.Add(this.dataGridView1);
            this.groupBoxEmployees.Dock = DockStyle.Fill;
            this.groupBoxEmployees.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.groupBoxEmployees.ForeColor = Color.FromArgb(44, 62, 80);
            this.groupBoxEmployees.Location = new Point(30, 30);
            this.groupBoxEmployees.Name = "groupBoxEmployees";
            this.groupBoxEmployees.Padding = new Padding(20);
            this.groupBoxEmployees.Size = new Size(1140, 620);
            this.groupBoxEmployees.TabIndex = 0;
            this.groupBoxEmployees.TabStop = false;
            this.groupBoxEmployees.Text = "Employees List";

            // ========== dataGridView1 ==========
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.None;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = Color.FromArgb(236, 240, 243);
            this.dataGridView1.Location = new Point(20, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1100, 540);
            this.dataGridView1.TabIndex = 0;

            // Background color
            this.dataGridView1.BackgroundColor = Color.White;

            // Font and colors
            this.dataGridView1.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.dataGridView1.ForeColor = Color.FromArgb(44, 62, 80);

            // Column header style
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.FromArgb(52, 152, 219);
            columnHeaderStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            columnHeaderStyle.ForeColor = Color.White;
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnHeaderStyle.Padding = new Padding(10, 5, 10, 5);
            this.dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Cell style
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            cellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.Padding = new Padding(5, 5, 5, 5);
            cellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            cellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle = cellStyle;

            // Alternating row style
            DataGridViewCellStyle alternatingCellStyle = new DataGridViewCellStyle();
            alternatingCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            alternatingCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            alternatingCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            alternatingCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            alternatingCellStyle.Padding = new Padding(5, 5, 5, 5);
            alternatingCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            alternatingCellStyle.SelectionForeColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = alternatingCellStyle;

            // Allow sorting
            this.dataGridView1.AllowUserToOrderColumns = true;

            // ========== ShowEmployee Form ==========
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ShowEmployee";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Show Employees";
            this.WindowState = FormWindowState.Maximized;

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        private Panel panelMain;
        private GroupBox groupBoxEmployees;
        private DataGridView dataGridView1;
    }
}