using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class Проект
{
    public int Id { get; set; }

    public DateTime? ДатаНачала { get; set; }

    public DateTime? ДатаКонца { get; set; }

    public int? Цена { get; set; }
}
