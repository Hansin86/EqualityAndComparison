using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    public class Food
    {
        private string _name;
        public string Name { get { return _name; } }
        
        public Food(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
