using Unity.Entities;

namespace thelebaron.entities
{
    /// <summary>
    /// Simple component that allows the LinkedAudioSystem to relay play & stop to a companion gameobject.
    /// </summary>
    public struct SoundLink : IComponentData
    {
        public bool Play;
        public bool Stop;
    }
}