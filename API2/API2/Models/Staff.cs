using System;
using System.Collections.Generic;

namespace API2.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? ShortName { get; set; }
}
