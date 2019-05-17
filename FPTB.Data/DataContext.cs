using FPTB.Data.Model;
using Ninject;
using System.Data.Entity;

namespace FPTB.Data
{
    public class FPTBContext : DbContext
    {
        [Inject]
        public FPTBContext()
            : base("name=FromPlayToBowDB")
        {
            //Database.SetInitializer<FPTBContext>(new FPTBContextCustomInitializer());
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<HtmlPage> HtmlPages { get; set; }
        public DbSet<HtmlBlock> HtmlBlocks { get; set; }
        public DbSet<User> Users { get; set; }
    }
   
}
