using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities
{
    public abstract class CSACollection:CollectionBase
    {
        public abstract bool GetItems(SqlConnection connection);
        public T Find<T>(Predicate<T> predicate) where T : class
        {
            return this.Cast<T>().FirstOrDefault(item => predicate(item));
        }
        public void AddRange<T>(IEnumerable<T> value) where T : class
        {
            foreach (T item in value)
            {
                InnerList.Add(item);
            }
        }
        public int Add<T>(T value) where T : class
        {
            return InnerList.Add(value);
        }

        public void Remove<T>(T value) where T : class
        {
            InnerList.Remove(value);
        }
        public void Insert(int index, object cruiseLine)
        {
            List.Insert(index, cruiseLine);
        }
    }
}