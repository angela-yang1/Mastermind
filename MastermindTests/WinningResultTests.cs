using System;
using System.Collections.Generic;
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
        public void GivenCorrectColourAndIndex_ShouldReturnFourBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue };
            var actual = new List<ResultColours> 
                { ResultColours.Black, ResultColours.Black, ResultColours.Black, ResultColours.Black };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.Equal(result, actual);
        }
        
        [Fact]
        public void GivenTwoCorrectColourAndIndex_ShouldReturnTwoBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Green, Colours.Red, Colours.Orange };
            var actual = new List<ResultColours> 
                { ResultColours.Black, ResultColours.Black };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.Equal(result, actual);
        }
        
        [Fact]
        public void GivenTwoCorrectColoursWithIncorrectIndex_ShouldReturnTwoWhiteValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Red, Colours.Blue, Colours.Green, Colours.Orange };
            var actual = new List<ResultColours> 
                { ResultColours.White, ResultColours.White };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.Equal(result, actual);
        }
        
        // always checks  & adds black to first before white
        [Fact]
        public void GivenDuplicateColoursWithIncorrectIndex_ShouldReturnOneWhiteAndOneBlackValues()
        {
            var winningCondition = new WinningResult();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Blue, Colours.Green, Colours.Blue };
            var actual = new List<ResultColours> 
                { ResultColours.Black, ResultColours.Black, ResultColours.White };
            winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);

            var result = winningCondition.CreateWinningResult(userGuesses, _masterSelectedColours);
            
            Assert.Equal(result, actual);
        }
    }
}