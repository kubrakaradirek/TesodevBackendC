namespace TesodevBackendC.Customer.WebApi.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);
        List<T> GetListAll();
    }
}
