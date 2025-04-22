using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class КоординатыПлощади
{
    public int IdПлощади { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public virtual Площадь? IdПлощадиNavigation { get; set; }
}
