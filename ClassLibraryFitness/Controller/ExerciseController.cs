using ClassLibraryFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFitness.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises;
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>(EATINGS_FILE_NAME) ?? new Exercise(user)
        }
    }
}
