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
        private readonly Colours[] _masterSelectedColours = 
            { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue };

        [Fact]
        public void GivenCorrectColourAndIndex_ShouldReturnTrue_ForFourBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
                
            Assert.True(result
                .All(c => c == ResultColours.Black) && result.Count == 4);
        }
        
        [Fact]
        public void GivenTwoCorrectColourAndIndex_ShouldReturnTrue_ForTwoBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Green, Colours.Red, Colours.Orange };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            Assert.True(result
                .All(c => c == ResultColours.Black) && result.Count == 2);
        }
        
        [Fact]
        public void GivenTwoCorrectColoursWithIncorrectIndex_ShouldReturnTrue_ForTwoWhiteValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Red, Colours.Blue, Colours.Green, Colours.Orange };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.True(result
                .All(c => c == ResultColours.White) && result.Count == 2);
        }
     
        [Fact]
        public void GivenDuplicateColoursWithIncorrectIndex_ShouldReturnOneWhiteAndOneBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Blue, Colours.Green, Colours.Blue };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            var blackCount = result.Count(c => c == ResultColours.Black);
            var whiteCount = result.Count(c => c == ResultColours.White);
            
            Assert.Equal(2,blackCount);
            Assert.Equal(1,whiteCount);
        }
    }
}