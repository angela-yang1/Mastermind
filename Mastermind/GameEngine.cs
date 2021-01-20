using System;
using System.ComponentModel;
using Mastermind.ColoursData;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly IUserInput _userInput;
        private readonly IErrorHandler _consoleErrorHandler;
        private readonly UserInputArrayLengthValidator _userInputArrayLengthValidator;

        public GameEngine(IUserInput userInput, IErrorHandler consoleErrorHandler)
        {
            _userInput = userInput;
            _consoleErrorHandler = consoleErrorHandler;
            _userInputArrayLengthValidator = new UserInputArrayLengthValidator();
        }

        public Colours[] GetUserAnswer()
        {
            while (true)
            {
                var userInput = _userInput.GetUserInput();
                try
                {
                    var userAnswer = ColoursParser.ParseFromString(userInput);
                    _userInputArrayLengthValidator.ValidateUserInput(userAnswer);
                    return userAnswer;
                }
                catch(ArgumentException e)
                {
                    _consoleErrorHandler.DisplayErrorMessage(e);
                }
            }
        }
    }
}