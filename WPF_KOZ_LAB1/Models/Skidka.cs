using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class Skidka
{
    public int Id { get; set; }

    public int Pers { get; set; }

    public virtual ICollection<ZakazSkidka> ZakazSkidkas { get; set; } = new List<ZakazSkidka>();
}
