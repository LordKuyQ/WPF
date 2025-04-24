using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class ZakazSkidka
{
    public int Id { get; set; }

    public int IdZakaz { get; set; }

    public int IdSkidka { get; set; }

    public virtual Skidka IdSkidkaNavigation { get; set; } = null!;

    public virtual Zakaz IdZakazNavigation { get; set; } = null!;
}
