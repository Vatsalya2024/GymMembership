using System;
namespace GymMembership.Interface
{
    public interface IRepository<K, T>
    {
        Task<List<T>?> GetAll();
        Task<T?> Get(K key);
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T?> Delete(K key);
    }
}

