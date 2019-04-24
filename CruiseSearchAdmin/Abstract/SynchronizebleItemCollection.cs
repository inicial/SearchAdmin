using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities.SyncModel
{
    public abstract class SynchronizebleItemCollection : CSACollection,IEnumerable<ISynchronizeble>
    {
        
        public abstract SynchronizebleItemCollection CreateCollectionFromInstance();
        public ISynchronizeble this[int index]
        {
            get { return (ISynchronizeble) InnerList[index]; }
        }
        IEnumerator<ISynchronizeble> IEnumerable<ISynchronizeble>.GetEnumerator()
        {
            return GetSyncEnumerator();
        }

        private IEnumerator<ISynchronizeble> GetSyncEnumerator()
        {
            IEnumerator ie = base.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (ISynchronizeble)ie.Current;
            }

        }
    }
}