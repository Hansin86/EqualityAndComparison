using System;
using System.Collections.Generic;

namespace EqualityAndComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Standard Equal() method
            Food banana = new Food("banana");
            Food chocolate = new Food("chocholate");

            Console.WriteLine(banana.Equals(chocolate)); //compare references
            Console.WriteLine(banana.Equals(null)); //compare references

            // 2) Static Equal() method
            Food exceptionFood = null; //will throw exception
            //Console.WriteLine(exceptionFood.Equals(chocolate));
            //Because of possible null value, we can use static Equal() from "object"
            Console.WriteLine(Equals(exceptionFood, chocolate));
            Console.WriteLine(Equals(chocolate, exceptionFood));
            Console.WriteLine(Equals(exceptionFood, exceptionFood));

            // 3) ReferenceEqual() method
            // Used to check wheter two variables refer to the same instance
            string bananaRef = "banana";
            string banana2Ref = String.Copy(bananaRef);
            Console.WriteLine(ReferenceEquals(bananaRef, banana2Ref));
            Console.WriteLine(bananaRef.Equals(banana2Ref));

            // 4) Overriding Equality for value types (structs)
            FoodStruct foodStructBanana1 = new FoodStruct("banana", FoodGroup.Fruit);
            FoodStruct foodStructBanana2 = new FoodStruct("banana", FoodGroup.Fruit);
            FoodStruct foodStructCarrot = new FoodStruct("carrot", FoodGroup.Vegetable);
            Console.WriteLine("banana == banana2: " + (foodStructBanana1 == foodStructBanana2));
            Console.WriteLine("banana2 == carrot: " + (foodStructBanana2 == foodStructCarrot));
            Console.WriteLine("carrot == banana: " + (foodStructCarrot == foodStructBanana1));

            // 5) Reference equality
            FoodClass foodClass = new FoodClass("apple", FoodGroup.Fruit);
            FoodClass foodClass2 = new FoodClass("apple", FoodGroup.Fruit);
            CookedFoodClass cookedFoodClass = new CookedFoodClass("stewed", "apple", FoodGroup.Fruit);
            CookedFoodClass cookedFoodClass2 = new CookedFoodClass("baked", "apple", FoodGroup.Fruit);
            CookedFoodClass cookedFoodClass3 = new CookedFoodClass("stewed", "apple", FoodGroup.Fruit);
            DisplayWheterEqual(foodClass, cookedFoodClass);
            DisplayWheterEqual(cookedFoodClass, cookedFoodClass2);
            DisplayWheterEqual(cookedFoodClass, cookedFoodClass3);
            DisplayWheterEqual(foodClass, foodClass2);
            DisplayWheterEqual(foodClass, foodClass);

            // 6) Comparison - implementation of IComparable<T> (not adviced to use in real world)
            CalorieCount cal300 = new CalorieCount(300);
            CalorieCount cal400 = new CalorieCount(400);
            DisplayOrder(cal300, cal400);
            DisplayOrder(cal400, cal300);
            DisplayOrder(cal300, cal300);
            if (cal300 < cal400)
                Console.WriteLine("cal300 < cal400");
            //In case of comparison operators, we should also implement == operator, Equals ect. (for developers convieniece)

            // 7) Comparer
            FoodClass[] list = {
                new FoodClass("orange", FoodGroup.Fruit),
                new FoodClass("banana", FoodGroup.Fruit),
                new FoodClass("apple", FoodGroup.Fruit),
                new FoodClass("carrot", FoodGroup.Vegetable)
            };
            SortAndShowList(list);

            // 7) Comparer and inheritance
            FoodClass[] list2 = {                
                new FoodClass("banana", FoodGroup.Fruit),
                new FoodClass("apple", FoodGroup.Fruit),
                new FoodClass("carrot", FoodGroup.Vegetable),
                new CookedFoodClass("raw", "apple", FoodGroup.Fruit)
            };
            SortAndShowList(list2);
            FoodClass[] list3 = {
                new CookedFoodClass("raw", "apple", FoodGroup.Fruit),
                new FoodClass("banana", FoodGroup.Fruit),
                new FoodClass("apple", FoodGroup.Fruit),
                new FoodClass("carrot", FoodGroup.Vegetable)
            };
            SortAndShowList(list3);

            // 8) Equality comparer
            var foodItems = new HashSet<FoodStruct>(FoodStructEqualityComparer.Instance); // By default Equal in our struct is case sensitive, so HashSet treat it as different value. We provide Custom comparer to allo case insensitive comparison
            foodItems.Add(new FoodStruct("apple", FoodGroup.Fruit));
            foodItems.Add(new FoodStruct("pear", FoodGroup.Fruit));
            foodItems.Add(new FoodStruct("pineapple", FoodGroup.Fruit));
            foodItems.Add(new FoodStruct("Apple", FoodGroup.Fruit)); 
            foreach (var foodItem in foodItems)
                Console.WriteLine(foodItem);
        }

        private static void DisplayWheterEqual(FoodClass food1, FoodClass food2)
        {
            if (food1 == food2)
                Console.WriteLine(String.Format("{0,12} == {1}", food1, food2));
            else
                Console.WriteLine(String.Format("{0,12} != {1}", food1, food2));
        }

        private  static void DisplayOrder<T>(T x, T y) where T: IComparable<T>
        {
            int result = x.CompareTo(y);
            if(result == 0)
                Console.WriteLine(String.Format("{0,12} == {1}", x, y));
            else if (result > 0)
                Console.WriteLine(String.Format("{0,12} > {1}", x, y));
            else
                Console.WriteLine(String.Format("{0,12} < {1}", x, y));
        }

        private static void SortAndShowList(FoodClass[] list)
        {
            Array.Sort(list, FoodNameComparer.Instance);
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
