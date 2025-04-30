using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("список_измерений")]
public partial class СписокИзмерений
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_пункта")]
    public int IdПункта { get; set; }

    [Column("id_измерения")]
    public int IdИзмерения { get; set; }

    [ForeignKey("IdИзмерения")]
    [InverseProperty("СписокИзмеренийs")]
    public virtual Измерения IdИзмеренияNavigation { get; set; } = null!;

    [ForeignKey("IdПункта")]
    [InverseProperty("СписокИзмеренийs")]
    public virtual ПунктыНаблюд IdПунктаNavigation { get; set; } = null!;
}