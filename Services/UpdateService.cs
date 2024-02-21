using E_Commerce.Interfaces;

namespace E_Commerce.Services
{
    public class UpdateService<T> : IUpdateService<T>
    {
        public T UpdateEntity(T existingEntity, T updatedEntity)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var updatedValue = property.GetValue(updatedEntity);
                if (updatedValue != null && property.Name != "Id")
                {
                    property.SetValue(existingEntity, updatedValue);
                }
            }
            return existingEntity;
        }
    }
}
