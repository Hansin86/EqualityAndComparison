using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    // sealed defined how we implement Equality
    public sealed class CookedFoodClass : FoodClass
    {
        private string _cookingMethod;
        public string CookingMethod { get { return _cookingMethod; } }

        public CookedFoodClass(string cookingMethod, string name, FoodGroup group) : base(name, group)
        {
            _cookingMethod = cookingMethod;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", _cookingMethod, Name);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            CookedFoodClass rhs = (CookedFoodClass)obj;
            return _cookingMethod == rhs._cookingMethod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _cookingMethod.GetHashCode();
        }

        public static bool operator ==(CookedFoodClass x, CookedFoodClass y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(CookedFoodClass x, CookedFoodClass y)
        {
            return !object.Equals(x, y);
        }
    }
}
