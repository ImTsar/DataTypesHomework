const int numberOfCars = 40;
var carSpeeds = GetCarSpeeds(numberOfCars).ToArray();

var maxSpeedInfo = FindMaxSpeedIndices(carSpeeds);

Console.WriteLine($"\nThe fastest car speed: {maxSpeedInfo.MaxSpeed} mph");
if (maxSpeedInfo.FirstIndex == maxSpeedInfo.LastIndex)
{
    Console.WriteLine($"Fastest car: #{maxSpeedInfo.FirstIndex + 1}");
}
else
{
    Console.WriteLine($"a) First fastest car: #{maxSpeedInfo.FirstIndex + 1}");
    Console.WriteLine($"b) Last fastest car: #{maxSpeedInfo.LastIndex + 1}");
}

static IEnumerable<int> GetCarSpeeds(int count)
{
    var random = new Random();

    for (int i = 0; i < count; i++)
    {
        yield return random.Next(90, 120);
    }
}

static MaxSpeedInfo FindMaxSpeedIndices(int[] speeds)
{
    int maxSpeed = speeds[0];
    int firstIndex = 0;
    int lastIndex = 0;

    for (int i = 1; i < speeds.Length; i++)
    {
        if (speeds[i] > maxSpeed)
        {
            maxSpeed = speeds[i];
            firstIndex = i;
            lastIndex = i;
        }
        else if (speeds[i] == maxSpeed)
        {
            lastIndex = i;
        }
    }

    return new MaxSpeedInfo(maxSpeed, firstIndex, lastIndex);
}

public class MaxSpeedInfo
{
    public int MaxSpeed { get; init; }
    public int FirstIndex { get; init; }
    public int LastIndex { get; init; }

    public MaxSpeedInfo(int maxSpeed, int firstIndex, int lastIndex)
    {
        MaxSpeed = maxSpeed;
        FirstIndex = firstIndex;
        LastIndex = lastIndex;
    }
}