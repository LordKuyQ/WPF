using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class Bron
{
    public int Id { get; set; }

    public DateTime DtBron { get; set; }

    public int InvId { get; set; }

    public virtual Inventory Inv { get; set; } = null!;
}
