using test001.Model;
using Microsoft.EntityFrameworkCore;

namespace test001.Data
{
    public class DessertsContext : DbContext
    {
        //Constructor
        public DessertsContext(DbContextOptions<DessertsContext> options) : base(options) { }

        public DessertsContext() { }

        public DbSet<Desserts> Desserts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping + จัดการ relations
            modelBuilder.Entity<Desserts>().ToTable("Desserts");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost";
            string database = "dessert";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3306;SslMode=Required;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
