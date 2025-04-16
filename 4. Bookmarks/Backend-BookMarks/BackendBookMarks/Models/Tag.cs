using System;
using System.Collections.Generic;

namespace BackendBookMarks.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
