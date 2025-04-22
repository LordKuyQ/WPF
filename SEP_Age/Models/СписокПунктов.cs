using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class СписокПунктов
{
    public int? IdПрофиля { get; set; }

    public int? IdПункта { get; set; }

    public virtual Профиль? IdПрофиляNavigation { get; set; }

    public virtual ПунктыНаблюд? IdПунктаNavigation { get; set; }
}
