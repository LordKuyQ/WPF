using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class СписокУчастников
{
    public int? IdПроекта { get; set; }

    public int? IdПользователя { get; set; }

    public virtual Пользователь? IdПользователяNavigation { get; set; }

    public virtual Проект? IdПроектаNavigation { get; set; }
}
