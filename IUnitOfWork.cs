
namespace DAL
{
    using System;

    public interface IUnitOfWork
    {
        #region Properties

        IAuditedOperationRepository AuditedOperationRepository { get; }                

        #endregion
        
        #region Methods
        
        void Dispose();

        void Commit();
		
        #endregion
    }
}
