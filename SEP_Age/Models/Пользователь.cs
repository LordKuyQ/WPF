using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Пользователь")]
public partial class Пользователь
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("тип_пользователя")]
    public string ТипПользователя { get; set; } = null!;

    [Column("ФИО")]
    public string Фио { get; set; } = null!;

    [Column("пароль")]
    public string Пароль { get; set; } = null!;

    [Column("емайл")]
    public string Емайл { get; set; } = null!;

    [Column("телефон")]
    public int Телефон { get; set; }

    [InverseProperty("IdПользователяNavigation")]
    public virtual ICollection<СписокУчастников> СписокУчастниковs { get; set; } = new List<СписокУчастников>();
}
