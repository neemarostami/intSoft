namespace Intsoft.Domain.ValueObjects;

public class PhoneNumber
{
    public ulong Value { get; private set; }

    public PhoneNumber(ulong phoneNumber)
    {
        if (phoneNumber.ToString().Length != 10)
        {
            throw new Exception("Phone Number length is not valid.");
        }

        Value = phoneNumber;
    }
}
