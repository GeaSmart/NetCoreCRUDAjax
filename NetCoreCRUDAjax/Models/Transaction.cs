using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Numero de cuenta")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(10)]
        public string AccountNumber { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Beneficiario")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(100)]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "varchar(30)")]
        [DisplayName("Banco")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string BankName { get; set; }

        [DisplayName("Fecha")]
        public DateTime TransactionDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayName("Monto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Ammount { get; set; }
    }
}
