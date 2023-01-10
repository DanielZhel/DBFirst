using System;
using System.Collections.Generic;

namespace DBFirst.MyDbContext.Entities;

public partial class Team
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CoachId { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual ICollection<Player> Players { get; } = new List<Player>();
}
