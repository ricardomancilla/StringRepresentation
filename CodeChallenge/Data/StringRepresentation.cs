using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge.Data
{
    [Table("StringRepresentation")]
    public class StringRepresentation
    {
        [Key]
        public int Id { get; set; }
        public int Limit { get; set; }
        public DateTime RequestDt { get; set; }
    }
}
