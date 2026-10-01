using static System.Console;
namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {

            

            //get current directory
            string dir = Directory.GetCurrentDirectory();
            string filepath = dir + "\\results.txt";
            try {
                string[] fileContents = File.ReadAllLines(filepath);

                int totalPoints = 0, points = 0, result = 0;

                // Ex 2 0 use of foreach
                foreach (string line in fileContents) {


                    result = Convert.ToInt32(line);
                    
                    if (result >= 90) points = 100;
                    else if (result >= 80) points = 88;
                    else if (result >= 70) points = 77;
                    else if (result >= 60) points = 66;
                    else if (result >= 50) points = 56;
                    else if (result >= 40) points = 46;
                    else if (result >= 30) points = 37;
                    else points = 0;

                    totalPoints += points;
                }

                File.AppendAllText(filepath, Environment.NewLine + "Total Points: " + totalPoints.ToString());


            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}


