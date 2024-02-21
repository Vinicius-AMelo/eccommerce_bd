namespace E_Commerce.Interfaces
{
    public interface IUpdateService<T> 
    {
        T UpdateEntity(T existingEntity, T updatedEntity);
    }
}
