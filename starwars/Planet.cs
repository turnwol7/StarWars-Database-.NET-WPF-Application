using System;
using System.Collections.Generic;

namespace starwars;

public partial class Planet
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RotationPeriod { get; set; }

    public int? OrbitalPeriod { get; set; }

    public int? Diameter { get; set; }

    public string? Climate { get; set; }

    public string? Gravity { get; set; }

    public string? Terrain { get; set; }

    public string? SurfaceWater { get; set; }

    public long? Population { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
