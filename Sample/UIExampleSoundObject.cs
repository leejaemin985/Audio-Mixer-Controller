using UnityEngine;

namespace MixerControllerExample
{
    public class UIExampleSoundObject : ExampleSoundObject
    {
        public override ExampleSoundType SoundType => ExampleSoundType.UI;

        protected override float spatialBlendSetting => 1f;

        [SerializeField] private AudioClip uiClip;

        protected override void Initialize()
        {
            base.Initialize();
            PlayOneShotUISound();
        }
        
        private void PlayOneShotUISound()
        {
            Audio.PlayOneShot(uiClip);
        }
    }
}
