namespace HypertropeCore.Controllers
{
    public static class ApiRoutes
    {
        public static class Workouts
        {
            private const string Base = "/api";

            public const string Create = Base + "/workout";
            public const string ShowAll = Base + "/workout";
            public const string ListByExercise = Base + "/workout/grouped/exercise";
            public const string ListByDate = Base + "/workout/grouped/date";
            public const string ListPb = Base + "/workout/pbs";
        }

        public static class Exercises
        {
            private const string Base = "api";

            public const string Create = Base + "/exercise";
            public const string ShowAll = Base + "/exercise";
        }
        
        public static class Quotes
        {
            private const string Base = "api";

            public const string Create = Base + "/quote";
            public const string ShowAll = Base + "/quote";
        }
    }
}