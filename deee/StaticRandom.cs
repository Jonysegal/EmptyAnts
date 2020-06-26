using SFML.Graphics;
using System;
using System.Threading;


/// <summary>
/// Thread safe implementation of Random
/// </summary>
public static class StaticRandom
{
    private static int _seedOffset = 0;

    /// <summary>
    /// Offsetting the seed every invocation ensures no two instances of Random
    /// are able to share the same seed
    /// </summary>
    private static int Seed => GetBaseSeed() + Interlocked.Increment(ref _seedOffset);

    private static int? _nextBaseSeed;

    /// <summary>
    /// Force the next BaseSeed to be a specific number rather than Environment.TickCount.
    /// This is used only for testing purposes
    /// </summary>
    /// <param name="seed">Seed to be forced</param>
    internal static void ForceNextBaseSeed(int seed) => _nextBaseSeed = seed;

    /// <summary>
    /// Base seed for a new Random instance. This will usually be the Environment.TickCount
    /// </summary>
    private static int GetBaseSeed()
    {
        if (_nextBaseSeed.HasValue)
        {
            var value = _nextBaseSeed.Value;
            _nextBaseSeed = null;
            return value;
        }
        return Environment.TickCount;
    }

    private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random(Seed));

    /// <summary>
    /// Wrapper for Random.Next()
    /// </summary>
    public static int Next() => _random.Value.Next();

    /// <summary>
    /// Wrapper for Random.Next(minValue, maxValue)
    /// </summary>
    public static int Next(int minValue, int maxValue) => _random.Value.Next(minValue, maxValue);

    public static double NextDouble() => _random.Value.NextDouble();

    public static Color randomColor() => new Color((byte)StaticRandom.Next(0, 255), (byte)StaticRandom.Next(0, 255), (byte)StaticRandom.Next(0, 255));

}