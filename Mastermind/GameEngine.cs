using System;
using System.ComponentModel;
using Mastermind.ColoursData;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly IUserInput _userInput;
        private readonly UserInputArrayLengthValidator _userInputArrayLengthValidator;

        public GameEngine(IUserInput userInput)
        {
            _userInput = userInput;
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
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}