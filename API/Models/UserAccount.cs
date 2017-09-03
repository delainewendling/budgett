using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class UserAccount
  {
    [Key]
    public int UserAccountId { get; set; }

    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int AccountId {get;set;}

    public User User {get;set;}
    public Account Account {get;set;}
  }
}