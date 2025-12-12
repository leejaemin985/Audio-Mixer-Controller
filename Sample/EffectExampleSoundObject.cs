using UnityEngine;

namespace MixerControllerExample
{
    public class EffectExampleSoundObject : ExampleSoundObject
    {
        public override ExampleSoundType SoundType => ExampleSoundType.Effect;

        protected override float spatialBlendSetting => .5f;


        [SerializeField] private AudioClip effectClip;

        protected override void Initialize()
        {
            base.Initialize();
            PlayOneShotEffectSound();
        }

        private void PlayOneShotEffectSound()
        {
            Audio.PlayOneShot(effectClip);
        }
    }
}
