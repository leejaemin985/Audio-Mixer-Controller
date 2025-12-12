using UnityEngine;
using App.Utility;

namespace MixerControllerExample
{
    public enum ExampleSoundType
    {
        Effect,
        BGM,
        UI
    }

    public abstract class ExampleSoundObject : SoundObject<ExampleSoundType>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitExampleStatic()
        {
            InitializeStaticContext();
        }

        protected abstract float spatialBlendSetting { get; }

        private void Start()
        {
            ExampleAudioMixerController.Instance.InitSoundObject(this);
            Initialize();
        }
        
        protected virtual void Initialize()
        {
            Audio.spatialBlend = spatialBlendSetting;
        }
    }
}
