using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class Location
  {
    [Key]
    public int LocationId { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Address {get;set;}

    public virtual ICollection<Transaction> Transactions {get;set;}
  }
}