
namespace DAL
{
    using System.ComponentModel.Composition;
    using Entities;
	using System.Data;
    using System.Linq;

    [Export(typeof(ICustomerRepository)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class customerRepository : GenericRepository<customer>, ICustomerRepository
    {
        [ImportingConstructor]
        public customerRepository(TestEntities context)
            : base(context)
        {
        }
		
		public override customer GetById(int id)
        {
            return Set.SingleOrDefault(e => e.ID == id);
        }        
    }
}
