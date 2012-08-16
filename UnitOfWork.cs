
namespace DAL
{       
    using System;
    using System.ComponentModel.Composition;
    using Entities;
	
    [Export(typeof(IUnitOfWork)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private Variables
        
        private FA31SalesDemoEntities context = null;
        private bool disposed = false;
        private IAuditedOperationRepository auditedoperationRepository;

        #endregion        
        
        #region Constructors

        [ImportingConstructor]
        public UnitOfWork()
        {
            this.context = new FA31SalesDemoEntities();
        }

        #endregion

        #region Public Properties

        public IAuditedOperationRepository AuditedOperationRepository
        {
            get
            {
                if (this.auditedoperationRepository == null)
                {
                    this.auditedoperationRepository = new AuditedOperationRepository(this.context);
                }
                
                return this.auditedoperationRepository; 
            }
        }

        #endregion

        #region Public Methods
        
        public void Commit()
        {
             this.context.SaveChanges();
        }
        
        public void Dispose()
        {
             this.Dispose(true);
             GC.SuppressFinalize(this);
        }
		
        #endregion
        
        #region Proptected Virtual Methods
        
        protected virtual void Dispose(bool disposing)
        {
             if (!this.disposed)
             {
                 if (disposing)
                 {
                     this.context.Dispose();
                 }
             }
            
             this.disposed = true;
         }
        
        #endregion
    }
}
