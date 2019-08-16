using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFitness.Model
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Создать пол
        /// </summary>
        /// <param name="name"> gender name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty or null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
