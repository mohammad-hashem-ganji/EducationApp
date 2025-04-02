using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class EducationDistrict
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;
}
