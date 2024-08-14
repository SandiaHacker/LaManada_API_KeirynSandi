using System;
using System.Collections.Generic;

namespace LaManada_API_KeirynSandi.Models;

public partial class Vwalluser
{
    public int? UserRoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int Expr1 { get; set; }
}
