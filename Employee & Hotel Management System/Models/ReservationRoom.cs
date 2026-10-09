using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class ReservationRoom
{
    public int ReservationRoomId { get; set; }

    public int ReservationId { get; set; }

    public int RoomId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
