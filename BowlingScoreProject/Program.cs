namespace BowlingScoreProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingScoreCounter bowlingScoreCounter = new BowlingScoreCounter();

            // Get input per frame
            bowlingScoreCounter.ComputeFromInput();

            // Print output per frame
            bowlingScoreCounter.PrintTotal();
        }
    }
}
