using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    public class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        public List<T> GetAll()
        {
            return new List<T>(items);
        }

        public T? GetById(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }

        public bool Remove(Func<T, bool> predicate)
        {
            var itemsToRemove = items.Where(predicate).ToList();
            foreach (var item in itemsToRemove)
            {
                items.Remove(item);
            }
            return itemsToRemove.Count > 0;
        }
    }
}

