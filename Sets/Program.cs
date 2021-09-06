﻿using System;

namespace DiscreteMath
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Sets-----");
            ShowcaseMultiSets();
            Console.WriteLine();
            Console.WriteLine("---Multiset---");
            ShowcaseSets();
            
            Console.ReadLine();
        }

        private static void ShowcaseSets()
        {
            var setA = new Set.Set(new[] {0, 0, 1, 2, 3, 4});
            var setB = new Set.Set(new[] {2, 3, 4, 4, 5, 6, 7});
            Console.WriteLine($"SetA: {setA}");
            Console.WriteLine($"SetB: {setB}");

            var memberA = 1;
            var memberB = 90;
            Console.WriteLine($"MemberA: {memberA} is member og SetA {setA.IsMember(memberA)}");
            Console.WriteLine($"MemberB: {memberB} is member og SetA {setA.IsMember(memberB)}");

            var union = setA.UnionWith(setB);
            Console.WriteLine($"Union og setA and setB: {union}");

            var intersection = setA.IntersectsWith(setB);
            Console.WriteLine($"Intersection og setA and setB: {intersection}");

            Console.WriteLine($"Cardinality of setA: {setA.Cardinality()}");
            Console.WriteLine($"Cardinality of setB: {setB.Cardinality()}");
        }

        private static void ShowcaseMultiSets()
        {
            var setA = new MultiSet.MultiSet(new[] {0, 0, 1, 2, 3, 4});
            var setB = new MultiSet.MultiSet(new[] {2, 3, 4, 4, 5, 6, 7});
            Console.WriteLine($"SetA: {setA}");
            Console.WriteLine($"SetB: {setB}");

            var memberA = 1;
            var memberB = 90;
            Console.WriteLine($"MemberA: {memberA} is member og SetA {setA.IsMember(memberA)}");
            Console.WriteLine($"MemberB: {memberB} is member og SetA {setA.IsMember(memberB)}");

            var union = setA.UnionWith(setB);
            Console.WriteLine($"Union og setA and setB: {union}");

            var intersection = setA.IntersectsWith(setB);
            Console.WriteLine($"Intersection og setA and setB: {intersection}");

            Console.WriteLine($"Cardinality of setA: {setA.Cardinality()}");
            Console.WriteLine($"Cardinality of setB: {setB.Cardinality()}");
        }
    }
}
