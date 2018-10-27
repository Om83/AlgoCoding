using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice2.Misc
{
    class Bus
    {
        int BusNumber;
        string[] Stops;

        public Bus(int busNumber, String[] stops)
        {
            BusNumber = busNumber;
            Stops = stops;
        }
    }

    class Stop
    {
        string StopName;
        List<String> BusNumber;
        List<Stop> NeighboringStops;
    }

    class City
    {

    }
}
