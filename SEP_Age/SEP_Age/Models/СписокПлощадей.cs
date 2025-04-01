using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class СписокПлощадей
{
    public int? IdПроекта { get; set; }

    public int? IdПлощади { get; set; }

    public virtual Площадь? IdПлощадиNavigation { get; set; }

    public virtual Проект? IdПроектаNavigation { get; set; }
}
