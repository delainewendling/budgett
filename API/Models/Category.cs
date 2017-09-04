using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }
    
    public virtual ICollection<Transaction> Transactions {get;set;}
  }
}