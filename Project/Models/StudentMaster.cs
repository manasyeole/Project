using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class StudentMaster
{
    public int Id { get; set; }

    public string? StudentFName { get; set; }

    public string? StudentMName { get; set; }

    public string? StudentLName { get; set; }

    public int? StudentState { get; set; }

    public int? StudentCity { get; set; }

    public string? Gender { get; set; }

    public virtual CityMaster? StudentCityNavigation { get; set; }

    public virtual StateMaster? StudentStateNavigation { get; set; }
}
