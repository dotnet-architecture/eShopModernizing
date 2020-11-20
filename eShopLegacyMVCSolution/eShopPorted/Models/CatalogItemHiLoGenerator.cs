using eShopLegacyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyMVC.Models
{
    public class CatalogItemHiLoGenerator
    {
        private const int HiLoIncrement = 10;
        private int sequenceId = -1;
        private int remainningLoIds = 0;
        private object sequenceLock = new object();

        public int GetNextSequenceValue(CatalogDBContext db)
        {
            lock (sequenceLock)
            {
                if (remainningLoIds == 0)
                {
                    var rawQuery = db.Database.SqlQuery<Int64>("SELECT NEXT VALUE FOR catalog_hilo;");
                    sequenceId = (int)rawQuery.Single();
                    remainningLoIds = HiLoIncrement - 1;
                    return sequenceId;
                }
                else
                {
                    remainningLoIds--;
                    return ++sequenceId;
                }
            }
        }
    }
}