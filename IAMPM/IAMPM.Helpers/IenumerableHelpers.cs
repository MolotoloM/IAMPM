using System;
using System.Collections.Generic;
using System.Linq;

namespace IAMPM.Helpers
{
    public static class IenumerableHelpers
    {
        public static T GetRandom<T>(this IEnumerable<T> source, string errorMessage = null)
        {
            T[] cardsArray = source.ToArray();

            if (cardsArray.Length == 0)
            {
                throw new ArgumentNullException(errorMessage);
            }

            int randNumber = new Random().Next(cardsArray.Length - 1);
            T chosenCard = cardsArray[randNumber];
            return chosenCard;
        }
    }
}