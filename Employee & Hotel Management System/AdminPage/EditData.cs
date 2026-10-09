using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2.AdminPage
{
    public partial class EditData : Form
    {
        private MyDbContext db = new MyDbContext();
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public EditData()
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

            // Button events
            this.btnShowData.Click += BtnShowData_Click;
            this.btnSave.Click += BtnSave_Click;

            // Hover effects
            this.btnShowData.MouseEnter += (s, e) => btnShowData.BackColor = Color.FromArgb(41, 128, 185);
            this.btnShowData.MouseLeave += (s, e) => btnShowData.BackColor = Color.FromArgb(52, 152, 219);

            this.btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(39, 174, 96);
            this.btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(46, 204, 113);

            // Phone validation (only numbers)
            this.txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            this.Load += EditData_Load;
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = db.Employees.ToList();
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "Name";
                cmbEmployee.ValueMember = "EmployeeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Please select an employee first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(cmbEmployee.SelectedValue);
                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);

                if (employee != null)
                {
                    // Show labels and fields
                    lblName.Visible = true;
                    lblNameValue.Visible = true;
                    lblPhone.Visible = true;
                    txtPhone.Visible = true;
                    lblEmail.Visible = true;
                    txtEmail.Visible = true;
                    lblRole.Visible = true;
                    txtRole.Visible = true;
                    btnSave.Visible = true;

                    // Set values
                    lblNameValue.Text = employee.Name;
                    txtPhone.Text = employee.Phone;
                    txtEmail.Text = employee.Email;
                    txtRole.Text = employee.Role;
                }
                else
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Please select an employee first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Phone number is required.", "Validation Error",
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
                    MessageBox.Show("Email is required.", "Validation Error",
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

                if (string.IsNullOrWhiteSpace(txtRole.Text))
                {
                    MessageBox.Show("Role is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRole.Focus();
                    return;
                }

                int id = Convert.ToInt32(cmbEmployee.SelectedValue);
                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);

                if (employee != null)
                {
                    // Update employee data
                    employee.Phone = txtPhone.Text.Trim();
                    employee.Email = txtEmail.Text.Trim();
                    employee.Role = txtRole.Text.Trim();

                    db.SaveChanges();

                    MessageBox.Show($"Employee data has been updated successfully!\n\nName: {employee.Name}\nPhone: {employee.Phone}\nEmail: {employee.Email}\nRole: {employee.Role}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear and hide fields after save
                    ClearFields();
                    LoadEmployees(); // Refresh combo box
                }
                else
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            lblName.Visible = false;
            lblNameValue.Visible = false;
            lblPhone.Visible = false;
            txtPhone.Visible = false;
            lblEmail.Visible = false;
            txtEmail.Visible = false;
            lblRole.Visible = false;
            txtRole.Visible = false;
            btnSave.Visible = false;

            txtPhone.Clear();
            txtEmail.Clear();
            txtRole.Clear();
            lblNameValue.Text = "";

            cmbEmployee.SelectedIndex = -1;
        }
    }
}