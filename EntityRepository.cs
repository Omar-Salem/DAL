
namespace DAL
{
    using System.ComponentModel.Composition;
    using Entities;

    [Export(typeof(IAuditedOperationRepository)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AuditedOperationRepository : GenericRepository<AuditedOperation>, IAuditedOperationRepository
    {
        [ImportingConstructor]
        public AuditedOperationRepository(FA31SalesDemoEntities context)
            : base(context)
        {
        }        
    }
}
