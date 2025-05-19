using System.Collections.Generic;

namespace JwtTechTask.Models
{
    public class UserData
    {
        public string userId { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
