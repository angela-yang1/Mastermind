using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class ColourMatchResultTests
    {
        private readonly Colour[] _masterSelectedColours = 
            { Colour.Blue, Colour.Green, Colour.Yellow, Colour.Blue };

        [Fact]
        public void GivenCorrectColourAndIndex_ShouldReturnFourBlackValues()
        {
            var colourMatchResult = new ColourMatchResult();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Green, Colour.Yellow, Colour.Blue };
            colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);

            var result = colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);
                
            Assert.True(result
                .All(c => c == ResultColour.Black) && result.Count == 4);
        }
        
        [Fact]
        public void GivenTwoCorrectColourAndIndex_ShouldReturnTwoBlackValues()
        {
            var colourMatchResult = new ColourMatchResult();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Green, Colour.Red, Colour.Orange };
            colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);
            
            var result = colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);

            Assert.True(result
                .All(c => c == ResultColour.Black) && result.Count == 2);
        }
        
        [Fact]
        public void GivenTwoCorrectColoursWithIncorrectIndex_ShouldReturnTwoWhiteValues()
        {
            var colourMatchResult = new ColourMatchResult();
            var userGuesses = new[] 
                { Colour.Red, Colour.Blue, Colour.Green, Colour.Orange };
            colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);

            var result = colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);
            
            Assert.True(result
                .All(c => c == ResultColour.White) && result.Count == 2);
        }
     
        [Fact]
        public void GivenDuplicateColoursWithIncorrectIndex_ShouldReturnOneWhiteAndOneBlackValues()
        {
            var colourMatchResult = new ColourMatchResult();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Blue, Colour.Green, Colour.Blue };
            colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);

            var result = colourMatchResult.CreateResult(_masterSelectedColours, userGuesses);
            var blackCount = result.Count(c => c == ResultColour.Black);
            var whiteCount = result.Count(c => c == ResultColour.White);
            
            Assert.Equal(2,blackCount);
            Assert.Equal(1,whiteCount);
        }
    }
}