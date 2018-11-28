using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace FlightRecord
{
    public class Base<T> where T:Base<T>
    {
        public static List<T> Items = new List<T>();
        public string Path { get; set; }
        public Base()
        {
            Items.Add((T)this);
        }


    }

}
