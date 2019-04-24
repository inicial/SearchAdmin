using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
    public class DeparturePort
    {
        public string Code { get; set; }
        public NameBox Name { get; set; }
        public int Parent { get; set; }
        public DeparturePort(string[] args, int parent)
        {
            Code = args[0];
            Name = new NameBox(){EN = args[1],RU = args[2]};
            Parent = parent;
        }
    }
}
