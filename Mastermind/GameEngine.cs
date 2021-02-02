#nullable enable
using System;
using System.Collections.Generic;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine : IGameEngine
    {
        private readonly IUserInput _userInput;
        private readonly IErrorHandler _consoleErrorHandler;
        private readonly UserInputArrayLengthValidator _userInputArrayLengthValidator;
        private readonly TurnCount _turnCount;
        private readonly WinningResult _winningResult;

        public GameEngine(IUserInput userInput, IErrorHandler consoleErrorHandler)
        {
            _userInput = userInput;
            _consoleErrorHandler = consoleErrorHandler;
            _userInputArrayLengthValidator = new UserInputArrayLengthValidator();
            _turnCount = new TurnCount();
            _winningResult = new WinningResult();
        }
        
        public Colours[]? TakeATurn()
        {
            // shouldn't be controlled by input/outputs
            // take in user input as parameter and remove while loop?
            while (true)
            {
                var userInput = _userInput.GetUserInput();
                
                if (userInput == UserOptions.Quit.ToString())
                {
                    return null;
                }

                try
                {
                    var userAnswer = ColoursParser.ParseFromString(userInput);
                    _userInputArrayLengthValidator.ValidateUserInput(userAnswer);

                    return userAnswer;
                }
                catch (ArgumentException e)
                {
                    _consoleErrorHandler.DisplayErrorMessage(e);
                }
            }
        }
    }
}


// sequence of parsers (ParseException) - 2 parsers (one for quit, one for colours)
// return something that tells the game to quit e.g. quit command (enum)
// parsing quit as a valid input - can still be an exception
// parsing colours as a valid guess input
// invalid inputs e.g. array length, invalid colour