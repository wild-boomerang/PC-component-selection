using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace Project
{
    public class ItemsRepository<T> where T : ComputerPart, new()
    {
        SQLiteConnection dataBase;
        public ItemsRepository(string fileName)
        {
            string dataBasePath = DependencyService.Get<ISQLite>().GetDataBasePath(fileName);
            dataBase = new SQLiteConnection(dataBasePath);
            dataBase.CreateTable<T>();
        }
        public IEnumerable<T> GetItems(computerParts whoIs, string condition1 = null, string condition2 = null)
        {
            List<T> items;
            if (condition1 == null)
            {
                items = (from i in dataBase.Table<T>() select i).ToList();
            }

            else
            {
                switch (whoIs)
                {
                    case computerParts.CASE:
                        items = (from i in dataBase.Table<T>()
                                         let _case = i as Case
                                         where _case.MotherboardFormFactor.Contains(condition1)
                                         select i).ToList();
                        break;
                    case computerParts.CPU:
                        items = (from i in dataBase.Table<T>() 
                                let cpu = i as CPU 
                                where cpu.Socket == condition1 
                                select i).ToList();
                        break;
                    case computerParts.HDD:
                        items = (from i in dataBase.Table<T>() 
                                let hdd = i as HDD 
                                where hdd.Manufacturer == condition1 
                                select i).ToList();
                        //return (from i in dataBase.Table<HDD>() where i.Manufacturer == condition1 select i).ToList();
                        //return (from i in dataBase.Table<T>() where FuncToDelegate(i, condition1) select i).ToList();
                        //TestDelegate testDelegate = FuncToDelegate;
                        //return dataBase.Table<T>().Where(i => FuncToDelegate(i, condition1));
                        //return dataBase.Table<T>().Where(i => i as HDD != null && i.Manufacturer == condition1);
                        //return (from i in dataBase.Table<T>() where (i as HDD).Manufacturer == condition1 select i).ToList();
                        break;
                    case computerParts.MOTHERBOARD:
                        items = (from i in dataBase.Table<T>() 
                                let motherboard = i as Motherboard 
                                where motherboard.Socket == condition1 
                                select i).ToList();
                        break;
                    case computerParts.POWERSUPPLY:
                        items = (from i in dataBase.Table<T>() 
                                let powerSupply = i as PowerSupply 
                                where powerSupply.Manufacturer == condition1 
                                select i).ToList();
                        break;
                    case computerParts.RAM:
                        items = (from i in dataBase.Table<T>() 
                                let ram = i as RAM 
                                where ram.Manufacturer == condition1 
                                select i).ToList();
                        break;
                    case computerParts.VIDEOCARD:
                        items = (from i in dataBase.Table<T>() 
                                let videocard = i as VideoCard 
                                where videocard.Manufacturer == condition1 
                                select i).ToList();
                        break;
                    default:
                        items = (from i in dataBase.Table<T>() 
                                select i).ToList();
                        break;
                }
            }

            foreach (var i in items)
                i.WhoIs = whoIs;

            return items;

            //return (from i in dataBase.Table<T>() where condition1 != null && (i as CPU).Socket == condition1 select i).ToList();
        }
        public T GetItem(int id)
        {
            return dataBase.Get<T>(id);
        }
        public int DeleteItem(int id)
        {
            return dataBase.Delete<T>(id);
        }
        public int SaveItem(T cpu)
        {
            if (cpu.Id1 != 0)
            {
                dataBase.Update(cpu);
                return cpu.Id1;
            }

            else
            {
                return dataBase.Insert(cpu);
            }
        }
    }

















    //public class ItemsRepository/*<T> where T : ComputerPart*/
    //{
    //    SQLiteConnection dataBase;
    //    public ItemsRepository(string fileName)
    //    {
    //        string dataBasePath = DependencyService.Get<ISQLite>().GetDataBasePath(fileName);
    //        dataBase = new SQLiteConnection(dataBasePath);
    //        dataBase.CreateTable<CPU>();
    //    }

    //    public IEnumerable<CPU> GetItems(string condition1)
    //    {
    //        return (from i in dataBase.Table<CPU>() where i.Manufacturer == condition1 select i).ToList();
    //    }

    //    public CPU GetItem(int id)
    //    {
    //        return dataBase.Get<CPU>(id);
    //    }

    //    public int DeleteItem(int id)
    //    {
    //        return dataBase.Delete<CPU>(id);
    //    }

    //    public int SaveItem(CPU cpu)
    //    {
    //        if (cpu.Id1 != 0)
    //        {
    //            dataBase.Update(cpu);
    //            return cpu.Id1;
    //        }

    //        else
    //        {
    //            return dataBase.Insert(cpu);
    //        }
    //    }
    //}
}
