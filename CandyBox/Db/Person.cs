using BTDB.ODBLayer;

namespace testBTBD.Db
{
    public class Person 
    {
        [PrimaryKey(1)]
        public ulong Id { get; set; }
        public string Name { get; set; }
        [SecondaryKey("Age")]
        public ulong Age { get; set; }
    }
    
    public interface IPersonTable : IRelation
    {
        void Insert(Person person);
        bool RemoveById(ulong id);
        Person FindById(ulong id);
    }
}