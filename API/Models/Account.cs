using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class Account
  {
    [Key]
    public int AccountId { get; set; }

    [Required]
    public string Name { get; set; }
    
    public virtual ICollection<User> Users {get;set;}
    public virtual ICollection<Goal> Goals {get;set;}
    public virtual ICollection<UserAccount> UserAccount {get;set;}
  }
}