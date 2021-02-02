#nullable enable
using System;
using System.Collections.Generic;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine : IGameEngine
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly IErrorHandler _consoleErrorHandler;
        private readonly InputArrayLengthValidator _inputArrayLengthValidator;

        public GameEngine(IInputReceiver inputReceiver, IErrorHandler consoleErrorHandler)
        {
            _inputReceiver = inputReceiver;
            _consoleErrorHandler = consoleErrorHandler;
            _inputArrayLengthValidator = new InputArrayLengthValidator();
        }
        
        public Colours[]? TakeATurn()
        {
            // shouldn't be controlled by input/outputs
            // take in user input as parameter and remove while loop?
            while (true)
            {
                var userInput = _inputReceiver.GetUserInput();
                
                if (userInput == UserOptions.Quit.ToString())
                {
                    return null;
                }

                try
                {
                    var userAnswer = InputColoursParser.ParseFromString(userInput);
                    _inputArrayLengthValidator.ValidateUserInput(userAnswer);

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