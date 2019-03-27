using DAL;
using Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RopaBLL
    {
        public static bool Guardar(Ropas ropa)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.Ropas.Add(ropa) != null)
                {
                    db.SaveChanges();
                    paso = true;

                    db.Dispose();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Contexto db = new Contexto();
                var ropa = db.Ropas.Find(id);
                if (ropa != null)
                {
                    db.Entry(ropa).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                    {
                        paso = true;
                        db.Dispose();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(Ropas ropa)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(ropa).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    paso = true;
                    db.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static Ropas Buscar(int id)
        {
            Contexto db = new Contexto();
            Ropas ropa = new Ropas();
            try
            {
                ropa = db.Ropas.Find(id);

                db.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return ropa;
        }

        public static List<Ropas> GetList(Expression<Func<Ropas, bool>> ropa)
        {
            List<Ropas> list = new List<Ropas>();
            Contexto db = new Contexto();
            try
            {
                list = db.Ropas.Where(ropa).ToList();
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

    }
}
