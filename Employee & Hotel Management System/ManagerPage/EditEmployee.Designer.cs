using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.ManagerPage
{
    partial class EditEmployee
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
            panelHeader = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            labelTitle = new Label();
            panelMain = new Panel();
            panelSelect = new Panel();
            lblSelectEmployee = new Label();
            cmbEmployee = new ComboBox();
            btnShowDetails = new Button();
            panelEmployeeInfo = new Panel();
            lblName = new Label();
            lblNameValue = new Label();
            lblDepartment = new Label();
            txtDepartment = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblSalary = new Label();
            txtSalary = new TextBox();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelSelect.SuspendLayout();
            panelEmployeeInfo.SuspendLayout();
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
            labelTitle.Size = new Size(246, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Edit Employee";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(panelSelect);
            panelMain.Controls.Add(panelEmployeeInfo);
            panelMain.Controls.Add(btnSave);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(91, 107, 91, 107);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // panelSelect
            // 
            panelSelect.BackColor = Color.White;
            panelSelect.Controls.Add(lblSelectEmployee);
            panelSelect.Controls.Add(cmbEmployee);
            panelSelect.Controls.Add(btnShowDetails);
            panelSelect.Dock = DockStyle.Top;
            panelSelect.Location = new Point(91, 107);
            panelSelect.Margin = new Padding(3, 4, 3, 4);
            panelSelect.Name = "panelSelect";
            panelSelect.Size = new Size(1189, 200);
            panelSelect.TabIndex = 0;
            // 
            // lblSelectEmployee
            // 
            lblSelectEmployee.AutoSize = true;
            lblSelectEmployee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSelectEmployee.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectEmployee.Location = new Point(57, 53);
            lblSelectEmployee.Name = "lblSelectEmployee";
            lblSelectEmployee.Size = new Size(206, 32);
            lblSelectEmployee.TabIndex = 0;
            lblSelectEmployee.Text = "Select Employee:";
            // 
            // cmbEmployee
            // 
            cmbEmployee.BackColor = Color.FromArgb(245, 247, 250);
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FlatStyle = FlatStyle.Flat;
            cmbEmployee.Font = new Font("Segoe UI", 13F);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(57, 100);
            cmbEmployee.Margin = new Padding(3, 4, 3, 4);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(571, 38);
            cmbEmployee.TabIndex = 1;
            // 
            // btnShowDetails
            // 
            btnShowDetails.BackColor = Color.FromArgb(52, 152, 219);
            btnShowDetails.Cursor = Cursors.Hand;
            btnShowDetails.FlatAppearance.BorderSize = 0;
            btnShowDetails.FlatStyle = FlatStyle.Flat;
            btnShowDetails.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnShowDetails.ForeColor = Color.White;
            btnShowDetails.Location = new Point(686, 87);
            btnShowDetails.Margin = new Padding(3, 4, 3, 4);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(286, 67);
            btnShowDetails.TabIndex = 2;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = false;
            btnShowDetails.Click += btnShowDetails_Click_1;
            // 
            // panelEmployeeInfo
            // 
            panelEmployeeInfo.BackColor = Color.White;
            panelEmployeeInfo.Controls.Add(lblName);
            panelEmployeeInfo.Controls.Add(lblNameValue);
            panelEmployeeInfo.Controls.Add(lblDepartment);
            panelEmployeeInfo.Controls.Add(txtDepartment);
            panelEmployeeInfo.Controls.Add(lblPhone);
            panelEmployeeInfo.Controls.Add(txtPhone);
            panelEmployeeInfo.Controls.Add(lblSalary);
            panelEmployeeInfo.Controls.Add(txtSalary);
            panelEmployeeInfo.Location = new Point(91, 347);
            panelEmployeeInfo.Margin = new Padding(3, 4, 3, 4);
            panelEmployeeInfo.Name = "panelEmployeeInfo";
            panelEmployeeInfo.Size = new Size(1189, 427);
            panelEmployeeInfo.TabIndex = 1;
            panelEmployeeInfo.Visible = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(891, 67);
            lblName.Name = "lblName";
            lblName.Size = new Size(80, 30);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 13F);
            lblNameValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblNameValue.Location = new Point(571, 67);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(65, 30);
            lblNameValue.TabIndex = 1;
            lblNameValue.Text = "Value";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(44, 62, 80);
            lblDepartment.Location = new Point(891, 147);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(146, 30);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            txtDepartment.BackColor = Color.FromArgb(245, 247, 250);
            txtDepartment.BorderStyle = BorderStyle.FixedSingle;
            txtDepartment.Font = new Font("Segoe UI", 13F);
            txtDepartment.Location = new Point(571, 144);
            txtDepartment.Margin = new Padding(3, 4, 3, 4);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(285, 36);
            txtDepartment.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhone.Location = new Point(891, 227);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(84, 30);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(245, 247, 250);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 13F);
            txtPhone.Location = new Point(571, 224);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(285, 36);
            txtPhone.TabIndex = 5;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSalary.ForeColor = Color.FromArgb(44, 62, 80);
            lblSalary.Location = new Point(891, 307);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(83, 30);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "Salary:";
            // 
            // txtSalary
            // 
            txtSalary.BackColor = Color.FromArgb(245, 247, 250);
            txtSalary.BorderStyle = BorderStyle.FixedSingle;
            txtSalary.Font = new Font("Segoe UI", 13F);
            txtSalary.Location = new Point(571, 304);
            txtSalary.Margin = new Padding(3, 4, 3, 4);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(285, 36);
            txtSalary.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(457, 827);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(457, 80);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Employee";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelSelect.ResumeLayout(false);
            panelSelect.PerformLayout();
            panelEmployeeInfo.ResumeLayout(false);
            panelEmployeeInfo.PerformLayout();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        private Panel panelMain;
        private Panel panelSelect;
        private Label lblSelectEmployee;
        private ComboBox cmbEmployee;
        private Button btnShowDetails;

        private Panel panelEmployeeInfo;
        private Label lblName;
        private Label lblNameValue;
        private Label lblDepartment;
        private TextBox txtDepartment;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblSalary;
        private TextBox txtSalary;

        private Button btnSave;
    }
}