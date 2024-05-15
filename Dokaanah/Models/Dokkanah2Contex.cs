using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Dokaanah.Models
{
    public class Dokkanah2Contex: IdentityDbContext<Customer>
    {

        public Dokkanah2Contex()
        {

        }

        public Dokkanah2Contex(DbContextOptions<Dokkanah2Contex> options)
        : base(options)
        {
        }

        
        #region for identity

        //public virtual DbSet<Customer> Users { get; set; }
        //public virtual DbSet<IdentityRole> Roles { get; set; } 
        
        
        #endregion

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customer1s { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }


        public virtual DbSet<Product_Category> Product_Categories { get; set; }
        public virtual DbSet<Cart_Product> Cart_Products { get; set; }
        public virtual DbSet<product_customer> Product_Customers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.
        UseSqlServer("Server=DESKTOP-0HPU58A\\SQLEXPRESS;Database=DokkanahDataBase_2fff;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product_Category>()
                .HasKey(e => new { e.Pid, e.Cid });

            modelBuilder.Entity<Cart_Product>()
                .HasKey(e => new { e.Prid, e.Caid });

            modelBuilder.Entity<product_customer>()
                .HasKey(e => new { e.PrudId, e.CustId });


            modelBuilder.Entity<product_customer>()
                .HasOne(e => e.Prud).WithMany(z => z.Product_Customers)
                .HasForeignKey(e => e.PrudId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<product_customer>()
                .HasOne(e => e.Cust).WithMany(z => z.Product_Customelrs)
                .HasForeignKey(e => e.CustId).OnDelete(DeleteBehavior.ClientSetNull);




            //    modelBuilder.Entity<Login>()
            //        .HasIndex(l => l.StudentsId) // Create an index on CustomerId
            //        .IsUnique();
            //    OnModelCreatingPartial(modelBuilder);
            //
        }





        // protect potentially sensitive information in your connection string,
        // you should move it out of source code. You can avoid scaffolding
        // the connection string by using the Name= syntax to read it from
        // configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
        // For more guidance on storing connection strings,
        // see http://go.microsoft.com/fwlink/?LinkId=723263.




    }
}
