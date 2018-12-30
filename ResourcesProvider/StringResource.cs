using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babylon.ResourcesProvider
{
    /// <summary>
    /// Represents one string to be localized. Contains all locales for the string. Locales are specified using .NET 4.0 culture codes.
    /// </summary>
    public class StringResource : IComparable
    {
        /// <summary>
        /// Name of the string. This generally is the key used in source code to identify the string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Notes helping with the translation of the string
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Storage location for the string. This generally is a file but could also be a database table.
        /// </summary>
        public string StorageLocation { get; set; }

        private Dictionary<string, string> _localeStrings = new Dictionary<string, string>();

        public StringResource(string name, string notes)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);

            Name = name;
            Notes = notes;
        }

        public void SetLocaleText(string locale, string text)
        {
            if (locale == null)
                throw new ArgumentNullException(locale);
            if (text == null)
                throw new ArgumentNullException(text);

            // check if a text for the locale is already set
            if (_localeStrings.ContainsKey(locale))
            {
                _localeStrings[locale] = text;
            }
            else
            {
                _localeStrings.Add(locale, text);
            }
        }

        public string GetLocaleText(string locale)
        {
            if (locale == null)
                throw new ArgumentNullException(locale);

            return _localeStrings.FirstOrDefault(s => s.Key == locale).Value;
        }

        public IEnumerable<string> GetLocales()
        {
            return _localeStrings.ToList().Select(s => s.Key);
        }

        public bool IsLocalePresent(string locale)
        {
            return _localeStrings.Count(s => s.Key == locale) > 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is StringResource))
                throw new ArgumentException("obj is null or of the wrong type");

            return string.Compare(this.StorageLocation + this.Name, (obj as StringResource).StorageLocation + (obj as StringResource).Name);
        }
    }
}
