﻿using Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Contexto: DbContext
    {
        public DbSet<Ropas> Ropas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<FacturasDetalles> FacturasDetalles { get; set; }
        public Contexto() : base("ConStr")
        {

        }
    }
}
