using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public int? Users { get; set; }

    public string? Name { get; set; }

    public string? Species { get; set; }

    public string? Breed { get; set; }

    public int? Age { get; set; }

    public decimal? Weight { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User? UsersNavigation { get; set; }
}
