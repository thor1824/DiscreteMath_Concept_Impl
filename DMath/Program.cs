using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Console.WriteLine();
            DoAndPrintProposition(states, andProposition);

            // OR
            var orProposition = new OrProposition(
                new ValueProposition("a"),
                new ValueProposition("b")
            );

            Console.WriteLine();
            DoAndPrintProposition(states, orProposition);

            // Not
            var notProposition = new NotProposition(orProposition);

            Console.WriteLine();
            DoAndPrintProposition(states, notProposition);

            // Implies
            var impliesProposition = new ImpliesProposition(
                new AndProposition(
                    new ValueProposition("a"),
                    new ValueProposition("b")
                ),
                new ValueProposition("c")
            );
            Console.WriteLine();
            DoAndPrintProposition(states, impliesProposition);

            // OR
            var xorProposition = new XorProposition(
                new ValueProposition("a"),
                new ValueProposition("b")
            );

            Console.WriteLine();
            DoAndPrintProposition(states, xorProposition);

            // tautology
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
            
            Console.WriteLine();
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), tautology);


            // Satisfiable
            var unsatisfiable = new AndProposition(
                new ValueProposition("p"),
                new NotProposition(new ValueProposition("p"))
            );
            
            Console.WriteLine();
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), unsatisfiable);

            // tautology speed
            var (test1, v1) = buildProposition(12);
            var (test2, v2) = buildProposition(16);
            // var (test3, v3) = buildProposition(20);
            var sw = new Stopwatch();
            Console.WriteLine($"\n---SpeedTest 1 with {v1} Variables");
            sw.Start();
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), test1);
            sw.Stop();
            Console.WriteLine($"---SpeedTest 1 took {sw.ElapsedMilliseconds/ 1000.0} secs");
            sw.Reset();
            Console.WriteLine($"\n---SpeedTest 2 with {v2} Variables");
            sw.Start();
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), test2);
            sw.Stop();
            Console.WriteLine($"---SpeedTest 2 took {sw.ElapsedMilliseconds/ 1000.0} secs");
            /*
            sw.Reset();
            Console.WriteLine($"\n---SpeedTest 3 with {v3} Variables");
            sw.Start();
            DoAndPrintProposition(new List<IDictionary<string, bool>>(), test3);
            sw.Stop();
            Console.WriteLine($"---SpeedTest 3 took {sw.ElapsedMilliseconds / 1000.0} secs");
            */
        }

        public static (BaseProposition prop, int nVariable) buildProposition(int count = 10)
        {
            BaseProposition super = null;
            var loops = count % 4 == 0 ? count / 4 : count / 4 + 1;
            for (int i = 0; i < loops; i++)
            {
                var part1 = new ImpliesProposition(
                    new ValueProposition("a" + i),
                    new ValueProposition("b" + i)
                );
                var part2 = new ImpliesProposition(
                    new NotProposition(new ValueProposition("c" + i)),
                    new NotProposition(new ValueProposition("d" + i))
                );

                if (i == 0)
                {
                    super = new AndProposition(part1, part2);
                    continue;
                }

                if (i % 2 == 0)
                {
                    var temp1 = new ImpliesProposition(part1, part2);
                    var temp = new OrProposition(super, temp1);
                    super = temp;
                }
                else
                {
                    var temp1 = new AndProposition(part1, part2);
                    var temp = new XorProposition(temp1, super);
                    super = temp;
                }
            }

            return (super, loops * 4);
        }

        private static void DoAndPrintProposition(List<IDictionary<string, bool>> states, BaseProposition proposition)
        {
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