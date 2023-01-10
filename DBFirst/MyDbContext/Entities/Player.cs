using System;
using System.Collections.Generic;

namespace DBFirst.MyDbContext.Entities;

public partial class Player
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Level { get; set; } = null!;

    public Guid TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;
}
