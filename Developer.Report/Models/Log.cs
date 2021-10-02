using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Developer.Report.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DeveloperCoder Developer { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public Company Company { get; set; }
    }
}
