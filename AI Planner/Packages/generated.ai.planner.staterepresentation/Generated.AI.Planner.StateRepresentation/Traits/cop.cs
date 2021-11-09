using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.AI.Planner.Traits;

namespace Generated.AI.Planner.StateRepresentation
{
    [Serializable]
    public struct cop : ITrait, IBufferElementData, IEquatable<cop>
    {
        public const string FieldReady2steal = "Ready2steal";
        public System.Boolean Ready2steal;

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(Ready2steal):
                    Ready2steal = (System.Boolean)value;
                    break;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait cop.");
            }
        }

        public object GetField(string fieldName)
        {
            switch (fieldName)
            {
                case nameof(Ready2steal):
                    return Ready2steal;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait cop.");
            }
        }

        public bool Equals(cop other)
        {
            return Ready2steal == other.Ready2steal;
        }

        public override string ToString()
        {
            return $"cop\n  Ready2steal: {Ready2steal}";
        }
    }
}
