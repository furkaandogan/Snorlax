namespace Snorlax.Web.Api.Models.Request
{
    public abstract class BasePostModel<TRepositoryDocument>
        where TRepositoryDocument:Repository.IDocument
    {
        public abstract TRepositoryDocument ToRepositoyModel(RequestType requestType);
    }
}