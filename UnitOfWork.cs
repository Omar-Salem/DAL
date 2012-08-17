
namespace DAL
{       
    using System;
    using System.ComponentModel.Composition;
    using Entities;
	
    [Export(typeof(IUnitOfWork)), PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private Variables
        
        private TestContext context = null;
        private bool disposed = false;
      
        private ICustomerRepository _customerRepository;

        #endregion        
        
        #region Constructors

        [ImportingConstructor]
        public UnitOfWork()
        {
            this.context = new TestContext();
        }

        #endregion

        #region Public Properties
 
        public ICustomerRepository customerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    this._customerRepository = new customerRepository(this.context);
                }
                
                return this._customerRepository; 
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
