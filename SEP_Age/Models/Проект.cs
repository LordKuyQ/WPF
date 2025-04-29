using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Проект")]
public partial class Проект
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("название")]
    public string Название { get; set; }

    [Column("дата_начала", TypeName = "DATE")]
    public DateOnly ДатаНачала { get; set; }

    [Column("дата_конца", TypeName = "DATE")]
    public DateOnly ДатаКонца { get; set; }

    [Column("цена")]
    public int Цена { get; set; }

    [InverseProperty("IdПроектаNavigation")]
    public virtual ICollection<СписокПлощадей> СписокПлощадейs { get; set; } = new List<СписокПлощадей>();

    [InverseProperty("IdПроектаNavigation")]
    public virtual ICollection<СписокУчастников> СписокУчастниковs { get; set; } = new List<СписокУчастников>();
}