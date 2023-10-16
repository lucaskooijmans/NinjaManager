﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;
public class Equipment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int ValueInGold { get; set; }
    public string Category { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
}
