using BenchmarkDotNet.Attributes;

namespace LinqSpeedDemo;

public class ComplexOperationsBenchmark
{
    // Request:
    // Start from a list of random integers
    // Isolate blocks of six consecutive digits
    // Count appearance of each block
    // Identify the most frequent block
    
    private List<int> _data = [];

    [GlobalSetup]
    public void Setup()
    {
        Random rnd = new();
        _data = Enumerable.Range(0, 10_000)
            .Select(x => rnd.Next())
            .ToList();
    }

    [Benchmark]
    public void ForLoop()
    {
        Dictionary<int, int> counts = new();

        foreach (var value in _data)
        {
            int temp = value;
            while (temp > 99_999)
            {
                int item = temp % 1_000_000;
                if (item > 99_999)
                {
                    int prevCount = counts.TryGetValue(item, out int count) ? count : 0;
                    counts[item] = prevCount + 1;
                    temp /= 10;
                }
            }
        }
        
        int[] candidates = counts.Keys.ToArray();
        Array.Sort(candidates, (a, b) => counts[b].CompareTo(counts[a]));
        int[] winners = new int[10];
        Array.Copy(candidates, winners, winners.Length);
    }
    
    [Benchmark(Baseline = true)]
    public void Linq()
    {
        IEnumerable<int> ToBlocks(int x)
        {
            while (x > 99_999)
            {
                int candidate = x % 1_000_000;
                if (candidate > 99_999)
                {
                    yield return candidate;
                    x /= 10;
                }
            }   
        }
        
        var winners = _data
            .SelectMany(ToBlocks)
            .GroupBy(block => block, (block, items) => (block, count: items.Count()))
            .OrderByDescending(x => x.count)
            .Select(x => x.block)
            .Take(10)
            .ToArray();
    }
}