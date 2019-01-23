using System;
using System.ComponentModel.DataAnnotations;

namespace sample_dotnet_app.Values {

    public class StoredValue {
        [Key]
        public long id {get; set;}
        public string value {get; set;}
    }

}