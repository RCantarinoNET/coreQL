using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreQL.Entities
{
    public class Account
    {
        [Key] 
        public Guid Id { get; set; }
        
        [Required]
        public TypeAccount TypeAccount { get; set; }
        
        public string Description { get; set; }
        
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }



    public enum TypeAccount
    {
        Cash,
        Savings,
        Expense,
        Income
    }
}