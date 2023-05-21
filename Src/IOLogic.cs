using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Memorer.Src
{
    using MessagesClasses;
    using System.Text.Encodings.Web;
    using System.Text.Json.Serialization;

    internal class IOLogic
    {
        private const string DEFAULT_DATA_DIRECTORY = @"..\..\..\Data\Data";
        private readonly List<string> files = new List<string>()
        {
            "Data.json",
            "Settings.json"
        };

        public enum Files
        {
            Messages,
            Settings,
        }
        public string Directory { get; private set; }
        public string? Filename { get; private set; }
        public string? Path { get; private set; }
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
        };

        public IOLogic(string directory = DEFAULT_DATA_DIRECTORY)
        {
            Directory = directory;
        }

        public void ChangePath(string filename, string directory)
        {
            Directory = directory;
            Filename = filename;
            Path = CombinePath(directory, filename);
        }

        public void ChangeFileName(string filename)
        {
            Filename = filename;
            Path = CombinePath(Directory, filename);
        }

        private string CombinePath(string directory, string filename)
        {
            return directory + (directory.Substring(directory.Length - 1) != @"\" ? @"\" : "") + filename;
        }

        public void PutStringsToFile<T>(T obj, Files file)
        {
            string json = JsonSerializer.Serialize(obj, options);
            if (Path == null)
            {
                Path = CombinePath(DEFAULT_DATA_DIRECTORY, files[(int)file]);
            }
            File.WriteAllText(Path, json);
        }
        public T? GetStringsFromFile<T>(Files file) where T : class, new()
        {
            Path = CombinePath(DEFAULT_DATA_DIRECTORY, files[(int)file]);
            try
            {
                if (File.Exists(Path))
                {
                    string json = File.ReadAllText(Path);
                    try
                    {
                        return JsonSerializer.Deserialize<T>(json, options);
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Error deserializing JSON data: {ex.Message}\n{ex.StackTrace}");
                        return null;
                    }
                }
                else
                {
                    File.Create(Path);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
