using Microsoft.EntityFrameworkCore;
using Pix.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pix.Infra
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente("Geovane", "ge01", 50),
                new Cliente("Mariane", "ma01", 10),
                new Cliente("Jonas", "jo01", 5),
                new Cliente("Claudia", "cl01", 1)
            );
        }
    }
}
