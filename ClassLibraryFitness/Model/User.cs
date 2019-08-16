using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryFitness.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User 
    {
        #region Properties
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// ДР
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"> Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Exeptions 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name can not be empty or null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender can not be 0.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900.") || birthDate>=DateTime.Now)
            {
                throw new ArgumentException("Not possible date of birth.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight can not be = or less than 0.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height can not be less than 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

            
        }
        //this constructor overload used to create User instance in case this User not exist
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name field can not be empty or null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+ " " + Age;
        }


    }
}
