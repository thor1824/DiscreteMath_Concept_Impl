using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class XorProposition : BinaryProposition
    {
        public XorProposition(BaseProposition leftProposition, BaseProposition rightProposition) : base(leftProposition,
            rightProposition)
        {
        }

        internal override bool CalculateValue()
        {
            return LeftProposition.CalculateValue() ^ RightProposition.CalculateValue();
        }

        public override string ToString()
        {
            return $"({LeftProposition} XOR {RightProposition})";
        }

        public override string ToStringVariable()
        {
            return $"({LeftProposition.ToStringVariable()} XOR {RightProposition.ToStringVariable()})";
        }
    }

    public class EquivalenceProposition : BinaryProposition
    {
        public EquivalenceProposition(BaseProposition leftProposition, BaseProposition rightProposition) : base(
            leftProposition, rightProposition)
        {
        }

        internal override bool CalculateValue()
        {
            return LeftProposition.CalculateValue() == RightProposition.CalculateValue();
        }

        public override string ToString()
        {
            return $"({LeftProposition} <=> {RightProposition})";
        }

        public override string ToStringVariable()
        {
            return $"({LeftProposition.ToStringVariable()} <=> {RightProposition.ToStringVariable()})";
        }
    }
}