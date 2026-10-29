using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;


namespace VirtualPetAdoption.Data

{
    public class PetAdoptionContext : DbContext
    {
        //Constructor - method that creates a new PetAdoptionContext object - a new DB Content
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options)

            : base(options)

        {

        }

        //Attribute - variable that stores data about the object
        //This attribute stores a database set, which is a collection, that holds
        // pets (pet objects)
        public DbSet<Pet> Pets { get; set; }

        //Method that is unique to the DBContext - it allows you to set a data model
        //that represents the table in the database and the data in the table.
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Pet>().HasData(

                new Pet { Id = 1, Name = "Fluffy", Species = "Cat",
                    Description = "A calm cat who enjoys naps.",
                    Emoji = "", EnergyLevel = 2 },
                new Pet { Id = 2, Name = "Rex", Species = "Dog",
                    Description = "A dog who loves to play fetch.",
                    Emoji = "", EnergyLevel = 5 },
                new Pet { Id = 3, Name = "Nibbles", Species = "Rabbit",
                    Description = "A friendly rabbit with medium energy.",
                    Emoji = "", EnergyLevel = 3 }
            );
        }
    }
}