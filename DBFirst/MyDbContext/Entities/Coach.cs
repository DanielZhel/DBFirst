using System;
using System.Collections.Generic;

namespace DBFirst.MyDbContext.Entities;

public partial class Coach
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Exp { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
