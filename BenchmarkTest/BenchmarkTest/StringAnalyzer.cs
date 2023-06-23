using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Text.RegularExpressions;

namespace BenchmarkTest;

[SimpleJob(RunStrategy.ColdStart, iterationCount: 1000)]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class StringAnalyzer
{
    [Benchmark]
    [Arguments("1234567890")]
    public bool IsStringNumberRegex(string value)
    {
        return Regex.IsMatch(value, @"^\d$");
    }

    [Benchmark]
    [Arguments("1234567890")]
    public bool IsStringNumberParse(string value)
    {
        return long.TryParse(value, out long number);
    }

    [Benchmark]
    [Arguments("1234567890")]
    public bool IsStringNumberLinq(string value)
    {
        return value.All(char.IsDigit);
    }
}