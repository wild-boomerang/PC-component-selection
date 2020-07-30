using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Database<T> where T: ComputerPart, new()
    {
        public ItemsRepository<T> itemDatabase;
        public ItemsRepository<T> ItemDatabase
        {
            get
            {
                if (itemDatabase == null)
                {
                    itemDatabase = new ItemsRepository<T>(App.DATABASE_NAME);
                }

                return itemDatabase;
            }
        }
    }
}
