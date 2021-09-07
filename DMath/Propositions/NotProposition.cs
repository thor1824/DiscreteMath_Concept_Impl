using System.Collections.Generic;
using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class NotProposition: BaseProposition
    {
        private readonly BaseProposition _proposition;

        public NotProposition(BaseProposition proposition)
        {
            _proposition = proposition;
        }

        internal override void SetVariableState(IDictionary<string, bool> variableToValueMap)
        {
            
            _proposition.SetVariableState(variableToValueMap);
        }

        internal override bool CalculateValue()
        {
            return !_proposition.CalculateValue();
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
            return _proposition.GetDefinedVariables();
        }
        
        public override string ToStringVariable()
        {
            return $"!{_proposition.ToStringVariable()}";
        }
        
        public override string ToString()
        {
            return $"!{_proposition}";
        }
    }
}