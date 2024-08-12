using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class PetCare
{
    public int PetCareId { get; set; }

    public string? CareType { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
