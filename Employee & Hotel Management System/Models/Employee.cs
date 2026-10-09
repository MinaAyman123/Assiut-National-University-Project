using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string Role { get; set; } = null!;

    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public string Password { get; set; } = null!;

    public virtual Department? Department { get; set; }
}
