using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.DTO
{
    public class Dog
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public int IgnoredProperty { get { return 1; } }
    }
}
