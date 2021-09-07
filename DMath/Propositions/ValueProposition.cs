using System.Collections.Generic;
using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class ValueProposition: BaseProposition
    {
        private readonly string _variableName; 
        private bool _variableValue; 

        public ValueProposition(string variableName)
        {
            _variableName = variableName;
        }

        internal  override void SetVariableState(IDictionary<string, bool> variableToValueMap)
        {
            _variableValue = variableToValueMap.ContainsKey(_variableName) && variableToValueMap[_variableName];
        }

        internal  override bool CalculateValue()
        {
            return _variableValue;
        }

        public override bool IsTautology()
        {
            return false;
        }

        public override bool IsSatisfiable()
        {
            return true;
        }

        public override string[] GetDefinedVariables()
        {
            return new[] {_variableName};
        }

        public override string ToStringVariable()
        {
            return _variableName;
        }

        public override string ToString()
        {
            return "" + _variableValue;
        }
    }
}