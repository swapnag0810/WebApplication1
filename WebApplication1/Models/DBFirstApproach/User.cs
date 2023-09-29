using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DBFirstApproach;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Dob { get; set; }
}
