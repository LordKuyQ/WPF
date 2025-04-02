using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class Измерения
{
    public int Id { get; set; }

    public int Давление { get; set; }

    public string? Описание { get; set; }
}
