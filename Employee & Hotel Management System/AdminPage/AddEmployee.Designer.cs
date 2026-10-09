using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.AdminPage
{
    partial class AddEmployee
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
            components = new System.ComponentModel.Container();
            panelHeader = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            labelTitle = new Label();
            panelMain = new Panel();
            groupBoxEmployeeInfo = new GroupBox();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            lblSalary = new Label();
            txtSalary = new TextBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnAdd = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
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
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1320, 24);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 47);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(52, 73, 94);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1274, 24);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 47);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(23, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(294, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Add New Employee";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(groupBoxEmployeeInfo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(57, 67, 57, 67);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // groupBoxEmployeeInfo
            // 
            groupBoxEmployeeInfo.BackColor = Color.White;
            groupBoxEmployeeInfo.Controls.Add(lblName);
            groupBoxEmployeeInfo.Controls.Add(txtName);
            groupBoxEmployeeInfo.Controls.Add(lblPhone);
            groupBoxEmployeeInfo.Controls.Add(txtPhone);
            groupBoxEmployeeInfo.Controls.Add(lblEmail);
            groupBoxEmployeeInfo.Controls.Add(txtEmail);
            groupBoxEmployeeInfo.Controls.Add(lblRole);
            groupBoxEmployeeInfo.Controls.Add(txtRole);
            groupBoxEmployeeInfo.Controls.Add(lblSalary);
            groupBoxEmployeeInfo.Controls.Add(txtSalary);
            groupBoxEmployeeInfo.Controls.Add(lblDepartment);
            groupBoxEmployeeInfo.Controls.Add(cmbDepartment);
            groupBoxEmployeeInfo.Controls.Add(lblPassword);
            groupBoxEmployeeInfo.Controls.Add(txtPassword);
            groupBoxEmployeeInfo.Controls.Add(btnAdd);
            groupBoxEmployeeInfo.Controls.Add(btnClear);
            groupBoxEmployeeInfo.Controls.Add(btnCancel);
            groupBoxEmployeeInfo.Dock = DockStyle.Fill;
            groupBoxEmployeeInfo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            groupBoxEmployeeInfo.ForeColor = Color.FromArgb(44, 62, 80);
            groupBoxEmployeeInfo.Location = new Point(57, 67);
            groupBoxEmployeeInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxEmployeeInfo.Name = "groupBoxEmployeeInfo";
            groupBoxEmployeeInfo.Padding = new Padding(57, 67, 57, 67);
            groupBoxEmployeeInfo.Size = new Size(1257, 773);
            groupBoxEmployeeInfo.TabIndex = 0;
            groupBoxEmployeeInfo.TabStop = false;
            groupBoxEmployeeInfo.Text = "Employee Information";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(42, 80);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(245, 247, 250);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(174, 77);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Enter full name";
            txtName.Size = new Size(320, 34);
            txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhone.Location = new Point(42, 173);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 28);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(245, 247, 250);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(174, 170);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Enter phone number";
            txtPhone.Size = new Size(320, 34);
            txtPhone.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(44, 62, 80);
            lblEmail.Location = new Point(42, 272);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 28);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(174, 270);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter email address";
            txtEmail.Size = new Size(320, 34);
            txtEmail.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(44, 62, 80);
            lblRole.Location = new Point(352, 406);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 28);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role:";
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.FromArgb(245, 247, 250);
            txtRole.BorderStyle = BorderStyle.FixedSingle;
            txtRole.Font = new Font("Segoe UI", 12F);
            txtRole.Location = new Point(484, 403);
            txtRole.Margin = new Padding(3, 4, 3, 4);
            txtRole.Name = "txtRole";
            txtRole.PlaceholderText = "Enter role (Admin/Manager/Worker)";
            txtRole.Size = new Size(320, 34);
            txtRole.TabIndex = 7;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSalary.ForeColor = Color.FromArgb(44, 62, 80);
            lblSalary.Location = new Point(661, 275);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(76, 28);
            lblSalary.TabIndex = 8;
            lblSalary.Text = "Salary:";
            // 
            // txtSalary
            // 
            txtSalary.BackColor = Color.FromArgb(245, 247, 250);
            txtSalary.BorderStyle = BorderStyle.FixedSingle;
            txtSalary.Font = new Font("Segoe UI", 12F);
            txtSalary.Location = new Point(828, 272);
            txtSalary.Margin = new Padding(3, 4, 3, 4);
            txtSalary.Name = "txtSalary";
            txtSalary.PlaceholderText = "Enter salary";
            txtSalary.Size = new Size(285, 34);
            txtSalary.TabIndex = 9;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(44, 62, 80);
            lblDepartment.Location = new Point(658, 83);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(132, 28);
            lblDepartment.TabIndex = 10;
            lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            cmbDepartment.BackColor = Color.FromArgb(245, 247, 250);
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FlatStyle = FlatStyle.Flat;
            cmbDepartment.Font = new Font("Segoe UI", 12F);
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(828, 83);
            cmbDepartment.Margin = new Padding(3, 4, 3, 4);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(285, 36);
            cmbDepartment.TabIndex = 11;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(44, 62, 80);
            lblPassword.Location = new Point(658, 176);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(106, 28);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(245, 247, 250);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(828, 174);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.Size = new Size(285, 34);
            txtPassword.TabIndex = 13;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(629, 600);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(229, 73);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add Employee";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(241, 196, 15);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(389, 600);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(206, 73);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(149, 600);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(206, 73);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Employee";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxEmployeeInfo.ResumeLayout(false);
            groupBoxEmployeeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        // Header controls
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        // Main controls
        private Panel panelMain;
        private GroupBox groupBoxEmployeeInfo;

        // Labels
        private Label lblName;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblRole;
        private Label lblSalary;
        private Label lblDepartment;
        private Label lblPassword;

        // TextBoxes
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtRole;
        private TextBox txtSalary;
        private TextBox txtPassword;

        // ComboBox
        private ComboBox cmbDepartment;

        // Buttons
        private Button btnAdd;
        private Button btnClear;
        private Button btnCancel;

        // Error Provider
        private ErrorProvider errorProvider;
    }
}