using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ms_user
    {
        [Key]
        public long user_id {  get; set; } 
        public string user_name {  get; set; }
        public string password {  get; set; }
        public bool is_active {  get; set; }
    }
    public class ms_location
    {
        [Key]
        public string location_id { get; set; }
        public string location_name { get; set; }
    }
}
