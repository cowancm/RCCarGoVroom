using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Xaml.Schema;

namespace Vroom.Engine.LocationalBookeeping
{
    public struct GPSMetrics
    {
        uint speed { get; set; }
        Location location { get; set; }
    }

    public struct Location
    {
        public double lat;
        public double lon;
    }
}
