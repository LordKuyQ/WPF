using System;
using System.Collections.Generic;

namespace WPF_KOZ_LAB1.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int Telefon { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Zakaz> Zakazs { get; set; } = new List<Zakaz>();
}
