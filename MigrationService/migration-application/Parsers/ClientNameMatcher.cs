using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySharp;
using Process = FuzzySharp.Process;

namespace migration_application.Parsers;

public interface IClientNameMatcher
{
    string Match(string rawText, List<string> knownClients);
}

public class ClientNameMatcher : IClientNameMatcher
{
    public string Match(string rawText, List<string> knownClients)
    {
        return Process.ExtractOne(rawText, knownClients)?.Value ?? string.Empty;
    }
}
