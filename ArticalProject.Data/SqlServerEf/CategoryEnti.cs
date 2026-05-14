using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wateen12148ArticalProject.Core;

namespace wateen12148ArticalProject.Data.AqlServerEF
{
   public class CategoryEnti : IDataHelper<Category>
    {
        private DBContext db;
        private Category _table;

        public CategoryEnti()
        {
            db = new DBContext();
        }
        public int Add(Category table)
        {
            if (db.Database.CanConnect())
            {
                db.Category.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.Category.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Category table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Category.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Category Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Category> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Category.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Category> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Category> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(x => x.Name.Contains(SerachItem)
                || x.Id.ToString().Contains(SerachItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
