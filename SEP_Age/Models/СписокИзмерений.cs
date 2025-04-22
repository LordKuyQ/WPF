using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class СписокИзмерений
{
    public int? IdПункта { get; set; }

    public int? IdИзмерения { get; set; }

    public virtual Измерения? IdИзмеренияNavigation { get; set; }

    public virtual ПунктыНаблюд? IdПунктаNavigation { get; set; }
}
