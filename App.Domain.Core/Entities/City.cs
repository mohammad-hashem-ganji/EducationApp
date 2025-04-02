using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public virtual ICollection<EducationDistrict> EducationDistricts { get; set; } = new List<EducationDistrict>();

    public virtual Province Province { get; set; } = null!;
}
