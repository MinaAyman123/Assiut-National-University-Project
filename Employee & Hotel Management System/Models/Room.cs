using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? Type { get; set; }

    public decimal PricePerNight { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
