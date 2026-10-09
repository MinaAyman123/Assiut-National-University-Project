using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.WorkerPage
{
    public partial class DeleteBook : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public DeleteBook()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Make form fullscreen
            this.WindowState = FormWindowState.Maximized;

            // Drag functionality for header
            this.panelHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    startPoint = new Point(e.X, e.Y);
                }
            };

            this.panelHeader.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };

            this.panelHeader.MouseUp += (s, e) => isDragging = false;

            // Window controls
            this.btnClose.Click += (s, e) => this.Close();
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Button event
            this.btnDelete.Click += BtnDelete_Click;

            // Hover effect for delete button
            this.btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = Color.FromArgb(192, 57, 43);
            this.btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = Color.FromArgb(231, 76, 60);

            // Phone validation (only numbers)
            this.txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Room number validation (only numbers)
            this.txtRoomNumber.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Set minimum date for check-in
            dtpCheckIn.MaxDate = DateTime.Today;
            dtpCheckIn.MinDate = new DateTime(2020, 1, 1);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please enter customer phone number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (txtPhone.Text.Length < 10)
                {
                    MessageBox.Show("Please enter a valid phone number (at least 10 digits).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
                {
                    MessageBox.Show("Please enter room number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRoomNumber.Focus();
                    return;
                }

                string phone = txtPhone.Text.Trim();
                string roomNumber = txtRoomNumber.Text.Trim();
                DateOnly checkIn = DateOnly.FromDateTime(dtpCheckIn.Value);

                // Find customer
                var customer = db.Customers.FirstOrDefault(x => x.Phone == phone);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found with this phone number.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Find room
                var room = db.Rooms.FirstOrDefault(x => x.RoomNumber == roomNumber);
                if (room == null)
                {
                    MessageBox.Show("Room number not found.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Find reservation
                var reservation = db.Reservations.FirstOrDefault(x =>
                    x.RoomId == room.RoomId &&
                    x.CustomerId == customer.CustomerId &&
                    x.CheckInDate == checkIn);

                if (reservation == null)
                {
                    MessageBox.Show("No reservation found matching the provided information.\n\nPlease check:\n- Customer phone number\n- Room number\n- Check-in date",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this reservation?\n\n" +
                    $"Customer: {customer.Name}\n" +
                    $"Phone: {customer.Phone}\n" +
                    $"Room: {room.RoomNumber}\n" +
                    $"Check-in: {checkIn}\n\n" +
                    "This action cannot be undone!",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Delete reservation
                    db.Reservations.Remove(reservation);

                    // Update room status to Available
                    room.Status = "Available";

                    db.SaveChanges();

                    MessageBox.Show($"Reservation deleted successfully!\n\n" +
                        $"Customer: {customer.Name}\n" +
                        $"Room: {room.RoomNumber}\n" +
                        $"Room status is now: Available",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Clear form
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtPhone.Clear();
            txtRoomNumber.Clear();
            dtpCheckIn.Value = DateTime.Today;
            txtPhone.Focus();
        }
    }
}