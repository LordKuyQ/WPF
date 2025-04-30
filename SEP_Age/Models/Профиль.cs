using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Профиль")]
public partial class Профиль
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("длина")]
    public int Длина { get; set; }

    [Column("высота")]
    public int Высота { get; set; }

    [Column("описание")]
    public string Описание { get; set; } = null!;

    [InverseProperty("IdПрофиляNavigation")]
    public virtual ICollection<СписокПрофилей> СписокПрофилейs { get; set; } = new List<СписокПрофилей>();

    [InverseProperty("IdПрофиляNavigation")]
    public virtual ICollection<СписокПунктов> СписокПунктовs { get; set; } = new List<СписокПунктов>();
}
