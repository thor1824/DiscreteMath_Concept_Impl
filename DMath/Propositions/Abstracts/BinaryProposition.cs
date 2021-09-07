using System;
using System.Collections.Generic;
using System.Linq;

namespace DMath.Propositions.Abstracts
{
    public abstract class BinaryProposition : BaseProposition
    {
        protected readonly BaseProposition LeftProposition;
        protected readonly BaseProposition RightProposition;

        protected BinaryProposition(BaseProposition leftProposition, BaseProposition rightProposition)
        {
            LeftProposition = leftProposition;
            RightProposition = rightProposition;
        }

        internal override void SetVariableState(IDictionary<string, bool> variableToValueMap)
        {
            LeftProposition.SetVariableState(variableToValueMap);
            RightProposition.SetVariableState(variableToValueMap);
        }

        public override bool IsSatisfiable()
        {
            var variables = GetDefinedVariables().Distinct().ToArray();
            var truthTable = GetTruthTable(variables);

            return truthTable.Any(Evaluate);
        }

        public override bool IsTautology()
        {
            var variables = GetDefinedVariables().Distinct().ToArray();
            var truthTable = GetTruthTable(variables);

            return truthTable.All(Evaluate);
        }

        private static IEnumerable<Dictionary<string, bool>> GetTruthTable(IReadOnlyCollection<string> variables)
        {
            var truthTable = new List<Dictionary<string, bool>>();
            var rows = (int) Math.Pow(2, variables.Count);
            var interval = 1;
            var start = false;
            foreach (var variable in variables)
            {
                for (var i = 0; i < rows; i++)
                {
                    if (truthTable.Count - 1 < i) truthTable.Add(new Dictionary<string, bool>());

                    if (i == 0)
                    {
                        truthTable[i].Add(variable, start);
                        continue;
                    }

                    if (interval == 1)
                    {
                        truthTable[i].Add(variable, (i + 1) % 2 == 0);
                        continue;
                    }

                    if (i % interval == 0) start = !start;

                    truthTable[i].Add(variable, start);
                }

                start = false;
                interval += interval;
            }

            return truthTable;
        }

        public override string[] GetDefinedVariables()
        {
            var leftVariables = LeftProposition.GetDefinedVariables();
            var rightVariables = RightProposition.GetDefinedVariables();
            return leftVariables.Concat(rightVariables).ToArray();
        }
    }
}