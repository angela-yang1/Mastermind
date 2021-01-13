using System;
using Mastermind.Data;

namespace Mastermind
{
    public class RandomGenerator : IRandomGenerator
    {
        public readonly Colours[] SelectedColours = new Colours[4];

        public Colours[] Generate()
        {
            var random = new Random();
            var type = typeof(Colours);

            var enumValues = type.GetEnumValues();

            for (var i = 0; i < 4; i++)
            {
                var randomChosenIndex = random.Next(0, enumValues.Length);
                SelectedColours[i] = (Colours)enumValues.GetValue(randomChosenIndex);
            }

            return SelectedColours;
        }
    }
}