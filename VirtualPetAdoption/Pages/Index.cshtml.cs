using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages

{

    public class IndexModel : PageModel

    {
        //Create a new instance of the database context - PetAdoptionContext
        private readonly PetAdoptionContext _context;

        // Initialize the new database context object that we just created using the
        // the pet adoption context that was created by the service in our application
        //container when the application started. Now we can work the database
        // in the code for this class.
        public IndexModel(PetAdoptionContext context)

        {
            _context = context;
        }

        // Attributes of the class - variables that store information about the class
        //Name is the name of the person who is looking for pet
        [BindProperty]

        //Energy preference is the energy level they want to see in a pet
        public string Name { get; set; } = "";

        // This attribute is the Pet object that the user is matched with
        [BindProperty]

        public int EnergyPreference { get; set; }

        public Pet? Match { get; set; }

        // OnGet is called automatically when the page is loaded
        // For this page we don't have to do anything when it is loaded so OnGet is empty
        public void OnGet()

        {

        }

        // OnPost method gets called when the user clicks submit on the form
        public void OnPost()

        {
            // The best match is the pet with the closest energy level.
            // Returns a resultset with a list of pets from the database
            //Orders the pets by the closest match for energy level
            // by subtracting the Pet's energy level from the User's preferred energy level,
            // then grab that first pet in the resultset since they are the best match.
            Match = _context.Pets
                .OrderBy(p => Math.Abs(p.EnergyLevel - EnergyPreference))
                .First();
        }
    }
}