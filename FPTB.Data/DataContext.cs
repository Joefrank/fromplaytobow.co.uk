using FPTB.Data.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTB.Data
{
    public class FPTBContext : DbContext
    {
        [Inject]
        public FPTBContext()
            : base("name=FromPlayToBowDB")
        {
            Database.SetInitializer<FPTBContext>(new FPTBContextCustomInitializer());
        }

        public DbSet<HtmlPage> HtmlPages { get; set; }

        public DbSet<HtmlBlock> HtmlBlocks { get; set; }

        public DbSet<User> Users { get; set; }
    }

    public class FPTBContextCustomInitializer : IDatabaseInitializer<FPTBContext>
    {
        public void InitializeDatabase(FPTBContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
            else
            {
                context.Database.Create();
            }
            context.SaveChanges();
        }
    }
}
