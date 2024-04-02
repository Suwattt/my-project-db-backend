using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test001.Model
{
    public class Desserts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string flavor { get; set; }
        public int price { get; set; }
    }
}
