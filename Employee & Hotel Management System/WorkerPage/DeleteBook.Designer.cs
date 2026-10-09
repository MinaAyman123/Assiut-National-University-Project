using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.WorkerPage
{
    partial class DeleteBook
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
            groupBoxDeleteBooking = new GroupBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblRoomNumber = new Label();
            txtRoomNumber = new TextBox();
            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();
            btnDelete = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxDeleteBooking.SuspendLayout();
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
            labelTitle.Size = new Size(266, 46);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Delete Booking";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 243);
            panelMain.Controls.Add(groupBoxDeleteBooking);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(57, 67, 57, 67);
            panelMain.Size = new Size(1371, 907);
            panelMain.TabIndex = 1;
            // 
            // groupBoxDeleteBooking
            // 
            groupBoxDeleteBooking.BackColor = Color.White;
            groupBoxDeleteBooking.Controls.Add(lblPhone);
            groupBoxDeleteBooking.Controls.Add(txtPhone);
            groupBoxDeleteBooking.Controls.Add(lblRoomNumber);
            groupBoxDeleteBooking.Controls.Add(txtRoomNumber);
            groupBoxDeleteBooking.Controls.Add(lblCheckIn);
            groupBoxDeleteBooking.Controls.Add(dtpCheckIn);
            groupBoxDeleteBooking.Controls.Add(btnDelete);
            groupBoxDeleteBooking.Dock = DockStyle.Fill;
            groupBoxDeleteBooking.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBoxDeleteBooking.ForeColor = Color.FromArgb(44, 62, 80);
            groupBoxDeleteBooking.Location = new Point(57, 67);
            groupBoxDeleteBooking.Margin = new Padding(3, 4, 3, 4);
            groupBoxDeleteBooking.Name = "groupBoxDeleteBooking";
            groupBoxDeleteBooking.Padding = new Padding(46, 53, 46, 53);
            groupBoxDeleteBooking.Size = new Size(1257, 773);
            groupBoxDeleteBooking.TabIndex = 0;
            groupBoxDeleteBooking.TabStop = false;
            groupBoxDeleteBooking.Text = "Delete Booking Information";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPhone.Location = new Point(286, 133);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(84, 30);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(245, 247, 250);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 13F);
            txtPhone.Location = new Point(400, 131);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Enter customer phone number";
            txtPhone.Size = new Size(571, 36);
            txtPhone.TabIndex = 1;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRoomNumber.Location = new Point(217, 227);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(170, 30);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Room Number:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.BackColor = Color.FromArgb(245, 247, 250);
            txtRoomNumber.BorderStyle = BorderStyle.FixedSingle;
            txtRoomNumber.Font = new Font("Segoe UI", 13F);
            txtRoomNumber.Location = new Point(400, 224);
            txtRoomNumber.Margin = new Padding(3, 4, 3, 4);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "Enter room number";
            txtRoomNumber.Size = new Size(571, 36);
            txtRoomNumber.TabIndex = 3;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCheckIn.Location = new Point(225, 317);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(162, 30);
            lblCheckIn.TabIndex = 4;
            lblCheckIn.Text = "Check In Date:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CalendarFont = new Font("Segoe UI", 12F);
            dtpCheckIn.Font = new Font("Segoe UI", 13F);
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(400, 317);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(571, 36);
            dtpCheckIn.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(400, 440);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(571, 80);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete Reservation";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // DeleteBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DeleteBook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delete Booking";
            WindowState = FormWindowState.Maximized;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxDeleteBooking.ResumeLayout(false);
            groupBoxDeleteBooking.PerformLayout();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelHeader;
        private Button btnClose;
        private Button btnMinimize;
        private Label labelTitle;

        private Panel panelMain;
        private GroupBox groupBoxDeleteBooking;

        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblRoomNumber;
        private TextBox txtRoomNumber;
        private Label lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private Button btnDelete;
    }
}