using System.Globalization;

namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(string message, params object[] args)
     : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}