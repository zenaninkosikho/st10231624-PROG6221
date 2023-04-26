// See https://aka.ms/new-console-template for more information
using System.Collections;

public class recipe
{
    //names of ingredients
    public string[] Inames { get; set; }

    //quantities of ingredients
    public double[] Iquantities { get; set; }
    
    //scaled quantities  of ingredients
    public double[] IscaledQuantities { get; set; }
    
    //stepDescriptions of recipe
    public  string[] Idescriptions { get; set; }

    //integer counts the number of elements in all parallel arrays
    public int listPoint { get; set; }

    //different units of measure
    private string[] unitOfMeasure = { "ml", "l", "g", "Kg", "teaspoons", "spoons", "units" };
    
    //chosen units for each added ingredients
    private int[] choiceUnits { get; set; }
  

    public recipe()
    {
        
        Inames = new string[50];
        
        Iquantities = new double[50];
        IscaledQuantities = new double[50];
        Idescriptions = new string[50];
        choiceUnits = new int[50];
        listPoint = 6;
    }
    
    //function shows the remaining options at the end of entering a recipe
    public void showMenu()
    {
        //enter the recipe
        //allows you to scale
        //reverse scale
        //options are looped to allow continuous selection
        while (true)
        {
            Console.WriteLine("1.Scale up");
            Console.WriteLine("2.Restore scale");
            Console.WriteLine("3.Re-enter recipe");
            Console.WriteLine("4.Exit");

            //variable takes the value of the taken choice
            int Ichoice;
            while (true)
            {
                //variable stores entered string before parsing
                string choice = Console.ReadLine();
                
                //check the validy of user entry
                if (checkForLetters(choice))
                {
                    Console.WriteLine("Only have numbers");
                    continue;
                }
                else
                {
                    Ichoice = int.Parse(choice);

                    if (Ichoice >= 1 || Ichoice <= 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter between 1-3");
                        continue;
                    }
                }
            }

            //variable stores the scale a user wants
            double loggedScale;

            //variable monitors to see if user selected the exit option
            Boolean hasQuit = false;

            //manages the menu
            switch (Ichoice)
            {
                case 1:
                    //enter scale
                    Console.WriteLine("Enter scale");

                    //check the validy of user entry
                    string tscale;
                    double Iscale;

                    while (true)
                    {
                        tscale = Console.ReadLine();
                        if (checkForLetters(tscale))
                        {
                            Console.WriteLine("Only have numbers");
                            continue;
                        }
                        else
                        {
                            Iscale = double.Parse(tscale);
                            break;
                        }
                    }

                    //assign logged scale
                    //scale
                    scaleRecipe(Iscale);
                    showScaledRecipe();
                    break;

                case 2:
                    //unscale or divide
                    //divide by loggedScale
                    showRecipe();
                    break;

                case 3:
                    this.clearAllLists();
                    this.writeRecipe();
                    this.showRecipe();
                    this.showMenu();    
                    break;

                case 4:
                    //showRe
                    hasQuit = true;
                    break;

                default:
                    break;
            }

            if (hasQuit)
                break;
        }
    }

    //takes the user through the process of developing the recipe
    public void writeRecipe()
    {
        //temporily stores an ingredient
        string stringIngred;
        Console.WriteLine("your recipe".ToUpper());
        Console.WriteLine();
        Console.WriteLine("Please enter the number of ingredients".ToUpper());

        //test this against containing a letter.
        while (true)
        {
            stringIngred = Console.ReadLine();
            
            if (checkForLetters(stringIngred))
            {
                Console.WriteLine("Only have numbers");
                continue;
            }
            else
            {
                break;
            }

        }


        //enter the ingredients based on the number of ingredients
        int ingredients = int.Parse(stringIngred) - 1;

        //monitors the number of loops
        int cycles;
        Console.WriteLine();

        /*loop enters ingredients of a recipe*/
        for (cycles = 0; cycles <= ingredients; cycles++)
        {
            Console.WriteLine("please enter ingredient:" + (cycles + 1));
            Console.WriteLine("Name:");
            string Iname = Console.ReadLine();
            this.Inames[listPoint] = Iname;

            Console.WriteLine("Quantity:");
            //guard against letters;
            string Iquantities;

            while (true)
            {
                Iquantities = Console.ReadLine();
                if (checkForLetters(Iquantities))
                {
                    Console.WriteLine("Only have numbers");
                    continue;
                }
                else
                {
                    break;
                }

            }

            this.Iquantities[listPoint] = int.Parse(Iquantities);
            this.IscaledQuantities[listPoint] = int.Parse(Iquantities);

            //sets the unit of measure for the recipe
           
            Console.WriteLine("Unit of Measure: enter");
            Console.WriteLine("1-millilitres");
            Console.WriteLine("2-litres");
            Console.WriteLine("3-grams");
            Console.WriteLine("4-kilograms");
            Console.WriteLine("5-teaspoons");
            Console.WriteLine("6-spoons");
            Console.WriteLine("7-units");

            //check the validy of user entry
            string choice;
            while (true)
            {
                choice = Console.ReadLine();
                if (checkForLetters(choice))
                {
                    Console.WriteLine("Only have numbers");
                    continue;
                }
                else
                {
                    int Intchoice = this.choiceUnits[listPoint]
                                 = int.Parse(choice) - 1;
                    if (Intchoice >= 0 && Intchoice <= 6)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter between 1 & 7");
                        continue;
                    }
                }
            }
            Console.WriteLine();

            //add this to 2 lists
            //list 1 to keep originals and the other to keep altered
            listPoint++;
        }

