using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.AdminPage
{
    public partial class ShowReservation : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public ShowReservation()
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

            this.Load += ShowReservation_Load;
        }

        private void ShowReservation_Load(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                var data = from r in db.Reservations
                           join c in db.Customers on r.CustomerId equals c.CustomerId
                           join room in db.Rooms on r.RoomId equals room.RoomId
                           select new
                           {
                               ReservationID = r.ReservationId,
                               CustomerName = c.Name,
                               Phone = c.Phone,
                               RoomNumber = room.RoomNumber,
                               RoomType = room.Type,
                               CheckIn = r.CheckInDate,
                               CheckOut = r.CheckOutDate
                           };

                dataGridView1.DataSource = data.ToList();

                // Format the DataGridView columns
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // Set column headers
                dataGridView1.Columns["ReservationID"].HeaderText = "Reservation ID";
                dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
                dataGridView1.Columns["Phone"].HeaderText = "Phone";
                dataGridView1.Columns["RoomNumber"].HeaderText = "Room Number";
                dataGridView1.Columns["RoomType"].HeaderText = "Room Type";
                dataGridView1.Columns["CheckIn"].HeaderText = "Check In Date";
                dataGridView1.Columns["CheckOut"].HeaderText = "Check Out Date";

                // Set column widths
                dataGridView1.Columns["ReservationID"].Width = 130;
                dataGridView1.Columns["CustomerName"].Width = 200;
                dataGridView1.Columns["Phone"].Width = 150;
                dataGridView1.Columns["RoomNumber"].Width = 130;
                dataGridView1.Columns["RoomType"].Width = 150;
                dataGridView1.Columns["CheckIn"].Width = 160;
                dataGridView1.Columns["CheckOut"].Width = 160;

                // Center align specific columns
                dataGridView1.Columns["ReservationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["RoomNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["CheckIn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["CheckOut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Format date columns
                dataGridView1.Columns["CheckIn"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dataGridView1.Columns["CheckOut"].DefaultCellStyle.Format = "yyyy-MM-dd";

                // Make columns fill remaining space
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name != "ReservationID" && column.Name != "RoomNumber" &&
                        column.Name != "CheckIn" && column.Name != "CheckOut")
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}