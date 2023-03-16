// See https://aka.ms/new-console-template for more information


using System.Collections;

namespace markiing 
{
    public class TGTInstitute
    {
        public static void Main()
        {
            //Console.WriteLine("Hello, World!");
            ScriptDistributor sDistributor = new ScriptDistributor();
            sDistributor.getData();
            sDistributor.displayResults();
        }
    }

    class ScriptDistributor
    {
        private int totalMarks;
        private int numberOfScripts;
        private int numberOfQuestions;
        private int subtotalPerQuestion;
        private int numberOfTeachers;
        private int scriptsPerTeacher;
        private double timePerLecturer;
        private string? timeUnit;
        private int timeEstimated;

        public ScriptDistributor()
        {
          //numberOfScripts = 0;
            numberOfQuestions = 0;
            subtotalPerQuestion = 0;
            numberOfTeachers = 0;
            scriptsPerTeacher = 0;
            timeEstimated = 0;
            timePerLecturer = 0.0;
            totalMarks = 0;
            timeUnit = null;
        }

        public void getData()
        {
            while (true) 
            {
                Console.WriteLine("Please enter the number of scripts");
                //get number
                numberOfScripts = int.Parse(Console.ReadLine());

                //send for cal

                if (numberOfScripts <= 0)
                {
                    continue;
                }
                else 
                {
                    break;
                }
            }

            while (true) 
            {
                Console.WriteLine("Please enter the number of questions ");
                //get number
                numberOfQuestions = int.Parse(Console.ReadLine());
                if (numberOfQuestions<=0 || numberOfQuestions>10)
                {
                    continue;
                }
                else 
                {
                    break;
                }
            }
            //send for cal

            while (true) 
            {
                Console.WriteLine("Please enter the subtotal per question");
                //get number
                subtotalPerQuestion = int.Parse(Console.ReadLine());

                if (subtotalPerQuestion <= 0)
                {
                    continue;
                }
                else
                {
                    break;
                }
                
            }
                        timeEstimated = totalMarks;
            
            distributeScripts();
        }

        public int distributeScripts()
        {
            //spread Scripts
            //get number of teachers
            while (true) 
            {
                Console.WriteLine("Please enter the number of Lecturers");
                this.numberOfTeachers = int.Parse(Console.ReadLine());
                if (numberOfTeachers <=0)
                {
                    continue;
                }
                else 
                {
                    break;
                }
            }
            

            //divide all scripts to teachers-
            totalMarks = numberOfQuestions * subtotalPerQuestion * numberOfScripts;

            scriptsPerTeacher = this.numberOfScripts / numberOfTeachers;
            
            return scriptsPerTeacher;
        }

        private double getTime()
        {
            //each mark is one second
            double timeSeconds = this.totalMarks;
            timePerLecturer = timeSeconds/ numberOfTeachers;
            
            if (timePerLecturer >= 60)
            {
                timePerLecturer = timePerLecturer / 60;
                timeUnit = " mintutes";
                

                int reduction = 0;
                while (timePerLecturer>0)
                {
                    timePerLecturer-= 1;
                    reduction++;
                    if (timePerLecturer >0 && timePerLecturer <1) 
                    {
                        //Console.Write(timePerLecturer + " is the remainder");
                        if (timePerLecturer>0.99) 
                        {
                            timePerLecturer = timePerLecturer / 0.99;

                        }
                        break;
                    }
                }
                timePerLecturer = timePerLecturer + reduction;

                if (timePerLecturer >= 60)
                {
                    timePerLecturer=timePerLecturer / 60;
                    timeUnit = " hours";
                }
            }

            return timePerLecturer;
        }

        public void displayResults()
        {
            Console.WriteLine();
            getTime();
            Console.WriteLine("Scripts per lecturer");
            Console.WriteLine(scriptsPerTeacher);
            //time
            Console.WriteLine("Time per lecturer");
            Console.WriteLine((int)timePerLecturer + timeUnit);
        }
    }
}

