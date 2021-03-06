using System;
using BCL;
using Mastermind.Enums;
using Mastermind.Exceptions;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class InputHandler : IInputHandler
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly IErrorHandler _errorHandler;
        private readonly InputArrayLengthValidator _inputArrayLengthValidator;

        public InputHandler(IInputReceiver inputReceiver, IErrorHandler errorHandler)
        {
            _inputReceiver = inputReceiver;
            _errorHandler = errorHandler;
            _inputArrayLengthValidator = new InputArrayLengthValidator(Constants.MasterColoursCount);
        }
        
        public Either<Colour[], UserOption> TakeInput()
        {
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
                    _errorHandler.DisplayParseExceptionMessage(e);
                }
                catch (LengthException e)
                {
                    _errorHandler.DisplayLengthExceptionMessage(e);
                }
            }
        }
    }
}