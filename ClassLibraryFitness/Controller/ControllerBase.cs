using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibraryFitness.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Save user data Serialisation in Binary
        /// </summary>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }

        }
        /// <summary>
        /// Deserialisation in Binary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
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
