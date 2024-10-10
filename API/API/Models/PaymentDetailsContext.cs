using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Models
{
    public class PaymentDetailsContext : DbContext
    {
        public PaymentDetailsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PaymentAPI> PaymentsAPI { get; set; }
    }
}
