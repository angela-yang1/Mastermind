#nullable enable
using System;
using System.Collections.Generic;
using BCL;
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
            _inputArrayLengthValidator = new InputArrayLengthValidator(Constants.NumberOfColours);
        }
        
        public Either<Colour[], UserOption> TakeATurn()
        {
            // shouldn't be controlled by input/outputs
            // take in user input as parameter and remove while loop?
            // do while loop??
            
            while (true)
            {
                var userInput = _inputReceiver.GetUserInput();
                
                if (string.Equals(userInput, UserOption.Quit.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return UserOption.Quit;
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