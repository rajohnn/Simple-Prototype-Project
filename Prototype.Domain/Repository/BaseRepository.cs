using System;
using System.Data.Entity;

namespace Prototype.Domain.Repository {

    public abstract class BaseRepository : IDisposable {
        protected DbContext _ctx;
        private bool _disposed = false;

        public BaseRepository(string connectionString) {
            _ctx = new DbContext(connectionString);

#if DEBUG
            // enable to view SQL queries when in debug mode or performing unit tests.
            //_ctx.Database.Log = s => System.Diagnostics.Debug.Write(s);
#endif
        }

        public BaseRepository(DbContext ctx) {
            _ctx = ctx;
        }

        #region IDisposable

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }
            if (disposing) {
                _ctx.Dispose();
            }
            _disposed = true;
        }

        #endregion IDisposable
    }
}