using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class WinningResultTests
    {
        private readonly Colour[] _masterSelectedColours = 
            { Colour.Blue, Colour.Green, Colour.Yellow, Colour.Blue };

        [Fact]
        public void GivenCorrectColourAndIndex_ShouldReturnTrue_ForFourBlackValues()
        {
            var winningCondition = new ResultOutput();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Green, Colour.Yellow, Colour.Blue };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
                
            Assert.True(result
                .All(c => c == ResultColour.Black) && result.Count == 4);
        }
        
        [Fact]
        public void GivenTwoCorrectColourAndIndex_ShouldReturnTrue_ForTwoBlackValues()
        {
            var winningCondition = new ResultOutput();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Green, Colour.Red, Colour.Orange };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            Assert.True(result
                .All(c => c == ResultColour.Black) && result.Count == 2);
        }
        
        [Fact]
        public void GivenTwoCorrectColoursWithIncorrectIndex_ShouldReturnTrue_ForTwoWhiteValues()
        {
            var winningCondition = new ResultOutput();
            var userGuesses = new[] 
                { Colour.Red, Colour.Blue, Colour.Green, Colour.Orange };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.True(result
                .All(c => c == ResultColour.White) && result.Count == 2);
        }
     
        [Fact]
        public void GivenDuplicateColoursWithIncorrectIndex_ShouldReturnOneWhiteAndOneBlackValues()
        {
            var winningCondition = new ResultOutput();
            var userGuesses = new[] 
                { Colour.Blue, Colour.Blue, Colour.Green, Colour.Blue };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            var blackCount = result.Count(c => c == ResultColour.Black);
            var whiteCount = result.Count(c => c == ResultColour.White);
            
            Assert.Equal(2,blackCount);
            Assert.Equal(1,whiteCount);
        }
    }
}