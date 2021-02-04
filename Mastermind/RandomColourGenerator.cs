using System;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class RandomColourGenerator : IRandomGenerator
    {
        private readonly Colour[] _selectedColours;

        public RandomColourGenerator(int numOfColours)
        {
            _selectedColours = new Colour[numOfColours];
        }
        
        public Colour[] Generate()
        {
            var random = new Random();
            var type = typeof(Colour);

            var enumValues = type.GetEnumValues();

            for (var i = 0; i < Constants.NumberOfColours; i++)
            {
                var randomChosenIndex = random.Next(0, enumValues.Length);
                _selectedColours[i] = (Colour)enumValues.GetValue(randomChosenIndex);
            }

            return _selectedColours;
        }
    }
}