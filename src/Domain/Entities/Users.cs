using System;


namespace Domain.Entities
{

    public partial class Users
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public  string UserName { get; set; }      
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Created  { get; set; }
       

    }
    
}
