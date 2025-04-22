# linq-speed-benchmarks

Hardware OS & spec:
- Operating system: Fedora Linux 42 (Workstation Edition)
- Hardware model: HP HP EliteBook x360 830 G6
- Processor: Intel® Core™ i5-8365U × 8
- Memory: 32.0 GB


Results for ListMaximumBenchmark:

| Method  |      Mean |     Error |    StdDev | Ratio | RatioSD |
|---------|----------:|----------:|----------:|------:|--------:|
| Linq    |  8.493 us | 0.1661 us | 0.2435 us |  1.00 |    0.04 |
| ForLoop | 67.978 us | 1.0049 us | 0.8392 us |  8.01 |    0.24 |
| Span    | 42.943 us | 0.8455 us | 0.9047 us |  5.06 |    0.17 |

Results for LazySequenceMaximumBenchmark:

| Method    |     Mean |    Error |   StdDev | Ratio | RatioSD |
|-----------|---------:|---------:|---------:|------:|--------:|
| ForLoop   | 796.2 us | 11.74 us | 13.05 us |  4.75 |    0.09 |
| WhileLoop | 198.3 us |  2.36 us |  1.97 us |  1.18 |    0.01 |
| Linq      | 167.7 us |  1.83 us |  1.43 us |  1.00 |    0.01 |

Results for ComplexOperationsBenchmark:

| Method    |     Mean |    Error |   StdDev | Ratio | RatioSD |
|-----------|---------:|---------:|---------:|------:|--------:|
| ForLoop   | 811.4 us | 12.92 us | 21.94 us |  4.69 |    0.15 |
| WhileLoop | 247.5 us |  4.69 us |  4.61 us |  1.43 |    0.04 |
| Linq      | 173.0 us |  3.21 us |  3.00 us |  1.00 |    0.02 |
