using System;
using System.Collections.Generic;

namespace Assingment4
{
    public class NumSet
    {
        private HashSet<int>? intSet;

        public HashSet<int>? IntSet { get => intSet; set => intSet = value; }

        /*
         * Constructor, takes in a params integer array, and fills a HashSet with the values in the array.
         */
        public NumSet(params int[]? args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args), "Passed in args array is null");
            }

            IntSet = new HashSet<int>(args);
        }

        /*
         * This method will print the numbers in the array that is built from the constructor.
         */
        public int[] ReturnArray()
        {
            if(IntSet == null)
            {
                throw new ArgumentNullException(nameof(IntSet), "NumberSet HashSet<int> is null in NumSet.ReturnArray()");
            }

            int[] arraySet = new int[IntSet.Count];
            IntSet.CopyTo(arraySet);
            return arraySet;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not NumSet numSet)
            {
                return false;
            }

            if (IntSet is null)
            {
                throw new ArgumentNullException(nameof(IntSet), "IntSet is null in NumSet.Equals(object obj)");
            }

            return this.IntSet == ((NumSet)obj).IntSet;
        }

        /*
         * Will return the HashCode specific to the HashSet built in the constructor
         * NOTE: Needs Testing
         */
        public override int GetHashCode()
        {
            if(IntSet == null)
            {
                throw new ArgumentNullException(nameof(IntSet), "IntSet is null, be sure it is made within the constructor");
            }

            return IntSet.GetHashCode();
        }

        public static bool operator ==(NumSet? temp1, NumSet? temp2)
        {
            if (temp1 is null && temp2 is null)
            {
                return true;
            }
            if (temp1 is null ^ temp2 is null)
            {
                return false;
            }

            /*
             * This if statement was used because the compiler was 
             *  whining that temp1 could be null, this was the fastest
             *  method of getting it to shut up.
             */
            if (temp1 is null)
                throw new ArgumentNullException(nameof(temp1), "Somehow, a null value got passed the two if statements in the overridden '==' operator. Bring a priest, demonic forces are about.");
            return temp1.Equals(temp2);
        }

        public static bool operator !=(NumSet temp1, NumSet temp2)
            => !(temp1 == temp2);

        public override string ToString()
        {
            if(IntSet == null)
            {
                throw new ArgumentNullException(nameof(IntSet), "HashSet of integers is null");
            }
            return String.Join(", ", IntSet);
        }
    }
}
