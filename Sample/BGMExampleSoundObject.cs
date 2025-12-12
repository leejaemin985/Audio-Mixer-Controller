using UnityEngine;

namespace MixerControllerExample
{
    public class BGMExampleSoundObject : ExampleSoundObject
    {
        public override ExampleSoundType SoundType => ExampleSoundType.BGM;

        protected override float spatialBlendSetting => 1f;

        [SerializeField] private AudioClip bgmClip;


        protected override void Initialize()
        {
            base.Initialize();
            StartBGM();
        }

        private void StartBGM()
        {
            Audio.loop = true;
            Audio.clip = bgmClip;
            Audio.Play();
        }
    }
}
