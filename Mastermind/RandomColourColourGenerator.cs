using System;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class RandomColourColourGenerator : IRandomColourGenerator
    {
        private readonly Colour[] _selectedColours;

        public RandomColourColourGenerator(int numOfColours)
        {
            _selectedColours = new Colour[numOfColours];
        }
        
        public Colour[] Generate()
        {
            var random = new Random();
            var type = typeof(Colour);

            var enumValues = type.GetEnumValues();

            for (var i = 0; i < _selectedColours.Length; i++)
            {
                var randomChosenIndex = random.Next(0, enumValues.Length);
                
                // This can never be null, because the index is within the bounds of
                // the `enumValues` array.
                // ReSharper disable once PossibleNullReferenceException
                _selectedColours[i] = (Colour) enumValues.GetValue(randomChosenIndex);
            }

            return _selectedColours;
        }
    }
}