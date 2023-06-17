using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils.Classes;

namespace Utils.Readers
{
    public static class Configuration
    {
        private static IEnumerable<ConfigEntry> _configEntries;
        static Configuration()
        {
            ReadAllConfigEntries();
        }

        public static void ReadAllConfigEntries()
        {
            var configFolder = new DirectoryInfo($"{AppContext.BaseDirectory}..\\..\\..\\..\\cfg");
            var configEntries = new List<ConfigEntry>();
            foreach (var file in configFolder.GetFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    var entry = new ConfigEntry();
                    var content = line.Trim().Split('=');
                    if (line.StartsWith('#') || content.Count() != 2)
                        continue;
                    entry.ID = content[0].Trim();
                    entry.Value = content[1].Trim();
                    entry.OriginalFile = file.Name;
                    configEntries.Add(entry);
                }
            }

            _configEntries = configEntries;
        }

        public static Result<ConfigEntry> GetConfigEntry(string pName, string pFileName = null)
        {
            var entry = new ConfigEntry()
            {
                ID = pName
            };

            if (!_configEntries.Select(x => x.ID).Contains(pName))
            {
                return new Result<ConfigEntry>(false);
            }

            entry.Value = pFileName is not null ?
                _configEntries.Where(x => x.OriginalFile == pFileName && x.ID == pName) :
                _configEntries.Where(x => x.ID == pName);

            if (entry.Value == null)
            {
                return new Result<ConfigEntry>(false);
            }
            return new Result<ConfigEntry>(true, entry);
        }

        public static Result<IEnumerable<ConfigEntry>> GetAllConfigEntries()
            => new Result<IEnumerable<ConfigEntry>>(true, _configEntries);

        public static Result<IEnumerable<ConfigEntry>> GetSelectedConfigEntries(IEnumerable<string> pContainedNames = null, IEnumerable<string> pContainedInFiles = null)
        {
            var allEntries = _configEntries;

            if (pContainedNames is not null)
            {
                allEntries = allEntries.Where(x => pContainedNames.Contains(x.ID)).ToList();
            }

            if (pContainedInFiles is not null)
            {
                allEntries = allEntries.Where(x => pContainedInFiles.Contains(x.OriginalFile.ToLower())).ToList();
            }

            return new Result<IEnumerable<ConfigEntry>>(true, allEntries);
        }
    }

    public struct ConfigEntry
    {
        public string ID;
        public object Value;
        public string OriginalFile;
    }
}
