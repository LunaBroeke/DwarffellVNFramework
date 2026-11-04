using System;
using System.IO;
using Newtonsoft.Json;

namespace Dwarffell.TextEngine
{
    public static class TextPlayer
    {
        public static Language text = new Language();
        private static string path;
        private static readonly bool debug = true;
        public static void Start(string code)
        {
            if (debug)
            {
                code = "en_debug";
                path = Path.Combine(Directory.GetCurrentDirectory(), "lang", $"{code}.lang");
                text = CreateFileDebug();
                return; 
            }
            path = Path.Combine(Directory.GetCurrentDirectory(), "lang", $"{code}.lang");
            if (File.Exists(path))
            {
                text = JsonConvert.DeserializeObject<Language>(File.ReadAllText(path));
            }
            else
            {
                Console.WriteLine($"Language file does not exist at {path}");
            }
        }
        public static Language CreateFileDebug()
        {
            Language l = new Language("en_debug");

            string json = JsonConvert.SerializeObject(l, Formatting.Indented);
            string directory = Path.GetDirectoryName(path);
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(path,json);
            return l;
        }
        public static string Display(string s)
        {
            return s;
        }
    }
}