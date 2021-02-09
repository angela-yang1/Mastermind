#nullable enable
using System;
using System.Collections.Generic;
using BCL;
using Mastermind.Enums;
using Mastermind.Exceptions;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class InputHandler : IInputHandler
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly IErrorHandler _consoleErrorHandler;
        private readonly InputArrayLengthValidator _inputArrayLengthValidator;

        public InputHandler(IInputReceiver inputReceiver, IErrorHandler consoleErrorHandler)
        {
            _inputReceiver = inputReceiver;
            _consoleErrorHandler = consoleErrorHandler;
            _inputArrayLengthValidator = new InputArrayLengthValidator(Constants.MasterColoursCount);
        }
        
        public Either<Colour[], UserOption> TakeInput()
        {
            // shouldn't be controlled by input/outputs
            // take in user input as parameter and remove while loop?
            
            while (true)
            {
                var userInput = _inputReceiver.GetUserInput();
                
                if (string.Equals(userInput, UserOption.Quit.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return UserOption.Quit;
                }

                try
                {
                    var userAnswer = InputColourParser.ParseFromString(userInput);
                    _inputArrayLengthValidator.ValidateUserInput(userAnswer);

                    return userAnswer;
                }
                catch (ParseException e)
                {
                    _consoleErrorHandler.DisplayParseErrorMessage(e);
                }
                catch (LengthException e)
                {
                    _consoleErrorHandler.DisplayLengthErrorMessage(e);
                }
                
            }
        }
    }
}