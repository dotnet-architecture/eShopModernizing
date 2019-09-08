using System;
using System.Linq;

namespace eShopModernizedMVC.Models
{
    public class CatalogItemHiLoGenerator
    {
        private const int HiLoIncrement = 10;
        private int _sequenceId = -1;
        private int _remainningLoIds = 0;
        private object sequenceLock = new object();

        public int GetNextSequenceValue(CatalogDBContext db)
        {
            lock (sequenceLock)
            {
                if (_remainningLoIds == 0)
                {
                    var rawQuery = db.Database.SqlQuery<Int64>("SELECT NEXT VALUE FOR catalog_hilo;");
                    _sequenceId = (int)rawQuery.Single();
                    _remainningLoIds = HiLoIncrement - 1;
                    return _sequenceId;
                }
                else
                {
                    _remainningLoIds--;
                    return ++_sequenceId;
                }
            }
        }
    }
}