using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class ImpliesProposition : BinaryProposition
    {   
        public ImpliesProposition(BaseProposition leftProposition, BaseProposition rightProposition) : base(leftProposition, rightProposition)
        {
        }

        internal override bool CalculateValue()
        {
            return RightProposition.CalculateValue() || LeftProposition.CalculateValue() == RightProposition.CalculateValue();
        }
        
        public override string ToStringVariable()
        {
            return $"({LeftProposition.ToStringVariable()} => {RightProposition.ToStringVariable()})";
        }
        
        public override string ToString()
        {
            return $"({LeftProposition} => {RightProposition})";
        }
    }
}