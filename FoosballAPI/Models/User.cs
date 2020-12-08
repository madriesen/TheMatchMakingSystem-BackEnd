using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        
        [NotMapped]
        public string Token { get; set; }

        //Relations
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int? PloegID { get; set; }
        public Ploeg? Ploeg { get; set; }
        [JsonIgnore]
        public ICollection<Table>? Tables { get; set; }
        [JsonIgnore]
        public ICollection<Team> Teams { get; set; }
    }
}
