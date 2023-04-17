using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.Entity
{
    public class Office
    {
        public int OfficeId { get; set; }
        public int  CityId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
    }
}
