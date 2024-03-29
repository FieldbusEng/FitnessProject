﻿using ClassLibraryFitness.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibraryFitness.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eatings.dat";
        private readonly User user;
        /// <summary>
        /// List of foods
        /// справочник еды
        /// </summary>
        public List<Food> Foods { get;  }
        /// <summary>
        /// List of getting the food справочник приема пищи
        /// </summary>
        /// <param name="user"></param>
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can not be empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }


        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(p => p.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        
        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            base.Save(FOODS_FILE_NAME, Foods);
            base.Save(EATING_FILE_NAME, Eating);
        }


    }
}
