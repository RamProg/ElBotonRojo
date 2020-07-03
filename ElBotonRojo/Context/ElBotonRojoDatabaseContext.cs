using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElBotonRojo.Models;

namespace ElBotonRojo.Context
{
    public class ElBotonRojoDatabaseContext : DbContext
    {

        public ElBotonRojoDatabaseContext(DbContextOptions<ElBotonRojoDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

    }
}