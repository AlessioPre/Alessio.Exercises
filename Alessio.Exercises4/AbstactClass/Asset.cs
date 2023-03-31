using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public abstract class Asset
    {
        decimal     _valueAsset;
        string      _name;

        public decimal ValueAsset { get { return _valueAsset; } set { _valueAsset =value; } } 
        public string Name { get { return _name; } set {  _name = value; } }

        public Asset(string name, decimal valueAsset) 
        {
            Name = name;
            ValueAsset = valueAsset; 
        }
    }
}