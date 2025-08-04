using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Utils
{
    public static List<T> ConvertCsvToJson<T>(string csv)
    {
        var lines = csv.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2) return null;

        string[] headers = lines[0].Split(',');

        JArray jArray = new JArray();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            JObject jObj = new JObject();

            for (int j = 0; j < headers.Length && j < values.Length; j++)
            {
                jObj[headers[j]] = values[j];
            }
            jArray.Add(jObj);
        }

        return JsonConvert.DeserializeObject<List<T>>(jArray.ToString());
    }
}
