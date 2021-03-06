﻿using DAL;
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
    public class InventarioRepositorio : Repositorio<Inventarios>
    {
        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Inventarios inventario = contexto.Inventarios.Find(id);

                if (inventario != null)
                {
                    contexto.Ropas.Find(inventario.RopaId).Inventario -= inventario.Cantidad;
                    contexto.Inventarios.Remove(inventario);
                }


                if (contexto.SaveChanges() > 0)
                { paso = true; }
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

        public override bool Guardar(Inventarios inventario)
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

        public override bool Modificar(Inventarios inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            InventarioRepositorio repositorio = new InventarioRepositorio();
            try
            {
                contexto.Entry(inventario).State = EntityState.Modified;
                Inventarios Ant = repositorio.Buscar(inventario.InventarioId);
                var Ropa = contexto.Ropas.Find(inventario.RopaId);

                var RopaAnt = contexto.Ropas.Find(Ant.RopaId);

                if (inventario.RopaId == Ant.RopaId)
                {
                    //RopaAnt.Inventario -= Ant.Cantidad;
                    //Ropa.Inventario += inventario.Cantidad;
                    Ropa.Inventario = inventario.Cantidad;

                }
                else
                {
                    //int dif = inventario.Cantidad - Ant.Cantidad;
                    Ropa.Inventario = inventario.Cantidad;
                }
                contexto.Entry(Ropa).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
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

        public override Inventarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inventarios inventario = new Inventarios();

            try
            {
                inventario = contexto.Inventarios.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inventario;
        }

        public override List<Inventarios> GetList(Expression<Func<Inventarios, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Inventarios> inventario = new List<Inventarios>();

            try
            {
                inventario = contexto.Inventarios.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inventario;
        }

    }
}