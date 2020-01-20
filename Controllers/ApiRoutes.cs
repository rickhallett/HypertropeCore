namespace HypertropeCore.Controllers
{
    public static class ApiRoutes
    {
        private const string Base = "/api";
        public static class Auth
        {
            public const string RegisterUser = Base + "/auth/register";
        }
        
        public static class Workouts
        {
            public const string Create = Base + "/workout";
            public const string ShowAll = Base + "/workout";
            public const string Count = Base + "/workout/count";
            public const string ListByExercise = Base + "/workout/grouped/exercise";
            public const string ListByDate = Base + "/workout/grouped/date";
            public const string ListPb = Base + "/workout/pbs";
        }

        public static class Exercises
        {
            public const string Create = Base + "/exercise";
            public const string ShowAll = Base + "/exercise";
        }
        
        public static class Quotes
        {
            public const string Create = Base + "/quote";
            public const string ShowAll = Base + "/quote";
        }
    }
}