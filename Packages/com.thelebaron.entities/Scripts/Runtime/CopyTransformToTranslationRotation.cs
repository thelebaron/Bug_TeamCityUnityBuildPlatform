using Unity.Entities;

namespace thelebaron.entities
{
    /// <summary>
    /// Component that allows for copy of transform data to an entity's local position and rotation.
    /// </summary>
    [GenerateAuthoringComponent]
    public struct CopyTransformToTranslationRotation :  IComponentData
    {
    }
}