using migration_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace migration_application.Parsers;

public class WorkOrderParser
{
    private readonly IClientNameMatcher _clientNameMatcher;

    public WorkOrderParser(IClientNameMatcher clientNameMatcher)
    {
        _clientNameMatcher = clientNameMatcher;
    }

    public ParsedWorkOrder Parse(string rawNote, List<string> knownClients)
    {
        string clientName = _clientNameMatcher.Match(rawNote, knownClients);

        var dateMatch = Regex.Match(rawNote, @"\b(\d{1,2}/\d{1,2}/\d{4})\b");
        DateTime.TryParse(dateMatch.Value, out var date);

        string cleanedInfo = rawNote.Replace(clientName, "").Replace(dateMatch.Value, "").Trim();

        return new ParsedWorkOrder
        {
            ClientFullName = clientName,
            Date = date,
            Information = cleanedInfo
        };
    }
}
