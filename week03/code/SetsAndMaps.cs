using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var results = new HashSet<string>();

        foreach (var word in words)
        {
            if (word.Length != 2) continue;

            char a = word[0];
            char b = word[1];

            // special case: skip identical letters like "aa"
            if (a == b) continue;

            string reversed = $"{b}{a}";

            if (set.Contains(reversed))
            {
                string pair = string.Compare(word, reversed) < 0
                    ? $"{word} & {reversed}"
                    : $"{reversed} & {word}";

                results.Add(pair);
            }
        }

        return results.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length < 4) continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string w1 = word1.Replace(" ", "").ToLower();
        string w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length) return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }

        foreach (char c in w2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);

        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.features == null)
            return Array.Empty<string>();

        var result = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            if (feature?.properties == null) continue;

            result.Add($"{feature.properties.place} - Mag {feature.properties.mag}");
        }

        return result.ToArray();
    }
}