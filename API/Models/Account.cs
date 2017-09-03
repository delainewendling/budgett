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
    
    ICollection<User> Users {get;set;}
    ICollection<Goal> Goals {get;set;}
    ICollection<UserAccount> UserAccount {get;set;}
  }
}