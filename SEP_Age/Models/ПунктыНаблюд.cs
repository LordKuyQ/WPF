using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Пункты_наблюд")]
public partial class ПунктыНаблюд
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("x")]
    public int X { get; set; }

    [Column("y")]
    public int Y { get; set; }

    [InverseProperty("IdПунктаNavigation")]
    public virtual ICollection<СписокИзмерений> СписокИзмеренийs { get; set; } = new List<СписокИзмерений>();

    [InverseProperty("IdПунктаNavigation")]
    public virtual ICollection<СписокПунктов> СписокПунктовs { get; set; } = new List<СписокПунктов>();
}
