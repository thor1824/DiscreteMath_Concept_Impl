using System.Collections.Generic;

namespace DMath.Propositions.Abstracts
{
    public abstract class BaseProposition
    {
        public bool Evaluate(IDictionary<string, bool> variableToValueMap)
        {
            SetVariableState(variableToValueMap);
            return CalculateValue();
        }

        internal abstract void SetVariableState(IDictionary<string, bool> variableToValueMap);
        internal abstract bool CalculateValue();
        public abstract bool IsTautology();

        public abstract bool IsSatisfiable();
        public abstract string[] GetDefinedVariables();

        public string ToString(IDictionary<string, bool> variableToValueMap)
        {
            SetVariableState(variableToValueMap);
            return ToString();
        }

        public abstract string ToStringVariable();
    }
}