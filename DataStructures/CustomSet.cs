namespace PROG7312_MunicipalServiceApp.DataStructures
{
    public class CustomSet<T>
    {
        // My set uses my custom linked list on the inside to store the items.
        private readonly CustomLinkedList<T> items;

        public CustomSet()
        {
            items = new CustomLinkedList<T>();
        }

        // The Add method is what makes this a set - it stops any duplicates.
        public bool Add(T item)
        {
            //I check if the item is already in the list.
            if (items.Contains(item))
            {
                // If it's already there, I do nothing.
                return false;
            }

            // If it's a new item, I add it.
            items.Add(item);
            return true;
        }

        // This method just uses the linked list's Contains method.
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public List<T> GetAllItems()
        {
            return items.GetAllNodesAsList();
        }
    }
}