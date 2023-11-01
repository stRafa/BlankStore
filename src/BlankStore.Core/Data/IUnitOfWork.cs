namespace BlankStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
