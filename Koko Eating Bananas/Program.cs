using System;
using System.Linq;

namespace Koko_Eating_Bananas
{
  class Program
  {
    static void Main(string[] args)
    {
      var piles = new int[] { 30, 11, 23, 4, 20 };
      int h = 6;
      Program p = new Program();
      var result = p.MinEatingSpeed(piles, h);
      Console.WriteLine(result);
    }

    public int MinEatingSpeed(int[] piles, int h)
    {
      int left = 1; // you have to eat atleast one banana
      int right = piles.Max(); // based on the input constaint max no of bananas in a pile

      while(left < right)
      {
        int canEatNoOfBanansInOneHOur = left + (right - left) / 2;
        int hourSum = 0;
        foreach (int noOfBanansInaPile in piles)
        {
          if (noOfBanansInaPile < canEatNoOfBanansInOneHOur) // if no of banans are less in a pile than the eating speed per hour, we need only one hour.
          {
            hourSum += 1;
          }
          else
          {
            int noOfHour = (noOfBanansInaPile % canEatNoOfBanansInOneHOur) == 0 ?
                            (noOfBanansInaPile / canEatNoOfBanansInOneHOur) :
                            1 + (noOfBanansInaPile / canEatNoOfBanansInOneHOur);
            hourSum += noOfHour;
          }
        }
        if (hourSum > h) // eating slow
        {
          left = canEatNoOfBanansInOneHOur + 1;
        }
        else
        {
          // valid eating speed but try a lower eating rate for minimum rate value as we try to complete in given h or nearest to h.
          right = canEatNoOfBanansInOneHOur;
        }
      }

      return left;
    }
  }
}
