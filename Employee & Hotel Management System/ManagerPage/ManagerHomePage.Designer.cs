using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.ManagerPage
{
    partial class ManagerHomePage
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
            btnLogout = new Button();
            labelTitle = new Label();
            panelMain = new Panel();
            panelWelcome = new Panel();
            labelWelcome = new Label();
            panelUserInfo = new Panel();
            lblName = new Label();
            lblNameValue = new Label();
            lblEmail = new Label();
            lblEmailValue = new Label();
            lblSalary = new Label();
            lblSalaryValue = new Label();
            lblPhone = new Label();
            lblPhoneValue = new Label();
            lblID = new Label();
            lblIDValue = new Label();
            lblDepartment = new Label();
            lblDepartmentValue = new Label();
            panelButtons = new Panel();
            btnEditData = new Button();
            btnShowEmployee = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelWelcome.SuspendLayout();
            panelUserInfo.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(btnLogout);
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
            btnClose.TabIndex = 3;
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
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1020, 24);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(103, 47);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(34, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(345, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Manager Dashboard";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(panelWelcome);
            panelMain.Controls.Add(panelUserInfo);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(57, 67, 57, 67);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // panelWelcome
            // 
            panelWelcome.BackColor = Color.White;
            panelWelcome.Controls.Add(labelWelcome);
            panelWelcome.Location = new Point(57, 67);
            panelWelcome.Margin = new Padding(3, 4, 3, 4);
            panelWelcome.Name = "panelWelcome";
            panelWelcome.Size = new Size(1257, 107);
            panelWelcome.TabIndex = 0;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelWelcome.ForeColor = Color.FromArgb(44, 62, 80);
            labelWelcome.Location = new Point(34, 27);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(289, 41);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Manager";
            // 
            // panelUserInfo
            // 
            panelUserInfo.BackColor = Color.White;
            panelUserInfo.Controls.Add(lblName);
            panelUserInfo.Controls.Add(lblNameValue);
            panelUserInfo.Controls.Add(lblEmail);
            panelUserInfo.Controls.Add(lblEmailValue);
            panelUserInfo.Controls.Add(lblSalary);
            panelUserInfo.Controls.Add(lblSalaryValue);
            panelUserInfo.Controls.Add(lblPhone);
            panelUserInfo.Controls.Add(lblPhoneValue);
            panelUserInfo.Controls.Add(lblID);
            panelUserInfo.Controls.Add(lblIDValue);
            panelUserInfo.Controls.Add(lblDepartment);
            panelUserInfo.Controls.Add(lblDepartmentValue);
            panelUserInfo.Location = new Point(57, 200);
            panelUserInfo.Margin = new Padding(3, 4, 3, 4);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(1257, 267);
            panelUserInfo.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(145, 41);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 28);
            lblName.TabIndex = 12;
            lblName.Text = "Name:";
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 12F);
            lblNameValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblNameValue.Location = new Point(292, 41);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(59, 28);
            lblNameValue.TabIndex = 13;
            lblNameValue.Text = "Value";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(44, 62, 80);
            lblEmail.Location = new Point(145, 94);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 28);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email:";
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Font = new Font("Segoe UI", 12F);
            lblEmailValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblEmailValue.Location = new Point(292, 94);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(59, 28);
            lblEmailValue.TabIndex = 15;
            lblEmailValue.Text = "Value";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSalary.ForeColor = Color.FromArgb(44, 62, 80);
            lblSalary.Location = new Point(145, 155);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(76, 28);
            lblSalary.TabIndex = 16;
            lblSalary.Text = "Salary:";
            // 
            // lblSalaryValue
            // 
            lblSalaryValue.AutoSize = true;
            lblSalaryValue.Font = new Font("Segoe UI", 12F);
            lblSalaryValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblSalaryValue.Location = new Point(292, 155);
            lblSalaryValue.Name = "lblSalaryValue";
            lblSalaryValue.Size = new Size(59, 28);
            lblSalaryValue.TabIndex = 17;
            lblSalaryValue.Text = "Value";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhone.Location = new Point(616, 155);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 28);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone:";
            // 
            // lblPhoneValue
            // 
            lblPhoneValue.AutoSize = true;
            lblPhoneValue.Font = new Font("Segoe UI", 12F);
            lblPhoneValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblPhoneValue.Location = new Point(837, 155);
            lblPhoneValue.Name = "lblPhoneValue";
            lblPhoneValue.Size = new Size(59, 28);
            lblPhoneValue.TabIndex = 5;
            lblPhoneValue.Text = "Value";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblID.ForeColor = Color.FromArgb(44, 62, 80);
            lblID.Location = new Point(634, 41);
            lblID.Name = "lblID";
            lblID.Size = new Size(38, 28);
            lblID.TabIndex = 8;
            lblID.Text = "ID:";
            // 
            // lblIDValue
            // 
            lblIDValue.AutoSize = true;
            lblIDValue.Font = new Font("Segoe UI", 12F);
            lblIDValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblIDValue.Location = new Point(837, 41);
            lblIDValue.Name = "lblIDValue";
            lblIDValue.Size = new Size(59, 28);
            lblIDValue.TabIndex = 9;
            lblIDValue.Text = "Value";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(44, 62, 80);
            lblDepartment.Location = new Point(586, 94);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(132, 28);
            lblDepartment.TabIndex = 10;
            lblDepartment.Text = "Department:";
            // 
            // lblDepartmentValue
            // 
            lblDepartmentValue.AutoSize = true;
            lblDepartmentValue.Font = new Font("Segoe UI", 12F);
            lblDepartmentValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblDepartmentValue.Location = new Point(837, 94);
            lblDepartmentValue.Name = "lblDepartmentValue";
            lblDepartmentValue.Size = new Size(59, 28);
            lblDepartmentValue.TabIndex = 11;
            lblDepartmentValue.Text = "Value";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnEditData);
            panelButtons.Controls.Add(btnShowEmployee);
            panelButtons.Location = new Point(57, 507);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1257, 333);
            panelButtons.TabIndex = 2;
            // 
            // btnEditData
            // 
            btnEditData.BackColor = Color.FromArgb(241, 196, 15);
            btnEditData.Cursor = Cursors.Hand;
            btnEditData.FlatAppearance.BorderSize = 0;
            btnEditData.FlatStyle = FlatStyle.Flat;
            btnEditData.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnEditData.ForeColor = Color.White;
            btnEditData.Location = new Point(400, 67);
            btnEditData.Margin = new Padding(3, 4, 3, 4);
            btnEditData.Name = "btnEditData";
            btnEditData.Size = new Size(457, 93);
            btnEditData.TabIndex = 0;
            btnEditData.Text = "✏️  Edit Data";
            btnEditData.UseVisualStyleBackColor = false;
            // 
            // btnShowEmployee
            // 
            btnShowEmployee.BackColor = Color.FromArgb(52, 152, 219);
            btnShowEmployee.Cursor = Cursors.Hand;
            btnShowEmployee.FlatAppearance.BorderSize = 0;
            btnShowEmployee.FlatStyle = FlatStyle.Flat;
            btnShowEmployee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnShowEmployee.ForeColor = Color.White;
            btnShowEmployee.Location = new Point(400, 187);
            btnShowEmployee.Margin = new Padding(3, 4, 3, 4);
            btnShowEmployee.Name = "btnShowEmployee";
            btnShowEmployee.Size = new Size(457, 93);
            btnShowEmployee.TabIndex = 1;
            btnShowEmployee.Text = "👥  Show Employees";
            btnShowEmployee.UseVisualStyleBackColor = false;
            // 
            // ManagerHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ManagerHomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manager Dashboard";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Button btnLogout;
        private Label labelTitle;

        private Panel panelMain;
        private Panel panelWelcome;
        private Label labelWelcome;

        private Panel panelUserInfo;
        private Label lblPhone;
        private Label lblPhoneValue;
        private Label lblID;
        private Label lblIDValue;
        private Label lblDepartment;
        private Label lblDepartmentValue;

        private Panel panelButtons;
        private Button btnEditData;
        private Button btnShowEmployee;
        private Label lblName;
        private Label lblNameValue;
        private Label lblEmail;
        private Label lblEmailValue;
        private Label lblSalary;
        private Label lblSalaryValue;
    }
}