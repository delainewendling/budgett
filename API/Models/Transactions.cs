using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budgett.Models
{
  public class Transaction
  {

    public Transaction()
    {
      DateEntered = DateTime.Now;
    }

    [Key]
    public int TransactionId { get; set; }

    [Required]
    public bool IsExpense { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateEntered {get;set;}

    [Required]
    public bool IsRecurring {get;set;}

    [Required]
    public double Amount {get;set;}

    [Required]
    public bool IsNeed {get;set;}

    [Required]
    public int CategoryId {get;set;}

    [Required]
    public int AccountId {get;set;}

    [Required]
    public int LocationId {get;set;}

  }
}