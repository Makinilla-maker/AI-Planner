using System;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Collections;
using Unity.Entities;

namespace Generated.Semantic.Traits
{
    [Serializable]
    public partial struct copData : ITraitData, IEquatable<copData>
    {
        public System.Boolean Ready2steal;

        public bool Equals(copData other)
        {
            return Ready2steal.Equals(other.Ready2steal);
        }

        public override string ToString()
        {
            return $"cop: {Ready2steal}";
        }
    }
}
