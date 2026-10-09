
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.AdminPage
{
    partial class AdminHomePage
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
            labelWelcomeTitle = new Label();
            panelSide = new Panel();
            pictureBoxLogo = new PictureBox();
            panelMain = new Panel();
            panelWelcome = new Panel();
            panelUserInfo = new Panel();
            lblName = new Label();
            lblNameValue = new Label();
            lblEmail = new Label();
            lblEmailValue = new Label();
            lblPhone = new Label();
            lblPhoneValue = new Label();
            panelButtons = new Panel();
            btnAddEmployee = new Button();
            btnShowReservation = new Button();
            btnEditData = new Button();
            panelHeader.SuspendLayout();
            panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
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
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1875, 27);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(52, 73, 94);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1818, 27);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1076, 21);
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
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(39, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(273, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Admin Dashboard";
            // 
            // labelWelcomeTitle
            // 
            labelWelcomeTitle.AutoSize = true;
            labelWelcomeTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelWelcomeTitle.ForeColor = Color.FromArgb(52, 73, 94);
            labelWelcomeTitle.Location = new Point(61, 29);
            labelWelcomeTitle.Name = "labelWelcomeTitle";
            labelWelcomeTitle.Size = new Size(228, 37);
            labelWelcomeTitle.TabIndex = 1;
            labelWelcomeTitle.Text = "Welcome Admin";
            // 
            // panelSide
            // 
            panelSide.BackColor = Color.FromArgb(52, 73, 94);
            panelSide.Controls.Add(pictureBoxLogo);
            panelSide.Dock = DockStyle.Left;
            panelSide.Location = new Point(0, 93);
            panelSide.Margin = new Padding(3, 4, 3, 4);
            panelSide.Name = "panelSide";
            panelSide.Size = new Size(909, 907);
            panelSide.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Resources.swimming_pool_beach_luxury_hotel_type_entertainment_complex_amara_dolce_vita_luxury_hotel_resort_tekirova_kemer_turkey;
            pictureBoxLogo.Location = new Point(3, 0);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(909, 1005);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(panelWelcome);
            panelMain.Controls.Add(panelUserInfo);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(909, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(46, 53, 46, 53);
            panelMain.Size = new Size(462, 907);
            panelMain.TabIndex = 2;
            panelMain.Paint += panelMain_Paint;
            // 
            // panelWelcome
            // 
            panelWelcome.BackColor = Color.White;
            panelWelcome.Controls.Add(labelWelcomeTitle);
            panelWelcome.Location = new Point(152, 57);
            panelWelcome.Margin = new Padding(3, 4, 3, 4);
            panelWelcome.Name = "panelWelcome";
            panelWelcome.Size = new Size(800, 107);
            panelWelcome.TabIndex = 2;
            // 
            // panelUserInfo
            // 
            panelUserInfo.BackColor = Color.White;
            panelUserInfo.Controls.Add(lblName);
            panelUserInfo.Controls.Add(lblNameValue);
            panelUserInfo.Controls.Add(lblEmail);
            panelUserInfo.Controls.Add(lblEmailValue);
            panelUserInfo.Controls.Add(lblPhone);
            panelUserInfo.Controls.Add(lblPhoneValue);
            panelUserInfo.Location = new Point(152, 182);
            panelUserInfo.Margin = new Padding(3, 4, 3, 4);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(800, 200);
            panelUserInfo.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(179, 36);
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
            lblNameValue.Location = new Point(455, 36);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(59, 28);
            lblNameValue.TabIndex = 1;
            lblNameValue.Text = "Value";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(44, 62, 80);
            lblEmail.Location = new Point(179, 87);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 28);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Font = new Font("Segoe UI", 12F);
            lblEmailValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblEmailValue.Location = new Point(455, 87);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(59, 28);
            lblEmailValue.TabIndex = 3;
            lblEmailValue.Text = "Value";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhone.Location = new Point(179, 156);
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
            lblPhoneValue.Location = new Point(455, 156);
            lblPhoneValue.Name = "lblPhoneValue";
            lblPhoneValue.Size = new Size(59, 28);
            lblPhoneValue.TabIndex = 5;
            lblPhoneValue.Text = "Value";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnAddEmployee);
            panelButtons.Controls.Add(btnShowReservation);
            panelButtons.Controls.Add(btnEditData);
            panelButtons.Location = new Point(152, 419);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(800, 533);
            panelButtons.TabIndex = 1;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.BackColor = Color.FromArgb(52, 152, 219);
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAddEmployee.ForeColor = Color.White;
            btnAddEmployee.Location = new Point(251, 67);
            btnAddEmployee.Margin = new Padding(3, 4, 3, 4);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(457, 93);
            btnAddEmployee.TabIndex = 0;
            btnAddEmployee.Text = "  Add New Employee";
            btnAddEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnAddEmployee.UseVisualStyleBackColor = false;
            // 
            // btnShowReservation
            // 
            btnShowReservation.BackColor = Color.FromArgb(46, 204, 113);
            btnShowReservation.FlatAppearance.BorderSize = 0;
            btnShowReservation.FlatStyle = FlatStyle.Flat;
            btnShowReservation.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnShowReservation.ForeColor = Color.White;
            btnShowReservation.Location = new Point(251, 200);
            btnShowReservation.Margin = new Padding(3, 4, 3, 4);
            btnShowReservation.Name = "btnShowReservation";
            btnShowReservation.Size = new Size(457, 93);
            btnShowReservation.TabIndex = 1;
            btnShowReservation.Text = "  Show Reservations";
            btnShowReservation.TextAlign = ContentAlignment.MiddleLeft;
            btnShowReservation.UseVisualStyleBackColor = false;
            // 
            // btnEditData
            // 
            btnEditData.BackColor = Color.FromArgb(241, 196, 15);
            btnEditData.FlatAppearance.BorderSize = 0;
            btnEditData.FlatStyle = FlatStyle.Flat;
            btnEditData.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnEditData.ForeColor = Color.White;
            btnEditData.Location = new Point(251, 333);
            btnEditData.Margin = new Padding(3, 4, 3, 4);
            btnEditData.Name = "btnEditData";
            btnEditData.Size = new Size(457, 93);
            btnEditData.TabIndex = 2;
            btnEditData.Text = "  Edit Data";
            btnEditData.TextAlign = ContentAlignment.MiddleLeft;
            btnEditData.UseVisualStyleBackColor = false;
            // 
            // AdminHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelSide);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminHomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMain.ResumeLayout(false);
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Button btnLogout;
        private Label labelTitle;

        private Panel panelSide;
        private PictureBox pictureBoxLogo;
        private Label labelWelcomeTitle;

        private Panel panelMain;
        private Panel panelUserInfo;
        private Label lblName;
        private Label lblNameValue;
        private Label lblEmail;
        private Label lblEmailValue;
        private Label lblPhone;
        private Label lblPhoneValue;

        private Panel panelButtons;
        private Button btnAddEmployee;
        private Button btnShowReservation;
        private Button btnEditData;
        private Panel panelWelcome;
    }
}