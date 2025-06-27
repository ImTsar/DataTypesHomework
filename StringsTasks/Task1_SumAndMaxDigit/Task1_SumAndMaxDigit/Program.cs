var text = "H3ll0,9 W0r1d16!";
var digitInfo = ProcessDigits(text);

Console.WriteLine(
    digitInfo is null
        ? "\nNo digits found in the text."
        : $"\nThe largest digit found: {digitInfo.MaxDigit}\nSum of all digits: {digitInfo.DigitSum}"
);

static DigitInfo ProcessDigits(string text)
{
    int? maxDigit = null;
    int digitSum = 0;

    foreach (var ch in text)
    {
        if (char.IsDigit(ch))
        {
            int digit = DigitCharToInt(ch);
            digitSum += digit;

            if (!maxDigit.HasValue || digit > maxDigit)
            {
                maxDigit = digit;
            }
        }
    }

    return maxDigit.HasValue ? new DigitInfo(maxDigit.Value, digitSum) : null;
}

static int DigitCharToInt(char digitChar)
{
    return digitChar - '0';
}

public class DigitInfo
{
    public int MaxDigit { get; init; }
    public int DigitSum { get; init; }

    public DigitInfo(int maxDigit, int digitSum)
    {
        MaxDigit = maxDigit;
        DigitSum = digitSum;
    }
}