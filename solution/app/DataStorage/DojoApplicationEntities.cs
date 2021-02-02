using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace DataStorage
{
    public partial class DojoApplicationEntities : DbContext
    {
        public DojoApplicationEntities(bool lazyLoadingEnabled)
        {
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }
    }
}
