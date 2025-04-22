using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("координаты_профиля")]
public partial class КоординатыПрофиля
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_площади")]
    public int IdПлощади { get; set; }

    [Column("x")]
    public int X { get; set; }

    [Column("y")]
    public int Y { get; set; }

    [ForeignKey("IdПлощади")]
    [InverseProperty("КоординатыПрофиляs")]
    public virtual Площадь IdПлощадиNavigation { get; set; } = null!;
}
