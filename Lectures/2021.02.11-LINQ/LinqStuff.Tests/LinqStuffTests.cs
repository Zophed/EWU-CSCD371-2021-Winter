using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace LinqStuff.Tests
{
    //public static class ArrayEx
    //{
    //    public static IEnumerable<T> Where<T>(this IEnumerable<T> array, Func<T, bool> filter)
    //    {
    //        foreach(T item in array)
    //        {
    //            // return this item;
    //        }
    //        return default;
    //    }
    //}

#if false // Covariance/Contravariance
            IThingOut<string> stringData = IThing<object> 
            IThingIn<object> objectData = IThing<string> // Data is of type string
            objectData.Add(Guid.NewGuid());
            string text = (object)IThing.Data;
#endif

    record Thing(int umber);


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] array = new string[]{ "first", "second", "third" };
            int[] numbers = default;
            // What is the count of the items
            // Sort all the items
            // Search for specific items
            // Add/remove items
            // Rearrange items?
            // Project out the collection:
            //      To create different types of items
            //      Filter the items
            // Distinct
            // Aggregate
            // GroupBy

            IEnumerable<int> even = numbers.Where<int>(item => (item % 2) == 0);

            IEnumerable<string> itemsContainLetterd = array.Where(
                item => item.Contains('d')
                );

            IEnumerable<Thing> numbersAsText = numbers.Select(item => new Thing(item));
            IEnumerable<(int,int)> tuples = numbers.Select(item => (item, item));
            tuples.Count();
            itemsContainLetterd.Sum(item => item.Length);
            numbers = even.ToArray();

            IEnumerator<string> enumerator = itemsContainLetterd.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            foreach(string item in itemsContainLetterd)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void DefferedExecution()
        {
            int executionCount = 0;
            IEnumerable<string> methods = typeof(string).GetMembers().Select(item => item.Name);
            Assert.IsTrue(methods.Contains("Trim"));
            
            methods = methods.Where(item =>
            {
                executionCount++;
                return item.StartsWith("G");
            });
            methods = methods.Where(item => item.Length > 4);
            Assert.IsTrue(methods.Count() > 0);
            Assert.AreEqual<int>(8, methods.Count());
            Assert.AreEqual<int>(332, executionCount);
            Assert.AreEqual<int>(8, methods.Count());
            Assert.AreEqual<int>(498, executionCount);
            methods = methods.AsEnumerable();
            List<string> list = methods.ToList();
            Assert.AreEqual<int>(664, executionCount);
            foreach (string text in list) { }
            Assert.AreEqual<int>(664, executionCount);
            
        }

        [TestMethod]
        public void LinqMethods()
        {
            IEnumerable<string> methods = typeof(string).GetMembers().Select(item => item.Name);

            // Are there any items that match the predicate
            Assert.IsTrue(methods.Any(item => item.StartsWith('G')));

            // Projection
            IEnumerable<int> lengthsQuery = methods.Select(item => item.Length);

            // Filter
            IEnumerable<string> filterdQuery = methods.Where(item => item.StartsWith('G')).ToList();

            // Project and filter
            lengthsQuery = methods.Where(item => item.StartsWith('G')).Select(item => item.Length);

            List<int> list = methods
                .Where(
                    item => item.StartsWith('G'))
                .Select(
                    item => item.Length)
                .ToList();



        }

        [TestMethod]
        public void GivenMembersOnString_AggregateTheTotalNumberOfCharacterForAllMembers_Returns842()
        {
            IEnumerable<string> methods = typeof(string).GetMembers().Select(item => item.Name);

            int result = methods.Aggregate(0, (total, next) => total += next.Length);
            int expected = methods.Select(item => item.Length).Sum();

            // Return the total number of characters in all members using LINQ.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void ReturnMethodInfoObjectWithTheLongestNameThatBeginsWithGet()
        {
            IEnumerable<MemberInfo> members = typeof(string).GetMethods();
            IEnumerable<MethodInfo> methods = members.Where(item => item.MemberType == MemberTypes.Method).Cast<MethodInfo>();
            // or just
            methods = typeof(string).GetMethods();

            methods = methods.Where(item => item.Name.StartsWith("Get"));

            // Possible: Preferably avoid calling ToList(), as it has a for each NOT RECOMMENDED unless you need a list
                methods.ToList().ForEach((item) =>
                {
                    Assert.IsTrue(item.Name.StartsWith("Get"));
                });
            
            // Using a foreach loop; simple, but "noisey"
            foreach (string item in methods.Select(item=>item.Name))
            {
                Assert.IsTrue(item.StartsWith("Get"));
            }

            // or using LINQ (Obviously the best way to do anything)
            Assert.IsTrue(methods.All(item=>item.Name.StartsWith("Get")));// Simple is better

            // Search Aggregate & LINQ
            MethodInfo actual = methods.Aggregate(
                (longestMethod, nextItem) => longestMethod.Name.Length > nextItem.Name.Length ? longestMethod : nextItem);

            // Use OrderBy()
            MethodInfo expected = methods.OrderBy(item => item.Name.Length).Last();

                // Check this out, order by length and then order them alphabetically
                /* Bad Code */ MethodInfo expected2 = methods.OrderBy(item => item.Name.Length).OrderBy(item => item).Last();// This will not work, OrderBy() overrides all previous OrderBy()

                MethodInfo expected3 = methods.OrderBy(item => item.Name.Length).ThenBy(item => item).Last();// This will use both OrderBy() and then apply the ThenBy() to apply both sorting

            Assert.AreEqual<string>(expected.Name, actual.Name);
        }
    }
}
