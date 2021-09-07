using System;
using DMath.Propositions.Abstracts;

namespace DMath.Propositions
{
    public class AndProposition : BinaryProposition
    {   
        public AndProposition(BaseProposition leftProposition, BaseProposition rightProposition) : base(leftProposition, rightProposition)
        {
        }

        internal override bool CalculateValue()
        {
            return LeftProposition.CalculateValue() && RightProposition.CalculateValue();
        }

        public override string ToStringVariable()
        {
            return $"({LeftProposition.ToStringVariable()} AND {RightProposition.ToStringVariable()})";
        }

        public override string ToString()
        {
            return $"({LeftProposition} AND {RightProposition})";
        }
    }
}