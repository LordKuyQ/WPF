using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("список_участников")]
public partial class СписокУчастников
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_проекта")]
    public int IdПроекта { get; set; }

    [Column("id_пользователя")]
    public int IdПользователя { get; set; }

    [ForeignKey("IdПользователя")]
    [InverseProperty("СписокУчастниковs")]
    public virtual Пользователь IdПользователяNavigation { get; set; } = null!;

    [ForeignKey("IdПроекта")]
    [InverseProperty("СписокУчастниковs")]
    public virtual Проект IdПроектаNavigation { get; set; } = null!;
}
