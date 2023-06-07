using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class StateMaster
{
    public int Id { get; set; }

    public string? State { get; set; }

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual ICollection<StudentMaster> StudentMasters { get; set; } = new List<StudentMaster>();
}
