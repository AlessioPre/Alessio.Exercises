using Alessio.Exercises4.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4.Classi
{
    internal class SwiftCentralBank : CentralBank ,ISansionable
    {
        bool _isSansionate = false;
        public SwiftCentralBank()
        {
        }

        public SwiftCentralBank(string name, string country) : base(name, country)
        {
        }

        //public SwiftCentralBank(string name, string country, CultureInfo culture) : base(name, country, culture)
        //{
        //}

        public SwiftCentralBank(string name, string country, string city, string street) : base(name, country, city, street)
        {
        }

        
        public bool IsSansionate { get => _isSansionate; set => _isSansionate = value; }
    }
}
