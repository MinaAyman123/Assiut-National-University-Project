using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room? Room { get; set; }
}
