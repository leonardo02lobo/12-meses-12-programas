using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Premium
{
    public int IdPremium { get; set; }

    public string TipoPlan { get; set; } = null!;

    public virtual Usuario IdPremiumNavigation { get; set; } = null!;
}
