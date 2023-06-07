using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class CityMaster
{
    public int Id { get; set; }

    public int? StateId { get; set; }

    public string? City { get; set; }

    public virtual StateMaster? State { get; set; }

    public virtual ICollection<StudentMaster> StudentMasters { get; set; } = new List<StudentMaster>();
}
