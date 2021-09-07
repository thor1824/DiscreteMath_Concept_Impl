using System;
using System.Collections.Generic;
using DMath.Propositions;
using DMath.Propositions.Abstracts;
using DMath.Sets;

namespace DMath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShowcaseSets();
            ShowcaseMultiSets();
            ShowcasePropositions();

            Console.ReadLine();
        }

        private static void ShowcasePropositions()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------Propositions--------------");

            var stateA = new Dictionary<string, bool> {{"a", true}, {"b", true}, {"c", false}};
            var stateB = new Dictionary<string, bool> {{"a", true}, {"b", false}, {"c", true}};
            var stateC = new Dictionary<string, bool> {{"a", false}, {"b", true}, {"c", false}};
            var stateD = new Dictionary<string, bool> {{"a", false}, {"b", false}, {"c", false}};
            var states = new List<IDictionary<string, bool>> {stateA, stateB, stateC, stateD};
            // AND
            var andProposition = new AndProposition(
                new ValueProposition("a"),
                new ValueProposition("b")
            );

            DoAndPrintProposition(states, andProposition);

            // OR
            var orProposition = new OrProposition(
                new ValueProposition("a"),
                new ValueProposition("b")
            );

            DoAndPrintProposition(states, orProposition);

            // Not
            var notProposition = new NotProposition(orProposition);

            DoAndPrintProposition(states, notProposition);

            // Implies
            var impliesProposition = new ImpliesProposition(
                new AndProposition(
                    new ValueProposition("a"),
                    new ValueProposition("b")
                ),
                new ValueProposition("c")
            );

            DoAndPrintProposition(states, impliesProposition);

            // OR
            var xorProposition = new XorProposition(
                new ValueProposition("a"),
                new ValueProposition("b")
            );

            DoAndPrintProposition(states, xorProposition);

            var tautology = new EquivalenceProposition(
                new ImpliesProposition(
                    new ValueProposition("p"),
                    new ValueProposition("q")
                ),
                new ImpliesProposition(
                    new NotProposition(new ValueProposition("q")),
                    new NotProposition(new ValueProposition("p"))
                )
            );
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), tautology);
            var unsatisfiable = new AndProposition(
                new ValueProposition("p"),
                new NotProposition(new ValueProposition("p"))
            );
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), unsatisfiable);
        }

        private static void DoAndPrintProposition(List<IDictionary<string, bool>> states, BaseProposition proposition)
        {
            Console.WriteLine();
            Console.WriteLine(proposition.GetType().Name + ": " + proposition.ToStringVariable());
            Console.WriteLine("Is Tautology: " + proposition.IsTautology());
            Console.WriteLine("Is Satisfiable: " + proposition.IsSatisfiable());
            foreach (var state in states)
                Console.WriteLine($"{proposition.ToString(state)} is {proposition.Evaluate(state)}");
        }

        private static void ShowcaseSets()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------Sets--------------");
            Console.WriteLine("");
            var setA = new Set(new[] {0, 0, 1, 2, 3, 4});
            var setB = new Set(new[] {2, 3, 4, 4, 5, 6, 7});
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
            Console.WriteLine("");
            Console.WriteLine("------------Multiset------------");
            Console.WriteLine("");

            var setA = new MultiSet(new[] {0, 0, 1, 2, 3, 4, 4});
            var setB = new MultiSet(new[] {2, 3, 4, 4, 4, 5, 6, 7});
            Console.WriteLine($"SetA: {setA}");
            Console.WriteLine($"SetB: {setB}");

            var memberA = 1;
            var memberB = 90;
            var memberC = 4;
            Console.WriteLine($"MemberA: {memberA} is member og SetA {setA.IsMember(memberA)}");
            Console.WriteLine($"MemberB: {memberB} is member og SetA {setA.IsMember(memberB)}");
            Console.WriteLine(
                $"MemberC: {memberC} is member og SetB {setB.IsMember(memberC)} and has {setB.InstancesOfMember(memberC)} instances");

            var union = setA.UnionWith(setB);
            Console.WriteLine($"Union og setA and setB: {union}");

            var intersection = setA.IntersectsWith(setB);
            Console.WriteLine($"Intersection og setA and setB: {intersection}");

            Console.WriteLine($"Cardinality of setA: {setA.Cardinality()}");
            Console.WriteLine($"Cardinality of setB: {setB.Cardinality()}");
        }
    }
}