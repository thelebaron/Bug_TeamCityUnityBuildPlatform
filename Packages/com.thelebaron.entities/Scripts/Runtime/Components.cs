using Unity.Entities;
using Unity.Mathematics;

namespace thelebaron.entities
{
    public struct Velocity : IComponentData
    {
        public float3 Value;
    }

    public struct BallisticMotion : IComponentData
    {
        public float Drag; // 0.0025f
        public float GravityFalloff; // 0.4
    }
}