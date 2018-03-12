using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityAndComparison
{
    public struct CalorieCount : IComparable<CalorieCount>
    {
        private float _value;
        public float Value { get { return _value; } }

        public CalorieCount(float value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value + " cal";
        }

        public int CompareTo(CalorieCount other)
        {
            return _value.CompareTo(other._value);
        }

        public static bool operator <(CalorieCount x, CalorieCount y)
        {
            return x._value < y._value;
        }

        public static bool operator <=(CalorieCount x, CalorieCount y)
        {
            return x._value <= y._value;
        }

        public static bool operator >(CalorieCount x, CalorieCount y)
        {
            return x._value > y._value;
        }

        public static bool operator >=(CalorieCount x, CalorieCount y)
        {
            return x._value >= y._value;
        }
    }
}
