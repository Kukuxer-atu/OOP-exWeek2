namespace Ex3 {
    internal class Program {
        static void Main(string[] args) {



            string dir = Directory.GetCurrentDirectory();
            string filepath = dir + "\\results.txt";
            string[] fileContents = File.ReadAllLines(filepath);

            int totalPoints = CalculatePoints(fileContents);

            Console.WriteLine($"The total points are {totalPoints}");
        }
        // method which accepts an array of grades (assume higher level only) and calculates the points.
        private static int CalculatePoints(string[] data) {
            int[] gradeBoundaries = { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints =    { 100, 88, 77, 66, 56, 46, 37, 0 };

            int totalPoints = 0, points = 0, result = 0;
            foreach (string line in data) {


                result = Convert.ToInt32(line);

                for (int j = 0; j < gradeBoundaries.Length; j++) {
                    if (result >= gradeBoundaries[j]) {
                        points = higherPoints[j];
                        break;
                    }

                }
                totalPoints+= points;
            }
            return totalPoints;
        }
    }
}
