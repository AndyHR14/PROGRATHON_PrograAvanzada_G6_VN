using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PROGRATHON.Models;
using System;

namespace PROGRATHON.Data
{
    public class AppDbContext : DbContext
    {
        //Creo un constructor vacio
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Establcemos los modelos de datos.

        //      CREATE TABLE `u484426513_pac325`.`Producto` (
        //`Id` INT NOT NULL AUTO_INCREMENT,
        //`Nombre` VARCHAR(45) NOT NULL,
        //`Descripcion` VARCHAR(45) NOT NULL,
        //`Precio` DECIMAL NOT NULL,
        //`Cantidad` INT NOT NULL,
        //PRIMARY KEY(`Id`));
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


    }
}