using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Size { get; set; }

    public int TypeId { get; set; }

    public int Price { get; set; }

    public string Model { get; set; } = null!;

    public virtual ICollection<Bron> Brons { get; set; } = new List<Bron>();

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
