namespace Intsoft.Domain.ValueObjects;

public class NationalCode
{
    public ulong Value { get; private set; }

    public NationalCode(ulong nationalCode)
    {
        if (nationalCode.ToString().Length != 10)
        {
            throw new Exception("National Code length must be 10.");
        }

        Value = nationalCode;
    }
}
