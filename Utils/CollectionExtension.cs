using System.Collections.ObjectModel;

namespace RackManager.Utils
{
    public static class CollectionExtension
    {
        public static ObservableCollection<T> ToCollection<T>(this ObservableCollection<T> collection, IEnumerable<T> list)
        {
            if (collection != null)
            {
                foreach (T item in list)
                {
                    collection.Add(item);
                }
                return collection;
            }
            return null;
        }
    }
}
