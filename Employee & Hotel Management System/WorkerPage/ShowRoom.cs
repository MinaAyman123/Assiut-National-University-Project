using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.WorkerPage
{
    public partial class ShowRoom : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public ShowRoom()
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
            this.btnShow.Click += BtnShow_Click;

            // Hover effect
            this.btnShow.MouseEnter += (s, e) => btnShow.BackColor = Color.FromArgb(41, 128, 185);
            this.btnShow.MouseLeave += (s, e) => btnShow.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void BtnShow_Click(object sender, EventArgs e)
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

                // Get rooms by type - use only properties that exist in your Room model
                var rooms = db.Rooms
                    .Where(r => r.Type == selectedType)
                    .Select(r => new
                    {
                        RoomID = r.RoomId,
                        RoomNumber = r.RoomNumber,
                        Type = r.Type,
                        Status = r.Status
                        // Remove Price and Description if they don't exist
                    })
                    .ToList();

                if (rooms.Count == 0)
                {
                    MessageBox.Show($"No rooms found for type: {selectedType}", "No Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Visible = false;
                    return;
                }

                // Show and bind data
                dataGridView1.Visible = true;
                dataGridView1.DataSource = rooms;

                // Format the DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // Set column headers
                dataGridView1.Columns["RoomID"].HeaderText = "Room ID";
                dataGridView1.Columns["RoomNumber"].HeaderText = "Room Number";
                dataGridView1.Columns["Type"].HeaderText = "Type";
                dataGridView1.Columns["Status"].HeaderText = "Status";

                // Set column widths
                dataGridView1.Columns["RoomID"].Width = 150;
                dataGridView1.Columns["RoomNumber"].Width = 200;
                dataGridView1.Columns["Type"].Width = 200;
                dataGridView1.Columns["Status"].Width = 200;

                // Center align all columns
                dataGridView1.Columns["RoomID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["RoomNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Color code status
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        if (status == "Available")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Green;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        }
                        else if (status == "Booked")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Red;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        }
                        else if (status == "Maintenance")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Orange;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        }
                    }
                }

                // Make all columns fill remaining space equally
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}