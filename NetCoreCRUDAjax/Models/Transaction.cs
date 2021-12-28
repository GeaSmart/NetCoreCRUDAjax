using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCRUDAjax.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string BeneficiaryName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string BankName { get; set; }
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Ammount { get; set; }
    }
}
