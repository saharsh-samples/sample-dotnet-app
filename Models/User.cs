using System.ComponentModel.DataAnnotations;

namespace sample_dotnet_app.Models {
    public class User {
        [Key]
        public string Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}