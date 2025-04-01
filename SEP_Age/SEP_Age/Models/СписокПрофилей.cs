using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class СписокПрофилей
{
    public int? IdПлощади { get; set; }

    public int? IdПрофиля { get; set; }

    public virtual Площадь? IdПлощадиNavigation { get; set; }

    public virtual Профиль? IdПрофиляNavigation { get; set; }
}
