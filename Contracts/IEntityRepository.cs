
namespace DAL
{
    using System;
	using Entities;

    public partial interface ICustomerRepository : IGenericRepository<TestContext,customer>
    {
    }
}
