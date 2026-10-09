using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.WorkerPage
{
    public partial class Booking : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);

        public Booking()
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
                    startPoint = new System.Drawing.Point(e.X, e.Y);
                }
            };

            this.panelHeader.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    System.Drawing.Point p = PointToScreen(e.Location);
                    this.Location = new System.Drawing.Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };

            this.panelHeader.MouseUp += (s, e) => isDragging = false;

            // Window controls
            this.btnClose.Click += (s, e) => this.Close();
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Button events
            this.btnShowRooms.Click += BtnShowRooms_Click;
            this.btnAddBooking.Click += BtnAddBooking_Click;

            // Hover effects
            this.btnShowRooms.MouseEnter += (s, e) => btnShowRooms.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnShowRooms.MouseLeave += (s, e) => btnShowRooms.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);

            this.btnAddBooking.MouseEnter += (s, e) => btnAddBooking.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAddBooking.MouseLeave += (s, e) => btnAddBooking.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);

            // Phone validation (only numbers)
            this.txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            // Set minimum date for check-in
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckOut.MinDate = DateTime.Today.AddDays(1);

            dtpCheckIn.ValueChanged += (s, e) =>
            {
                dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
                if (dtpCheckOut.Value <= dtpCheckIn.Value)
                {
                    dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
                }
            };
        }

        private void BtnShowRooms_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedType = cmbRoomType.Text;

                if (string.IsNullOrEmpty(selectedType))
                {
                    MessageBox.Show("Please select a room type first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filteredRooms = db.Rooms
                    .Where(r => r.Type == selectedType && r.Status == "Available")
                    .ToList();

                if (filteredRooms.Count == 0)
                {
                    MessageBox.Show($"No available rooms found for type: {selectedType}", "No Rooms",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmbRoom.Items.Clear();
                foreach (var room in filteredRooms)
                {
                    cmbRoom.Items.Add(room.RoomNumber);
                }

                if (cmbRoom.Items.Count > 0)
                {
                    cmbRoom.SelectedIndex = 0;
                    MessageBox.Show($"Found {filteredRooms.Count} available room(s).", "Rooms Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddBooking_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter customer name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please enter phone number.", "Validation Error",
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

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please enter email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Please enter address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (cmbRoom.SelectedItem == null)
                {
                    MessageBox.Show("Please select a room. Click 'Show Rooms' first.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create customer
                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                DateOnly birthDate = DateOnly.FromDateTime(dtpBirthDate.Value);

                Customer customer = new Customer
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Address = address,
                    DateOfBirth = birthDate
                };

                db.Customers.Add(customer);
                db.SaveChanges();

                // Get room
                string roomNumber = cmbRoom.SelectedItem.ToString();
                var room = db.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                if (room == null)
                {
                    MessageBox.Show("Selected room not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get customer ID
                var savedCustomer = db.Customers.FirstOrDefault(c => c.Name == name && c.Phone == phone);
                if (savedCustomer == null)
                {
                    MessageBox.Show("Error retrieving customer data.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create reservation
                DateOnly checkIn = DateOnly.FromDateTime(dtpCheckIn.Value);
                DateOnly checkOut = DateOnly.FromDateTime(dtpCheckOut.Value);

                if (checkOut <= checkIn)
                {
                    MessageBox.Show("Check-out date must be after check-in date.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Reservation reservation = new Reservation
                {
                    CustomerId = savedCustomer.CustomerId,
                    RoomId = room.RoomId,
                    CheckInDate = checkIn,
                    CheckOutDate = checkOut
                };

                db.Reservations.Add(reservation);

                // Update room status
                room.Status = "Booked";

                db.SaveChanges();

                MessageBox.Show($"Booking created successfully!\n\nCustomer: {name}\nRoom: {roomNumber}\nCheck-in: {checkIn}\nCheck-out: {checkOut}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbRoomType.SelectedIndex = -1;
            cmbRoom.Items.Clear();
            cmbRoom.Text = "";
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            dtpBirthDate.Value = DateTime.Today.AddYears(-20);
            txtName.Focus();
        }
    }
}