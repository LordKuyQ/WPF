using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Площадь")]
public partial class Площадь
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("координаты")]
    public int Координаты { get; set; }

    [Column("площадь")]
    public int Площадь1 { get; set; }

    [InverseProperty("IdПлощадиNavigation")]
    public virtual ICollection<КоординатыПлощади> КоординатыПлощадиs { get; set; } = new List<КоординатыПлощади>();

    [InverseProperty("IdПлощадиNavigation")]
    public virtual ICollection<КоординатыПрофиля> КоординатыПрофиляs { get; set; } = new List<КоординатыПрофиля>();

    [InverseProperty("IdПлощадиNavigation")]
    public virtual ICollection<СписокПлощадей> СписокПлощадейs { get; set; } = new List<СписокПлощадей>();

    [InverseProperty("IdПлощадиNavigation")]
    public virtual ICollection<СписокПрофилей> СписокПрофилейs { get; set; } = new List<СписокПрофилей>();
}
