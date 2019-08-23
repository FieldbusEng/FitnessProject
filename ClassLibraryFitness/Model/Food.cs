using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFitness.Model
{
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; set; }
        /// <summary>
        /// Fat food
        /// </summary>
        public double Fets { get; set; }
        /// <summary>
        /// Carbonate
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories for 100gr
        /// </summary>
        public double Calories { get; }
        
        /// <summary>
        /// empty constructor in case passed only name
        /// </summary>
        /// <param name="name"></param>
        public Food(string name) : this(name,0,0,0,0)
        {
            
        }

        public Food(string name, double proteins, double fets, double carbohydrates, double calories)
        {
            Name = name;
            Proteins = proteins /100.0;
            Fets = fets / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
            //todo: check

        }
        public override string ToString()
        {
            return Name;
        }

    }
}
