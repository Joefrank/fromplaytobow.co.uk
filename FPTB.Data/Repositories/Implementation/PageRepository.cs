using FPTB.Data.Model;
using FPTB.Data.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTB.Data.Repositories.Implementation
{
    public class PageRepository : GenericRepository<HtmlPage>, IPageRepository
    {
        public PageRepository(DbContext context)
            : base(context)
        {
            
        }  
    }
}
