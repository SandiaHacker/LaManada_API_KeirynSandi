using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? Users { get; set; }

    public int? Pet { get; set; }

    public int? PetCare { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public TimeOnly? ReservationTime { get; set; }

    public virtual PetCare? PetCareNavigation { get; set; }

    public virtual Pet? PetNavigation { get; set; }

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();

    public virtual User? UsersNavigation { get; set; }
}
