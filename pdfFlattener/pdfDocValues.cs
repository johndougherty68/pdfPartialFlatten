using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfFlattener
{
    /// <summary>
    /// This class allows you to populate a list of key/value pairs which will be given to the pdf in order to fill out the fields
    /// </summary>
    public static class pdfDocValues
    {
        static List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Returns the list of key/value pairs
        /// </summary>
        /// <returns>A list of the values provided</returns>
        public static List<KeyValuePair<string, string>> GetValues()
        {
            return values;
        }

        /// <summary>
        /// Returns the value for a given key. If no value has been provided, returns an empty string
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The value for the key provided</returns>
        public static string GetValue(string key)
        {
            string res=string.Empty;
            foreach(KeyValuePair<string, string> item in values)
            {
                if (item.Key.ToLower() == key.ToLower()) return item.Value;
            }
            return res;
        }

        /// <summary>
        /// Adds an item to the list of values. If the value already exists, an exception will be thrown
        /// </summary>
        /// <param name="key">The name of the key for the item (typically the field name in the pdf)</param>
        /// <param name="value">The value of the item</param>
        public static void Add(string key, string value)
        {
            try
            {
                if (GetValue(key) != string.Empty) throw new Exception("Item already exists with key '" + key + "'");
                values.Add(new KeyValuePair<string, string>(key, value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes an item witn the provided key. If no item with the key exists, no action is taken and no exception is thrown
        /// </summary>
        /// <param name="key">The key of the item to be removed</param>
        public static void Remove(string key)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in values)
                {
                    if (item.Key.ToLower() == key.ToLower()) values.Remove(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
