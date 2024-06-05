using System;
using System.Collections.Generic;

namespace INDEX_RPG_API.Repositories.Models;

public partial class CharacterStat
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Health { get; set; }

    public int Mana { get; set; }

    public int Damage { get; set; }
}
