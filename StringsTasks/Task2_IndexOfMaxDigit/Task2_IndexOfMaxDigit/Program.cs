var text = "   a 4aht9r 79a5";
var indexOfMaxDigit = GetMaxDigitIndex(text);

Console.WriteLine(
    indexOfMaxDigit.HasValue
        ? $"\nIndex of the largest digit (relative to the first non-space character): {indexOfMaxDigit.Value}"
        : "\nNo digits found in the text."
);

static int? GetMaxDigitIndex(string text)
{
    const char maxDigitChar = '9';
    var maxDigit = 0;
    int? maxDigitIndex = null;
    var firstNonSpaceIndex = 0;
    var firstNonSpaceIndexFound = false;

    for (int i = 0; i < text.Length; i++)
    {
        var currentChar = text[i];

        if (!firstNonSpaceIndexFound && char.IsWhiteSpace(currentChar))
        {
            firstNonSpaceIndex++;

            continue;
        }

        firstNonSpaceIndexFound = true;

        if (currentChar == maxDigitChar)
        {
            maxDigitIndex = i;

            break;
        }

        if (!char.IsDigit(currentChar))
        {
            continue;
        }

        var currentDigit = DigitCharToInt(currentChar);

        if (currentDigit > maxDigit)
        {
            maxDigit = currentDigit;
            maxDigitIndex = i;
        }
    }

    return maxDigitIndex.HasValue ? maxDigitIndex.Value - firstNonSpaceIndex + 1 : null;
}

static int DigitCharToInt(char digitChar)
{
    return digitChar - '0';
}