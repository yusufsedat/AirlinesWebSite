using Microsoft.EntityFrameworkCore;

namespace WebProgramlama_Odev.Models
{
    public class AirlineContext :DbContext
    {

        public DbSet <User> Users { get; set; }
        public DbSet <GuzergahModel> Guzergah { get; set; }
        public DbSet <UcusModel> Ucus { get; set; }
        public DbSet <AdminModel> Admins { get; set; }
        public DbSet <UserUcus> UserUcus { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Airline; Trusted_Connection=True;");
        }
    }
}
