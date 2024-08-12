using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class Transport
{
    public int TransportId { get; set; }

    public int? Reservation { get; set; }

    public string? PickupAddress { get; set; }

    public string? DropoffAddress { get; set; }

    public DateOnly? TransportDate { get; set; }

    public TimeOnly? TransportTime { get; set; }

    public string? TransportStatus { get; set; }

    public virtual Reservation? ReservationNavigation { get; set; }
}
