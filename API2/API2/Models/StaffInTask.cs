using System;
using System.Collections.Generic;

namespace API2.Models;

public partial class StaffInTask
{
    public int Id { get; set; }

    public int Idstaff { get; set; }

    public int Idstask { get; set; }
}
