namespace Electronics_project.Utilities
{
    public static class LayoutHelper
    {
        public static List<string> Pages { get; set; }
        public static List <string> ForLoggedIn { get; set; }
        static LayoutHelper()
        {
            Pages = new List<string>
            {
                "Login",
                "Products"
            };

            ForLoggedIn = new List<string>
            {
                "Profile",
                "Products",
                "Logout"
            };
        }
    }
}
