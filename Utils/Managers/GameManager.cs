using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Interfaces;
using Utils.Readers;

namespace Utils.Managers
{
    public static class GameManager
    {
        private static Type _currentGameType;
        private static Dictionary<string, Type> _gameIdentifiers;

        static GameManager()
        {
            _gameIdentifiers = ReadGameIdentifiers();
        }

        private static Dictionary<string, Type> ReadGameIdentifiers()
        {
            var result = Configuration.GetSelectedConfigEntries(pContainedInFiles: new List<string>() { "games.cfg" });
            var ret = new Dictionary<string, Type>();
            if (!result)
            {
                return ret;
            }

            foreach (var entry in result.Value)
            {
                if (entry.Value is not string s)
                    continue;

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                Type type = typeof(object);
                if (s.Contains('.'))
                {
                    var split = s.Split('.');
                    var project = split[0].Trim();
                    var typeName = split[1].Trim();
                    var assembly = assemblies.FirstOrDefault(x => x.FullName.Contains(project));
                    if (assembly == null)
                        continue;
                    type = assembly.GetType(s);
                }

                ret.Add(entry.ID, type);
            }
            return ret;
        }

        public static bool SetGameType(string pGameGuid)
        {
            if (string.IsNullOrEmpty(pGameGuid) || !_gameIdentifiers.ContainsKey(pGameGuid))
                return false;

            _currentGameType = _gameIdentifiers[pGameGuid];
            return true;
        }

        public static IGame LoadCurrentGame()
        {
            return Activator.CreateInstance(_currentGameType) as IGame;
        }
    }
}
