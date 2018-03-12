using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    public class FoodStructEqualityComparer : EqualityComparer<FoodStruct>
    {
        private static readonly FoodStructEqualityComparer _instance = new FoodStructEqualityComparer();
        public static FoodStructEqualityComparer Instance { get { return _instance; } }

        public override bool Equals(FoodStruct x, FoodStruct y)
        {
            //return x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant()
            //    && x.Group == y.Group;
            return StringComparer.OrdinalIgnoreCase.Equals(x.Name, y.Name); // Build in string comparer
        }

        public override int GetHashCode(FoodStruct obj)
        {
            //return obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Group.GetHashCode();
            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name) ^ obj.Group.GetHashCode(); // Both techniques are fine
        }
    }
}
