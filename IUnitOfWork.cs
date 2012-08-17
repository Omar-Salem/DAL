
namespace DAL
{
    using System;

    public interface IUnitOfWork
    {
        #region Properties

        ICustomerRepository customerRepository { get; }                

        #endregion
        
        #region Methods
        
        void Dispose();

        void Commit();
		
        #endregion
    }
}
