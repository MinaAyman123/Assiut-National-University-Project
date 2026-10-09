using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.AdminPage
{
    partial class EditData
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
            panelContent = new Panel();
            groupBoxEditData = new GroupBox();
            lblSelectEmployee = new Label();
            cmbEmployee = new ComboBox();
            btnShowData = new Button();
            lblName = new Label();
            lblNameValue = new Label();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            btnSave = new Button();
            errorProvider = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            groupBoxEditData.SuspendLayout();
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
            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1320, 27);
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
            btnMinimize.Location = new Point(1269, 27);
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
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(236, 240, 243);
            panelContent.Controls.Add(groupBoxEditData);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 93);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(57, 67, 57, 67);
            panelContent.Size = new Size(1371, 907);
            panelContent.TabIndex = 1;
            // 
            // groupBoxEditData
            // 
            groupBoxEditData.BackColor = Color.White;
            groupBoxEditData.Controls.Add(lblSelectEmployee);
            groupBoxEditData.Controls.Add(cmbEmployee);
            groupBoxEditData.Controls.Add(btnShowData);
            groupBoxEditData.Controls.Add(lblName);
            groupBoxEditData.Controls.Add(lblNameValue);
            groupBoxEditData.Controls.Add(lblPhone);
            groupBoxEditData.Controls.Add(txtPhone);
            groupBoxEditData.Controls.Add(lblEmail);
            groupBoxEditData.Controls.Add(txtEmail);
            groupBoxEditData.Controls.Add(lblRole);
            groupBoxEditData.Controls.Add(txtRole);
            groupBoxEditData.Controls.Add(btnSave);
            groupBoxEditData.Dock = DockStyle.Fill;
            groupBoxEditData.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBoxEditData.ForeColor = Color.FromArgb(44, 62, 80);
            groupBoxEditData.Location = new Point(57, 67);
            groupBoxEditData.Margin = new Padding(3, 4, 3, 4);
            groupBoxEditData.Name = "groupBoxEditData";
            groupBoxEditData.Padding = new Padding(46, 53, 46, 53);
            groupBoxEditData.Size = new Size(1257, 773);
            groupBoxEditData.TabIndex = 0;
            groupBoxEditData.TabStop = false;
            groupBoxEditData.Text = "Edit Employee Data";
            // 
            // lblSelectEmployee
            // 
            lblSelectEmployee.AutoSize = true;
            lblSelectEmployee.Font = new Font("Segoe UI", 12F);
            lblSelectEmployee.Location = new Point(69, 93);
            lblSelectEmployee.Name = "lblSelectEmployee";
            lblSelectEmployee.Size = new Size(159, 28);
            lblSelectEmployee.TabIndex = 0;
            lblSelectEmployee.Text = "Select Employee:";
            // 
            // cmbEmployee
            // 
            cmbEmployee.BackColor = Color.FromArgb(245, 247, 250);
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FlatStyle = FlatStyle.Flat;
            cmbEmployee.Font = new Font("Segoe UI", 12F);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(69, 133);
            cmbEmployee.Margin = new Padding(3, 4, 3, 4);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(399, 36);
            cmbEmployee.TabIndex = 1;
            // 
            // btnShowData
            // 
            btnShowData.BackColor = Color.FromArgb(52, 152, 219);
            btnShowData.Cursor = Cursors.Hand;
            btnShowData.FlatAppearance.BorderSize = 0;
            btnShowData.FlatStyle = FlatStyle.Flat;
            btnShowData.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnShowData.ForeColor = Color.White;
            btnShowData.Location = new Point(514, 120);
            btnShowData.Margin = new Padding(3, 4, 3, 4);
            btnShowData.Name = "btnShowData";
            btnShowData.Size = new Size(229, 60);
            btnShowData.TabIndex = 2;
            btnShowData.Text = "Show Employee Data";
            btnShowData.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Location = new Point(857, 240);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 28);
            lblName.TabIndex = 3;
            lblName.Text = "Name:";
            lblName.Visible = false;
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 12F);
            lblNameValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblNameValue.Location = new Point(514, 240);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(59, 28);
            lblNameValue.TabIndex = 4;
            lblNameValue.Text = "Value";
            lblNameValue.Visible = false;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.Location = new Point(857, 333);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 28);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Phone:";
            lblPhone.Visible = false;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(245, 247, 250);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(514, 331);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(320, 34);
            txtPhone.TabIndex = 6;
            txtPhone.Visible = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.Location = new Point(857, 427);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 28);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            lblEmail.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(514, 424);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 34);
            txtEmail.TabIndex = 8;
            txtEmail.Visible = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRole.Location = new Point(857, 520);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 28);
            lblRole.TabIndex = 9;
            lblRole.Text = "Role:";
            lblRole.Visible = false;
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.FromArgb(245, 247, 250);
            txtRole.BorderStyle = BorderStyle.FixedSingle;
            txtRole.Font = new Font("Segoe UI", 12F);
            txtRole.Location = new Point(514, 517);
            txtRole.Margin = new Padding(3, 4, 3, 4);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(320, 34);
            txtRole.TabIndex = 10;
            txtRole.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(457, 640);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(343, 73);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Employee Data";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            groupBoxEditData.ResumeLayout(false);
            groupBoxEditData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        private Panel panelContent;
        private GroupBox groupBoxEditData;

        private Label lblSelectEmployee;
        private ComboBox cmbEmployee;
        private Button btnShowData;

        private Label lblName;
        private Label lblNameValue;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private TextBox txtRole;

        private Button btnSave;
        private ErrorProvider errorProvider;
    }
}