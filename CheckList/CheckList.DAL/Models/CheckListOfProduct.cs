using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckList.DAL.Models
{
    public class CheckListOfProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Fittings> Fittings { get; set; }
        public DateTime Time { get; set; }
        public string UserIdFitter { get; set; }
        [ForeignKey("UserIdFitter")]
        public User User { get; set; }
    }
}
