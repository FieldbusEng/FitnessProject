using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibraryFitness.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Save user data
        /// </summary>
        protected void Save(string fileName, object itemtype)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, itemtype);
            }

        }
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T itemtype)
                {
                    return itemtype;
                }
                else
                {
                    return default(T);
                }
            }

        }

    }
}
