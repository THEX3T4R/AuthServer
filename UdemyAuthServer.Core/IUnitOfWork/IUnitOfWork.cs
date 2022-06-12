namespace UdemyAuthServer.Core.IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
