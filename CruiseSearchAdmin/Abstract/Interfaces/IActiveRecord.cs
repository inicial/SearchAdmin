namespace CruiseSearchAdmin.Entities
{
    public interface IActiveRecord
    {
        void Insert();
        void Update();
        void Delete();
    }
}