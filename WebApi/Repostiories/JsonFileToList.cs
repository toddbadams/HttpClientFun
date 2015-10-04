using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi.Repostiories
{
    public static class JsonFileToList<T> where T : class
    {
        public static List<T> Read(string fileName)
        {
            try
            {
                using (StreamReader file = File.OpenText(fileName))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    return o2.ToObject<List<T>>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void Write(string fileName, List<T> values)
        {
            using (var file = File.CreateText(fileName))
            using (var writer = new JsonTextWriter(file))
            {
                writer.WriteValue(JsonConvert.SerializeObject(values));
            }
        }
    }
}