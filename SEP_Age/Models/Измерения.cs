using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

[Table("Измерения")]
public partial class Измерения
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("давление")]
    public int Давление { get; set; }

    [Column("описание")]
    public string Описание { get; set; } = null!;

    [Column("абсолютная_высота")]
    public int АбсолютнаяВысота { get; set; }

    [Column("расстояние")]
    public int Расстояние { get; set; }

    [InverseProperty("IdИзмеренияNavigation")]
    public virtual ICollection<СписокИзмерений> СписокИзмеренийs { get; set; } = new List<СписокИзмерений>();
}