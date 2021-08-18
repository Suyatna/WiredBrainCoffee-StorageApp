using System.Text.Json;

namespace WiredBrainCoffee_StorageApp.Entities
{
    public static class EntityExtensions
    {
        public static T? Copy<T>(this T itemCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
