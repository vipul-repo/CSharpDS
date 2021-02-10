using System;
using System.Collections.Generic;

class BadgedAccessProblem
{
    public static void Main1()
    {
        string[][] badgeTimes = new string[][]{
            new string[]{"Paul",     "1355"},
            new string[]{"Jennifer", "1910"},
            new string[]{"John",      "835"},
            new string[]{"John",      "830"},
            new string[]{"Paul",     "1315"},
            new string[]{"John",     "1615"},
            new string[]{"John",     "1640"},
            new string[]{"Paul",     "1405"},
            new string[]{"John",      "855"},
            new string[]{"John",      "930"},
            new string[]{"John",      "915"},
            new string[]{"John",      "730"},
            new string[]{"John",      "940"},
            new string[]{"Jennifer", "1335"},
            new string[]{"Jennifer",  "730"},
            new string[]{"John",     "1630"},
            new string[]{"Vipul",    "2330"},
            new string[]{"Vipul",    "2315"},
            new string[]{"Vipul",    "2300"},
            new string[]{"Vipul",    "1700"},
            new string[]{"Vipul",    "1100"},
            new string[]{"Vipul",    "1045"},
            new string[]{"Vipul",    "1030"},
            new string[]{"Vipul",    "1015"},
            new string[]{"Vipul",    "1000"},
        };

        var result = findPeople(badgeTimes, 3, 100);

        foreach (var item in result)
        {
            Console.WriteLine($"{item[0]}: {item[1]}");
        }
    }

    static List<List<string>> findPeople(string[][] badgeTimes, int noOfTimes, int inTime)
    {
        var personBadgedTimes = new Dictionary<string, List<int>>();

        foreach (var badgeTime in badgeTimes)
        {
            if (personBadgedTimes.ContainsKey(badgeTime[0]))
            {
                personBadgedTimes[badgeTime[0]].Add(Convert.ToInt32(badgeTime[1]));
            }
            else
            {
                personBadgedTimes.Add(badgeTime[0], new List<int> { Convert.ToInt32(badgeTime[1]) });
            }
        }

        var result = new List<List<string>>();

        foreach (var kv in personBadgedTimes)
        {
            if (kv.Value.Count >= noOfTimes)
            {
                kv.Value.Sort();

                var personTimes = getBadgedTimesInPeriod(kv.Value, noOfTimes, inTime);

                if (personTimes != null && personTimes.Count > 0)
                    result.Add(new List<string> { kv.Key, string.Join(", ", personTimes) });
            }
        }

        return result;
    }

    static List<int> getBadgedTimesInPeriod(List<int> badgeTimes, int noOfTimes, int inTim)
    {
        int start = 0, end = 0;

        for (int i = 0; i < badgeTimes.Count; i++)
        {
            start = i;
            for (int j = i + 1; j < badgeTimes.Count; j++)
            {
                if (badgeTimes[j] - badgeTimes[i] > 100)
                    break;
                else
                    end = j;
            }

            if (end - start >= 2)
                return badgeTimes.GetRange(start, end - start + 1);

        }

        return null;
    }
}
