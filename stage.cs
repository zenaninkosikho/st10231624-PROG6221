using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class stage
    {
        public static void Main()
        {
            //creates an instance of recipe
            recipe newRecipe = new recipe();
            
            //functions give you each step to deal for recipe
            newRecipe.writeRecipe();
            newRecipe.showRecipe();
            newRecipe.showMenu();
        }
    }
}
