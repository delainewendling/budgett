using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class Goal
  {
    [Key]
    public int GoalId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Amount {get;set;}

    [Required]
    public DateTime DateToComplete {get;set;}

    [Required]
    public double ContributedAmount {get;set;}

    [Required]
    public bool IsSpending {get;set;}

    [Required]
    public int AccountId {get;set;}
    
    public virtual ICollection<Transaction> Transactions {get;set;}
  }
}