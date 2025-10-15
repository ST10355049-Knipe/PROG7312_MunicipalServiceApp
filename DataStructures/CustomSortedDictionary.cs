using System;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    public class CustomSortedDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {
        public class CustomSortedDictionary<TKey, TValue> where TKey : IComparable<TKey>
        {
            private readonly CustomLinkedList<KeyValuePair<TKey, TValue>> items;

            public CustomSortedDictionary()
            {
                items = new CustomLinkedList<KeyValuePair<TKey, TValue>>();
            }
        }
}