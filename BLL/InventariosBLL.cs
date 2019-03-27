using DAL;
using Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InventariosBLL
    {

        public static bool Guardar(Inventarios inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Inventarios.Add(inventario) != null)
                {
                    contexto.Ropas.Find(inventario.RopaId).Inventario += inventario.Cantidad;
                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Inventarios inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            try
            {
                contexto.Entry(inventario).State = EntityState.Modified;

                Inventarios ant = repositorio.Buscar(inventario.InventarioId);
                var Ropa = contexto.Ropas.Find(inventario.RopaId);
                var RopaAnt = contexto.Ropas.Find(ant.RopaId);

                if (inventario.RopaId != ant.RopaId)
                {
                    Ropa.Inventario += inventario.Cantidad;
                    RopaAnt.Inventario -= ant.Cantidad;
                }
                {
                    int diferencia = inventario.Cantidad - ant.Cantidad;
                    Ropa.Inventario += diferencia;
                }


                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                Inventarios inventarios = contexto.Inventarios.Find(id);
                contexto.Ropas.Find(inventarios.RopaId).Inventario += inventarios.Cantidad;

                contexto.Inventarios.Remove(inventarios);
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

    }
}
