﻿namespace TesodevBackendC.Customer.WebApi.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TCreate(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        T TGetById(Guid id);
        List<T> TGetListAll();
    }
}
