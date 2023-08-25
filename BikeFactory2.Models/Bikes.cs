using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BikeFactory2.Models.Enums;

namespace BikeFactory2.Models;

public class Bikes
{
    [Key]
    public int Id { get; set; }

    [Required()] 
    [Unicode(false)] 
    [StringLength(50)] 
    public string Name { get; set; } = string.Empty;

    [Required()]
    [DisplayName("Suspension Type")]
    [Range(1, int.MaxValue, ErrorMessage = "The Suspension Type field is required")]
    public int SuspensionType { get; set; }

    [Required()]
    [DisplayName("Tire Type")]
    [Range(1, int.MaxValue, ErrorMessage = "The Tire Type field is required")]
    public int TireType { get; set; }
}
