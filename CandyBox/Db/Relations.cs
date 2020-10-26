using System;
using BTDB.KVDBLayer;
using BTDB.ODBLayer;
using NUnit.Framework;

namespace testBTBD.Db
{
    public class Relations
    {
        IKeyValueDB kvDb = new InMemoryKeyValueDB();
        IObjectDB db = new ObjectDB();
        Func<IObjectDBTransaction, IPersonTable> creator;
        public void StartRelationTransaction()
        {
            using (var tr = db.StartTransaction())
            {
                db.Open(kvDb, false);
                creator = tr.InitRelation<IPersonTable>("Person");
                var personTable = creator(tr);
                personTable.Insert(new Person { Id = 2, Name = "admin", Age = 100 });
                tr.Commit();
            }
        }
        public Person LogAllPersonName()
        {
            using (var tr = db.StartTransaction())
            {
                db.Dispose();
                var personTable = creator(tr);
                return personTable.FindById(2);
            }
        }
    }
}