using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class Профиль
{
    public int Id { get; set; }

    public int? Длина { get; set; }

    public int? Высота { get; set; }

    public string? Описание { get; set; }
}
