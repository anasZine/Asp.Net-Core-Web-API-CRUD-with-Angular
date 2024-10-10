﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Ecommerce.Models



{
    public class PaymentAPI
    {
        [Key]
        public int PaymentDetailsId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string CardNumber { get; set; } = "";
        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; } = "";
        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = "";





    }
}
