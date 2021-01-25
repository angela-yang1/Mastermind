using System;
using Mastermind.Enums;

namespace Mastermind
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Colours[] _selectedColours = new Colours[4];

        public Colours[] Generate()
        {
            var random = new Random();
            var type = typeof(Colours);

            var enumValues = type.GetEnumValues();

            for (var i = 0; i < 4; i++)
            {
                var randomChosenIndex = random.Next(0, enumValues.Length);
                _selectedColours[i] = (Colours)enumValues.GetValue(randomChosenIndex);
            }

            return _selectedColours;
        }
    }
}