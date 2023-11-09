using System;

namespace RandomRoll
{
    public class GetRandomRoll
    {
        public int getRandomRoll(int diceNumber, int sideNumber)
        {
            System.Random rnd = new Random();
            int dieTotal = 0;
            for (int i = 0; i < diceNumber; i++)
            {
                dieTotal += rnd.Next(1, sideNumber);
            }
            return dieTotal;
        }
    }
}