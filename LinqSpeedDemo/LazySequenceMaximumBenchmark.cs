using BenchmarkDotNet.Attributes;

namespace LinqSpeedDemo;

public class LazySequenceMaximumBenchmark
{
    private IEnumerable<int> _data = [];
    
    [GlobalSetup]
    public void Setup()
    {
        _data = Enumerable.Range(0, 100_000);
    }
    
    [Benchmark]
    public void ForLoop()
    {
        List<int> list = [];
        foreach (var item in _data)
        {
            list.Add(item);
        }
        
        int max = list[0];
        for (var i = 1; i < list.Count; i++)
        {
            max = Math.Max(max, list[i]);
        }
    }

    [Benchmark]
    public void WhileLoop()
    {
        using var enumerator = _data.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return;
        }
        
        int max = enumerator.Current;
        while (enumerator.MoveNext())
        {
            max = Math.Max(max, enumerator.Current);
        }
    }
    
    [Benchmark(Baseline = true)]
    public void Linq()
    {
        int max = _data.Max();
    }
}