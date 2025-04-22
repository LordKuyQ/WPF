using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("список_профилей")]
public partial class СписокПрофилей
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_площади")]
    public int IdПлощади { get; set; }

    [Column("id_профиля")]
    public int IdПрофиля { get; set; }

    [ForeignKey("IdПлощади")]
    [InverseProperty("СписокПрофилейs")]
    public virtual Площадь IdПлощадиNavigation { get; set; } = null!;

    [ForeignKey("IdПрофиля")]
    [InverseProperty("СписокПрофилейs")]
    public virtual Профиль IdПрофиляNavigation { get; set; } = null!;
}
