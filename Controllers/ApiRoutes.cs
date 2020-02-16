namespace HypertropeCore.Controllers
{
    public static class ApiRoutes
    {
        private const string Base = "/api";
        public static class Auth
        {
            public const string RegisterUser = Base + "/auth/register";
            public const string Login = Base + "/auth/login";
            public const string Ping = Base + "/ping";
        }
        
        public static class Workouts
        {
            public const string Create = Base + "/workouts";
            public const string ShowAll = Base + "/workouts";
            public const string Count = Base + "/workouts/count";
            public const string ListByExercise = Base + "/workouts/grouped/exercise";
            public const string ListByDate = Base + "/workouts/grouped/date";
            public const string ListPb = Base + "/workouts/pbs";
        }

        public static class Exercises
        {
            public const string Create = Base + "/exercises";
            public const string ShowAll = Base + "/exercises";
        }
        
        public static class Quotes
        {
            public const string Create = Base + "/quotes";
            public const string ShowAll = Base + "/quotes";
        }

        public static class MeditationLog
        {
            public const string Create = Base + "/meditationlogs";
            public const string Delete = Base + "/meditationlogs";
            public const string Update = Base + "/meditationlogs";
            public const string ShowAll = Base + "/meditationlogs";
            public const string Show = Base + "/meditationlogs/{id}";
        }
    }
}