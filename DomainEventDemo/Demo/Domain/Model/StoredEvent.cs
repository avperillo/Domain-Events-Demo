using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model
{
    public class StoredEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventBody { get; set; }
        public DateTime OcurredOn { get; set; }
    }
}
