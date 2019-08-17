using ClassLibraryFitness.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;



namespace ClassLibraryFitness.Controller
{
    /// <summary>
    /// Controller for User
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of the application
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }

        //additional flag to understand if user new or not, by default is false
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Creation of the new Controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("name can not be emtpy", nameof(userName));
            }
            Users = GetUsersData();

            // checking if this user already exist in the List
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName); 

            //if User not exist we create new User where we put only name
            if (CurrentUser == null) 
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
             
            }

        }
        /// <summary>
        /// Method to get the saved List of users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (fs.Length >0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                
            }
          

        }
        //method  to create new user
        public void SetNewUserData(string genderName, DateTime birthDate, double weight=1, double height =1)
        {
            //Checking
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        /// <summary>
        /// Load user data to app
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    Users = users;
                }
                // todo: what to do if deserializer didnt work out
            }

        }

        /// <summary>
        /// Save user data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }

        }
        

    }
}
