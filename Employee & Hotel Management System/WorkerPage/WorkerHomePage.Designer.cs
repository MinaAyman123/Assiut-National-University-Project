using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.WorkerPage
{
    partial class WorkerHomePage
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
            lblPhone = new Label();
            lblPhoneValue = new Label();
            lblEmail = new Label();
            lblEmailValue = new Label();
            lblRole = new Label();
            lblRoleValue = new Label();
            panelButtons = new Panel();
            btnAddBooking = new Button();
            btnDeleteBooking = new Button();
            btnShowRoom = new Button();
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
            btnLogout.Location = new Point(1081, 24);
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
            labelTitle.Size = new Size(321, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Worker Dashboard";
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
            labelWelcome.Size = new Size(267, 41);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Worker";
            // 
            // panelUserInfo
            // 
            panelUserInfo.BackColor = Color.White;
            panelUserInfo.Controls.Add(lblName);
            panelUserInfo.Controls.Add(lblNameValue);
            panelUserInfo.Controls.Add(lblPhone);
            panelUserInfo.Controls.Add(lblPhoneValue);
            panelUserInfo.Controls.Add(lblEmail);
            panelUserInfo.Controls.Add(lblEmailValue);
            panelUserInfo.Controls.Add(lblRole);
            panelUserInfo.Controls.Add(lblRoleValue);
            panelUserInfo.Location = new Point(57, 200);
            panelUserInfo.Margin = new Padding(3, 4, 3, 4);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(1257, 213);
            panelUserInfo.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(743, 53);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 12F);
            lblNameValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblNameValue.Location = new Point(971, 53);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(59, 28);
            lblNameValue.TabIndex = 1;
            lblNameValue.Text = "Value";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhone.Location = new Point(740, 109);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 28);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone:";
            // 
            // lblPhoneValue
            // 
            lblPhoneValue.AutoSize = true;
            lblPhoneValue.Font = new Font("Segoe UI", 12F);
            lblPhoneValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblPhoneValue.Location = new Point(971, 109);
            lblPhoneValue.Name = "lblPhoneValue";
            lblPhoneValue.Size = new Size(59, 28);
            lblPhoneValue.TabIndex = 3;
            lblPhoneValue.Text = "Value";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(44, 62, 80);
            lblEmail.Location = new Point(114, 38);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 28);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Font = new Font("Segoe UI", 12F);
            lblEmailValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblEmailValue.Location = new Point(343, 38);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(59, 28);
            lblEmailValue.TabIndex = 5;
            lblEmailValue.Text = "Value";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(44, 62, 80);
            lblRole.Location = new Point(114, 107);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 28);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role:";
            // 
            // lblRoleValue
            // 
            lblRoleValue.AutoSize = true;
            lblRoleValue.Font = new Font("Segoe UI", 12F);
            lblRoleValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblRoleValue.Location = new Point(343, 107);
            lblRoleValue.Name = "lblRoleValue";
            lblRoleValue.Size = new Size(59, 28);
            lblRoleValue.TabIndex = 7;
            lblRoleValue.Text = "Value";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnAddBooking);
            panelButtons.Controls.Add(btnDeleteBooking);
            panelButtons.Controls.Add(btnShowRoom);
            panelButtons.Location = new Point(57, 453);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1257, 400);
            panelButtons.TabIndex = 2;
            // 
            // btnAddBooking
            // 
            btnAddBooking.BackColor = Color.FromArgb(52, 152, 219);
            btnAddBooking.Cursor = Cursors.Hand;
            btnAddBooking.FlatAppearance.BorderSize = 0;
            btnAddBooking.FlatStyle = FlatStyle.Flat;
            btnAddBooking.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAddBooking.ForeColor = Color.White;
            btnAddBooking.Location = new Point(286, 40);
            btnAddBooking.Margin = new Padding(3, 4, 3, 4);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(686, 93);
            btnAddBooking.TabIndex = 0;
            btnAddBooking.Text = "📅  Add Booking";
            btnAddBooking.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteBooking.Cursor = Cursors.Hand;
            btnDeleteBooking.FlatAppearance.BorderSize = 0;
            btnDeleteBooking.FlatStyle = FlatStyle.Flat;
            btnDeleteBooking.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDeleteBooking.ForeColor = Color.White;
            btnDeleteBooking.Location = new Point(286, 160);
            btnDeleteBooking.Margin = new Padding(3, 4, 3, 4);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new Size(686, 93);
            btnDeleteBooking.TabIndex = 1;
            btnDeleteBooking.Text = "🗑️  Delete Booking";
            btnDeleteBooking.UseVisualStyleBackColor = false;
            // 
            // btnShowRoom
            // 
            btnShowRoom.BackColor = Color.FromArgb(46, 204, 113);
            btnShowRoom.Cursor = Cursors.Hand;
            btnShowRoom.FlatAppearance.BorderSize = 0;
            btnShowRoom.FlatStyle = FlatStyle.Flat;
            btnShowRoom.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnShowRoom.ForeColor = Color.White;
            btnShowRoom.Location = new Point(286, 280);
            btnShowRoom.Margin = new Padding(3, 4, 3, 4);
            btnShowRoom.Name = "btnShowRoom";
            btnShowRoom.Size = new Size(686, 93);
            btnShowRoom.TabIndex = 2;
            btnShowRoom.Text = "🏠  Show Available Rooms";
            btnShowRoom.UseVisualStyleBackColor = false;
            // 
            // WorkerHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "WorkerHomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Worker Dashboard";
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
        private Label lblName;
        private Label lblNameValue;
        private Label lblPhone;
        private Label lblPhoneValue;
        private Label lblEmail;
        private Label lblEmailValue;
        private Label lblRole;
        private Label lblRoleValue;

        private Panel panelButtons;
        private Button btnAddBooking;
        private Button btnDeleteBooking;
        private Button btnShowRoom;
    }
}