using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    public struct FoodStruct : IEquatable<FoodStruct>
    {
        private readonly string _name;
        private readonly FoodGroup _group;
        public string Name { get { return _name; } }
        public FoodGroup Group { get { return _group; } }

        public FoodStruct(string name, FoodGroup group)
        {
            _name = name;
            _group = group;
        }

        public override string ToString()
        {
            return _name;
        }

        // When overriding Equality for value typs (structs), we need always to implement (this is a good practice):
        // 1) Implement IEquatable<FoodStruct>
        // 2) Override object.Equals()
        // 3) Implement == operator
        // 4) Implement != operator
        // 5) Implement object.GetHashCode()

        // 1) Implement IEquatable<FoodStruct>
        public bool Equals(FoodStruct other)
        {
            return _name == other.Name && _group == other.Group;
        }

        // 2) Override object.Equals()
        public override bool Equals(object obj)
        {
            if (obj is FoodStruct)
                return Equals((FoodStruct)obj);
            else
                return false;
        }

        // 3) Implement == operator
        public static bool operator ==(FoodStruct lhs, FoodStruct rhs)
        {
            return lhs.Equals(rhs);
        }

        // 4) Implement != operator
        public static bool operator !=(FoodStruct lhs, FoodStruct rhs)
        {
            return !lhs.Equals(rhs);
        }

        // 5) Implement object.GetHashCode()
        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _group.GetHashCode();
        }
    }
}
