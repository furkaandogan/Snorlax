using Microsoft.EntityFrameworkCore;

namespace Snorlax.Repository.SQLDB
{
    public interface ISQLDBContext
    {
        DbSet<T> GetDbSet<T>(string tableName=null)
            where T:class,IDocument;
    }
}