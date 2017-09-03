using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class User
  {
    [Key]
    public int UserId { get; set; }

    public User()
    {
        DateCreated = DateTime.Now;
    }

    [Required]
    public DateTime DateCreated {get;set;}

    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName {get;set;}

    [Required]
    public string Email {get;set;}

    [Required]
    public double BankBalance {get;set;}
  }
}