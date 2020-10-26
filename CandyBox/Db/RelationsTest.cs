using System;
using BTDB.KVDBLayer;
using BTDB.ODBLayer;
using NUnit.Framework;

namespace testBTBD.Db
{
    public class RelationsTest: IDisposable
    {
        private IKeyValueDB _lowDb;
        private IObjectDB _db;

        [Test]
        public void ObjectDbTableUpgradeTest()
        {
            _lowDb = new InMemoryKeyValueDB();
            OpenDb();
        }
        
        [Test]
        public void Test()
        {
            using (var tr = _db.StartTransaction())
            {
                _db.Open(_lowDb, false);
                var creator = tr.InitRelation<IPersonTable>("Person");
                var personTable = creator(tr);
                personTable.Insert(new Person { Id = 2, Name = "admin", Age = 100 });
                tr.Commit();
            }
            ReopenDb();
        }

        public void Dispose()
        {
            _db.Dispose();
            _lowDb.Dispose();
        }
        
        void ReopenDb()
        {
            _db.Dispose();
            OpenDb();
        }
        
        void OpenDb()
        {
            _db = new ObjectDB();
            _db.Open(_lowDb, false, new DBOptions().WithoutAutoRegistration());
        }
    }
}