
namespace DAL
{
    using System;
	using Entities;

    public partial interface IAuditedOperationRepository : IGenericRepository<AuditedOperation>
    {
    }
}
