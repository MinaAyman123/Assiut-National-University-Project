using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.WorkerPage
{
    partial class Booking
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
            groupBoxBooking = new GroupBox();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            btnShowRooms = new Button();
            lblRoom = new Label();
            cmbRoom = new ComboBox();
            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();
            btnAddBooking = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxBooking.SuspendLayout();
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
            labelTitle.Size = new Size(236, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "New Booking";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(groupBoxBooking);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(57, 67, 57, 67);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // groupBoxBooking
            // 
            groupBoxBooking.BackColor = Color.White;
            groupBoxBooking.Controls.Add(lblName);
            groupBoxBooking.Controls.Add(txtName);
            groupBoxBooking.Controls.Add(lblPhone);
            groupBoxBooking.Controls.Add(txtPhone);
            groupBoxBooking.Controls.Add(lblEmail);
            groupBoxBooking.Controls.Add(txtEmail);
            groupBoxBooking.Controls.Add(lblAddress);
            groupBoxBooking.Controls.Add(txtAddress);
            groupBoxBooking.Controls.Add(lblBirthDate);
            groupBoxBooking.Controls.Add(dtpBirthDate);
            groupBoxBooking.Controls.Add(lblRoomType);
            groupBoxBooking.Controls.Add(cmbRoomType);
            groupBoxBooking.Controls.Add(btnShowRooms);
            groupBoxBooking.Controls.Add(lblRoom);
            groupBoxBooking.Controls.Add(cmbRoom);
            groupBoxBooking.Controls.Add(lblCheckIn);
            groupBoxBooking.Controls.Add(dtpCheckIn);
            groupBoxBooking.Controls.Add(lblCheckOut);
            groupBoxBooking.Controls.Add(dtpCheckOut);
            groupBoxBooking.Controls.Add(btnAddBooking);
            groupBoxBooking.Dock = DockStyle.Fill;
            groupBoxBooking.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBoxBooking.ForeColor = Color.FromArgb(44, 62, 80);
            groupBoxBooking.Location = new Point(57, 67);
            groupBoxBooking.Margin = new Padding(3, 4, 3, 4);
            groupBoxBooking.Name = "groupBoxBooking";
            groupBoxBooking.Padding = new Padding(46, 53, 46, 53);
            groupBoxBooking.Size = new Size(1257, 773);
            groupBoxBooking.TabIndex = 0;
            groupBoxBooking.TabStop = false;
            groupBoxBooking.Text = "Booking Information";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblName.Location = new Point(57, 80);
            lblName.Name = "lblName";
            lblName.Size = new Size(80, 30);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(245, 247, 250);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 13F);
            txtName.Location = new Point(206, 77);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(457, 36);
            txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPhone.Location = new Point(709, 80);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(84, 30);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(245, 247, 250);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 13F);
            txtPhone.Location = new Point(800, 77);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(400, 36);
            txtPhone.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEmail.Location = new Point(57, 147);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(75, 30);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 13F);
            txtEmail.Location = new Point(206, 144);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(457, 36);
            txtEmail.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAddress.Location = new Point(697, 147);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(103, 30);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(245, 247, 250);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 13F);
            txtAddress.Location = new Point(800, 144);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(400, 36);
            txtAddress.TabIndex = 7;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBirthDate.Location = new Point(57, 213);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(126, 30);
            lblBirthDate.TabIndex = 8;
            lblBirthDate.Text = "Birth Date:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CalendarFont = new Font("Segoe UI", 12F);
            dtpBirthDate.Font = new Font("Segoe UI", 13F);
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(206, 211);
            dtpBirthDate.Margin = new Padding(3, 4, 3, 4);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(457, 36);
            dtpBirthDate.TabIndex = 9;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRoomType.Location = new Point(57, 293);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(134, 30);
            lblRoomType.TabIndex = 10;
            lblRoomType.Text = "Room Type:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.BackColor = Color.FromArgb(245, 247, 250);
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.FlatStyle = FlatStyle.Flat;
            cmbRoomType.Font = new Font("Segoe UI", 13F);
            cmbRoomType.Items.AddRange(new object[] { "Single", "Double", "Suite" });
            cmbRoomType.Location = new Point(206, 291);
            cmbRoomType.Margin = new Padding(3, 4, 3, 4);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(228, 38);
            cmbRoomType.TabIndex = 11;
            // 
            // btnShowRooms
            // 
            btnShowRooms.BackColor = Color.FromArgb(52, 152, 219);
            btnShowRooms.Cursor = Cursors.Hand;
            btnShowRooms.FlatAppearance.BorderSize = 0;
            btnShowRooms.FlatStyle = FlatStyle.Flat;
            btnShowRooms.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnShowRooms.ForeColor = Color.White;
            btnShowRooms.Location = new Point(469, 287);
            btnShowRooms.Margin = new Padding(3, 4, 3, 4);
            btnShowRooms.Name = "btnShowRooms";
            btnShowRooms.Size = new Size(194, 53);
            btnShowRooms.TabIndex = 12;
            btnShowRooms.Text = "Show Rooms";
            btnShowRooms.UseVisualStyleBackColor = false;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRoom.Location = new Point(57, 367);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(78, 30);
            lblRoom.TabIndex = 13;
            lblRoom.Text = "Room:";
            // 
            // cmbRoom
            // 
            cmbRoom.BackColor = Color.FromArgb(245, 247, 250);
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.FlatStyle = FlatStyle.Flat;
            cmbRoom.Font = new Font("Segoe UI", 13F);
            cmbRoom.Location = new Point(206, 364);
            cmbRoom.Margin = new Padding(3, 4, 3, 4);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(457, 38);
            cmbRoom.TabIndex = 14;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCheckIn.Location = new Point(686, 250);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(107, 30);
            lblCheckIn.TabIndex = 15;
            lblCheckIn.Text = "Check In:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CalendarFont = new Font("Segoe UI", 12F);
            dtpCheckIn.Font = new Font("Segoe UI", 13F);
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(823, 245);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(377, 36);
            dtpCheckIn.TabIndex = 16;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCheckOut.Location = new Point(674, 325);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(126, 30);
            lblCheckOut.TabIndex = 17;
            lblCheckOut.Text = "Check Out:";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.CalendarFont = new Font("Segoe UI", 12F);
            dtpCheckOut.Font = new Font("Segoe UI", 13F);
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(823, 325);
            dtpCheckOut.Margin = new Padding(3, 4, 3, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(377, 36);
            dtpCheckOut.TabIndex = 18;
            // 
            // btnAddBooking
            // 
            btnAddBooking.BackColor = Color.FromArgb(46, 204, 113);
            btnAddBooking.Cursor = Cursors.Hand;
            btnAddBooking.FlatAppearance.BorderSize = 0;
            btnAddBooking.FlatStyle = FlatStyle.Flat;
            btnAddBooking.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAddBooking.ForeColor = Color.White;
            btnAddBooking.Location = new Point(400, 627);
            btnAddBooking.Margin = new Padding(3, 4, 3, 4);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(457, 80);
            btnAddBooking.TabIndex = 19;
            btnAddBooking.Text = "Add Booking";
            btnAddBooking.UseVisualStyleBackColor = false;
            // 
            // Booking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Booking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Booking";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxBooking.ResumeLayout(false);
            groupBoxBooking.PerformLayout();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        private Panel panelMain;
        private GroupBox groupBoxBooking;

        // Customer Information
        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;

        // Room Information
        private Label lblRoomType;
        private ComboBox cmbRoomType;
        private Button btnShowRooms;
        private Label lblRoom;
        private ComboBox cmbRoom;

        // Date Section
        private Label lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private Label lblCheckOut;
        private DateTimePicker dtpCheckOut;

        // Button
        private Button btnAddBooking;
    }
}