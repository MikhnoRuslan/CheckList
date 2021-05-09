using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckList.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public List<Packing> WeightOfPacking { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public bool IsReady { get; set; }
        public string UserIdDeveloper { get; set; }
        [ForeignKey("UserIdDeveloper")]
        public User User { get; set; }
    }
}
