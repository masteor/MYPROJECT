using System;

namespace QWERTY.Shared.Db.Infrastructure
{
    public class DisposableObject : IDisposable
    {
        private bool _isDisposed;
 
        ~DisposableObject()
        {
            Dispose(false);
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }
 
            _isDisposed = true;
        }
 
        /// <summary>
        /// Ovveride this to dispose custom objects
        /// </summary>
        protected virtual void DisposeCore()
        {

        }
    }
}
