namespace HypertropeCore.Controllers
{
    public static class ApiRoutes
    {
        public static class Workouts
        {
            private const string Base = "/api";

            public const string Create = Base + "/workout";
            public const string ShowAll = Base + "/workout";
        }
    }
}