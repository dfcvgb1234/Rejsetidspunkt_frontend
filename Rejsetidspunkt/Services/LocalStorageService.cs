using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    internal class LocalStorageService
    {
        public static void SaveStringToStorage(string key, string data)
        {
            Preferences.Default.Set<string>(key, data);
        }

        public static string GetStringFromStorage(string key)
        {
            bool hasKey = Preferences.Default.ContainsKey(key);

            if (hasKey)
            {
                return Preferences.Default.Get<string>(key, null);
            }

            return null;
        }

        public static void DeleteStringFromStorage(string key)
        {
            bool hasKey = Preferences.Default.ContainsKey(key);

            if (hasKey)
            {
                Preferences.Default.Remove(key);
            }
        }
    }
}
