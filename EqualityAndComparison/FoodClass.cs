using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    public class FoodClass
    {
        private readonly string _name;
        private readonly FoodGroup _group;
        public string Name { get { return _name; } }
        public FoodGroup Group { get { return _group; } }

        public FoodClass(string name, FoodGroup group)
        {
            _name = name;
            _group = group;
        }

        public override string ToString()
        {
            return _name;
        }

        // When overriding Equals we also need to override GetHashCode and == (as good practive)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            FoodClass rhs = obj as FoodClass;
            return _name == rhs._name && _group == rhs._group;
        }

        public static bool operator ==(FoodClass x, FoodClass y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(FoodClass x, FoodClass y)
        {
            return !object.Equals(x, y);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _group.GetHashCode();
        }
    }
}
