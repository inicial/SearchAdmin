using System.Data.SqlClient;

namespace CruiseSearchAdmin.Entities.SyncModel
{
    public interface ISynchronizeble
    {
        SyncRecord Synchronize(SyncBaseProccessor baseProccessor,SynchronyzeMethod sMethod);
        int SyncItemType { get; }
        int? ID { get; set; }
        string Text { get; set; }
        void RemoveSyncBinding(Synchronizer synchronizer);
        bool ItemChecked { get; set; }
    }

    public enum SynchronyzeMethod
    {
        Insert,Update
    }
}