        //check the validy of user entry
        Console.WriteLine("Number of steps:");
        
        //stores the string number of steps before parsing to int
        string stringsteps;
        int steps;
        while (true)
        {
            stringsteps = Console.ReadLine();
            if (checkForLetters(stringsteps))
            {
                Console.WriteLine("Only have numbers");
                continue;
            }
            else
            {
                steps = int.Parse(stringsteps) - 1;
                if (steps < 1)
                {
                    Console.WriteLine("Enter at least 1 step");
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        //later enter an actual value
        this.getDescription(steps);
    }

    //gets the number of steps then loads their descriptions into the relevant array
    public void getDescription(int stringSteps)
    {
        int steps = stringSteps;
        int sublistPoint = 0;
        //loop through descriptions
        ArrayList stepList = new ArrayList();

        //tracks the number of loops 
        int subCycles = 0;
        //repeatedly takes a description based on the number of steps
        Console.WriteLine();
        for (subCycles = 0; subCycles <= steps; subCycles++)
        {
            Console.WriteLine("please enter description of step " + (subCycles + 1));
            string stepDescription = Console.ReadLine();
            this.Idescriptions[subCycles] = stepDescription;

        }
        Console.WriteLine();

    }

    //check the validy of user string
    public Boolean checkForLetters(string wordSubject)
    {
        //store the conclusion of an entered string 
        Boolean hasLetter;

        //track the character a string is compared against
        int runner = 0;

        //stores the characters to be searched in a string 
        string[] letters =
            {"q","w","e","r","t","y","u","i","o","p","a",
                 "s","d","f","g","h","j","k","l","z","x","c",
                 "v","b","n","m","~","!","@","#","$","%","^","&","*","(",")","_","+","=","-","{","}","[","]","|","/","?" };

        //loops through each letter to see if a string has it
        for (; ; )
        {
            if (wordSubject.Contains(letters[runner]))
            {
                
                hasLetter = true;
                break;
            }
            else if (!wordSubject.Contains(letters[runner]) && runner == 46)
            {
                
                hasLetter = false;
                break;
            }
            runner++;
        }

        return hasLetter;
    }

    //scales quantities of a recipe by a certain value
    public void scaleRecipe(double scaleValue)
    {
        //multiply each value in array IscaledQuantities[] by scaleValue
        int runner = 0;
        for (; runner <= listPoint - 1;)
        {
            IscaledQuantities[runner] = (IscaledQuantities[runner] * scaleValue);
            runner++;
        }
    }

    //function to clear all lists
    public void clearAllLists()
    {
        
        //re-initialization of all arrays that were used inorder to restart a program
        Inames = new string[50];
        Iquantities = new double[50];
        IscaledQuantities = new double[50];
        Idescriptions = new string[50];
        choiceUnits = new int[50];
        listPoint = 6;
    }

    //shows the recipe entered by a user
    public void showRecipe()
    {
        //track the loop number
        int runPoint = 0;
        
        //marks the index to add data into in an array
        int listsize = listPoint - 1;

        Console.WriteLine("-----------------RECIPE-------------------");
        Console.WriteLine("Ingredients".ToUpper());

        //loops through parallel arrays and displays info
        while (runPoint <= listsize)
        {
            //shows only ingredients with quantities above 0
            if (Iquantities[runPoint] > 0) 
            {
                Console.Write((runPoint + 1) + ". " + Inames[runPoint] + "- ");
                Console.WriteLine(Iquantities[runPoint] + " " + this.unitOfMeasure[choiceUnits[runPoint]]);
            }

            runPoint++;

            
        }

        //tracks the point information is to be displayed from the parallel arrays
        runPoint = 0;
        listsize = listPoint - 1;
        Console.WriteLine();
        Console.WriteLine("STEPS");

        //list all descriptions
        while (true)
        {
            Console.WriteLine((runPoint + 1) + ". " + Idescriptions[runPoint]);

            if (Idescriptions[runPoint + 1] == null)
            {
                break;
            }
            runPoint++;
            
        }

        Console.WriteLine("-----------------FINISHED-----------------");


    }

    //performs the exact same function as showRecipe() function
    
    //excepts accommodates scaled quantities
   
    public void showScaledRecipe()
    {
        int runPoint = 0;
        int listsize = listPoint - 1;

        Console.WriteLine("-----------------RECIPE-------------------");
        Console.WriteLine("Ingredients".ToUpper());
        while (runPoint <= listsize)
        {
            if (Iquantities[runPoint] > 0) 
            {
                Console.Write((runPoint + 1) + ". " + Inames[runPoint] + "- ");
                Console.WriteLine(IscaledQuantities[runPoint] + " " + this.unitOfMeasure[choiceUnits[runPoint]]);

            }

            runPoint++;

            //list all descriptions
        }


        runPoint = 0;
        listsize = listPoint - 1;
        Console.WriteLine();
        Console.WriteLine("STEPS");
        while (true)
        {
            Console.WriteLine((runPoint + 1) + ". " + Idescriptions[runPoint]);

            if (Idescriptions[runPoint + 1] == null)
            {
                break;
            }
            runPoint++;
            //list all descriptions
        }

        Console.WriteLine("-----------------FINISHED-----------------");
    }
}
//quit at any point in time
//clear screen with every new step