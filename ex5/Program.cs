using static System.Console;
namespace ex5 {
    internal class Program {
        static void Main(string[] args) {
            Write("Enter your name >>");
            string name = ReadLine();

            Write("Enter your student number >> ");
            string studentNumber = ReadLine();

            string[] subjects = new string[7];
            string[] levels = new string[7];
            string[] results = new string[7];
            int[] points = new int[7];

            for (int i = 0; i < 7; i ++) {
                Write($"Enter subject name {i+1} >> ");
                subjects[i] = ReadLine();

                Write($"Enter subject level for {subjects[i]} >> ");
                levels[i] = ReadLine();

                Write($"Enter subject result for {subjects[i]} >> ");
                results[i] = ReadLine();
            }

            int totalPoints = CalculatePoints(results, levels, points);

            DisplayResults(name, studentNumber, subjects, results, levels, points, totalPoints);

            WriteDetailsTofile(name,studentNumber,subjects,results,levels,points,totalPoints);

            ReadLine();
        }

        private static void DisplayResults(string name, string studentNumber, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints) {
            WriteLine($"Name: {name}");
            WriteLine($"Student Number: {studentNumber}");

            for (int i = 0; i < results.Length; i++) {
                WriteLine($"{subjects[i],15} {levels[i],10} {results[i],10} {points[i],10}");
            }
            Write($"Total Points : {totalPoints}");
        }

        private static int CalculatePoints(string[] data, string[] levels, int[] studentpoints) {
            int[] gradeBoundaries = { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryPoints = { 56, 46, 37, 28, 20, 12, 0, 0 };

            int totalPoints = 0, points = 0;

            for(int i = 0; i < data.Length; i++) {

                int result = Convert.ToInt32(data[i]);

                for(int j = 0; j < data.Length; j++) {
                    if(result >= gradeBoundaries[j]) {

                        points = levels[i].ToLower().Equals("h") ? higherPoints[j] : ordinaryPoints[j];
                        break;
                    }
                }
                studentpoints[i] = points;
            }
            Array.Sort(studentpoints);
            Array.Reverse(studentpoints);

            for (int i = 0; i < 6; i++) {
                totalPoints += studentpoints[i];
            }
            return totalPoints;


        }

        private static void WriteDetailsTofile(string name, string studentNumber, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints) {
            StreamWriter sw = new StreamWriter("Results.txt");
                
            sw.WriteLine($"Name: {name}");
            sw.WriteLine($"Student Number: {studentNumber}");

            for (int i = 0; i < results.Length; i ++) {
                sw.WriteLine($"{subjects[i],10} {levels[i],10} {subjects[i],10} {results[i],10} {points[i],10}");
            }
            sw.WriteLine($"Total Points: {totalPoints}");
            sw.Flush();
            sw.Close();

            WriteLine("WriteDetailsToFile complete");
        }
    }
}
