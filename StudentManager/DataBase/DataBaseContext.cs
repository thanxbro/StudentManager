using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManager.DataBase.Data;


namespace StudentManager.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public string DbPath { get; }
        public DataBaseContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "database.db");

            if(Database.EnsureCreated())
            {
                Teachers.Add(new Teacher { Name = "Сафронов Леонид Яковлевич" });
                Teachers.Add(new Teacher { Name = "Потемина Анна Анатольевна" });
                Teachers.Add(new Teacher { Name = "Григорьев Вячеслав Александрович" });

                Departaments.Add(new Departament { Name = "Вычислительные машины и комплексы" });
                Departaments.Add(new Departament { Name = "Химическая и нефтихимическая промышленность" });
                SaveChanges();
            }
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
