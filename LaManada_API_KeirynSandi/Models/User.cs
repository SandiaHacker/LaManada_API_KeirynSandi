using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class User
{
    public int UsersId { get; set; }

    public int? UserRoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Province { get; set; }

    public string? Canton { get; set; }

    public string? District { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual UserRole? UserRole { get; set; }
}
