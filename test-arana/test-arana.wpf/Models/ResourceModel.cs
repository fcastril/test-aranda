using System;
using System.ComponentModel.DataAnnotations;

namespace test_arana.wpf.Models
{
    public class ResourceModel
    {
        [Key]
        public Guid id { get; set; }
        public string so { get; set; }
        public string machine { get; set; }
        public string ip { get; set; }
        public string dd { get; set; }
        public string procesador { get; set; }
        public string ram { get; set; }
        public DateTime date { get; set; }
    }
}
