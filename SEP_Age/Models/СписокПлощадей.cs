using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("список_площадей")]
public partial class СписокПлощадей
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_проекта")]
    public int IdПроекта { get; set; }

    [Column("id_площади")]
    public int IdПлощади { get; set; }

    [ForeignKey("IdПлощади")]
    [InverseProperty("СписокПлощадейs")]
    public virtual Площадь IdПлощадиNavigation { get; set; } = null!;

    [ForeignKey("IdПроекта")]
    [InverseProperty("СписокПлощадейs")]
    public virtual Проект IdПроектаNavigation { get; set; } = null!;
}
