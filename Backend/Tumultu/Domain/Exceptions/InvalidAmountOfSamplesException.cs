namespace Tumultu.Domain.Exceptions;

public class InvalidAmountOfSamplesException : Exception
{
    public InvalidAmountOfSamplesException(int requiredAmount, int receivedAmount)
        : base($"Invalid amount of samples provided. Required amount for this sample is: {requiredAmount}. Amount provided is {receivedAmount}")
    {}
}
