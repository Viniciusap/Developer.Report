using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Developer.Report.Models
{
    public class DeveloperCoder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adrress { get; set; }
        public int Age { get; set; }
        public List<Company> Company { get; set; }
    }
}
