using System;
using System.Collections.Generic;

namespace SEP_Age.Models;

public partial class Пользователь
{
    public int Id { get; set; }

    public string? ТипПользователя { get; set; }

    public string? Фио { get; set; }

    public int? Телефон { get; set; }

    public string? Емайл { get; set; }

    public string? Пароль { get; set; }
}
