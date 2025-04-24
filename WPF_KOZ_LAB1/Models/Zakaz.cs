using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class Zakaz
{
    public int Id { get; set; }

    public int InvId { get; set; }

    public int Time { get; set; }

    public int ClentId { get; set; }

    public virtual Client Clent { get; set; } = null!;

    public virtual Inventory Inv { get; set; } = null!;

    public virtual ICollection<ZakazSkidka> ZakazSkidkas { get; set; } = new List<ZakazSkidka>();
}
