namespace WebApplication3.Models
{
    public class LotteryService : ILotteryService
    {
        private Random rnd = new Random();
        public string GetWinningNumber()
        {
            string result = "";

            for (int i = 0; i < 7; i++)
            result += rnd.Next(0, 10);
            return result;
        }
    }
}