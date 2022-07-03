using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPIOracle.Models
{
    [Table("COUNTRIES")]
    public class Countries
    {
        [Key]
        public string COUNTRY_ID { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string REGION_ID { get; set; }
    }
}
