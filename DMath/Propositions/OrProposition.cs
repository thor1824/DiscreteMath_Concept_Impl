using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class OrProposition : BinaryProposition
    {   
        public OrProposition(BaseProposition leftProposition, BaseProposition rightProposition) : base(leftProposition, rightProposition)
        {
        }

        internal override bool CalculateValue()
        {
            return LeftProposition.CalculateValue() || RightProposition.CalculateValue();
        }
        
        public override string ToString()
        {
            return $"({LeftProposition} OR {RightProposition})";
        }
        
        public override string ToStringVariable()
        {
            return $"({LeftProposition.ToStringVariable()} OR {RightProposition.ToStringVariable()})";
        }
    }
}