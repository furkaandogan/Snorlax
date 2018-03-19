namespace Snorlax.Repository.Model
{
    [CollectionName("Admins")]
    public class Admin
        :Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Admin()
            :base()
        {

        }
    }
}