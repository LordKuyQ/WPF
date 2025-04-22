using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("список_пунктов")]
public partial class СписокПунктов
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_профиля")]
    public int IdПрофиля { get; set; }

    [Column("id_пункта")]
    public int IdПункта { get; set; }

    [ForeignKey("IdПрофиля")]
    [InverseProperty("СписокПунктовs")]
    public virtual Профиль IdПрофиляNavigation { get; set; } = null!;

    [ForeignKey("IdПункта")]
    [InverseProperty("СписокПунктовs")]
    public virtual ПунктыНаблюд IdПунктаNavigation { get; set; } = null!;
}
