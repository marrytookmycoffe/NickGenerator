using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace slowaTest
{
    [TestClass]
    public class Permutation
    {
        [TestMethod]
        public void TestMethod1()
        {
            String tekst = "";
            var list = new List<string> { "a", "b", "c", "d", "e" };
            var result = GetPermutations(list, 3);
            foreach (var perm in result)
            {
                foreach (var c in perm)
                {
                    tekst =$"{tekst}{c} ";
                }
                tekst = $"{tekst}\n";
            }

            tekst = $"{tekst}\n";
        }


        static void Main(string[] args)
        {

        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
    }
}
