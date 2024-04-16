using System;
using System.Collections.Generic;

namespace starwars;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Height { get; set; }

    public double? Mass { get; set; }

    public string? HairColor { get; set; }

    public string? SkinColor { get; set; }

    public string? EyeColor { get; set; }

    public string? BirthYear { get; set; }

    public string? Gender { get; set; }

    public int PlanetId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Url { get; set; }

    public virtual Planet Planet { get; set; } = null!;
}
