using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    //public class FoodNameComparer : IComparer<FoodClass>
    public class FoodNameComparer : Comparer<FoodClass> //MS suggest to derive from Comparer class, rather than implement IComparer
    {
        // Good candidate for being a static field
        private static FoodNameComparer _instance = new FoodNameComparer();

        public static FoodNameComparer Instance { get { return _instance; } }

        // We should compare all fields, so in case of equal results, we'll get always same result
        public override int Compare(FoodClass x, FoodClass y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            
            int nameOrder = string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);

            if (nameOrder != 0)
                return nameOrder;

            return string.Compare(
                x.Group.ToString(), y.Group.ToString(), StringComparison.CurrentCulture);
        }
    }
}
