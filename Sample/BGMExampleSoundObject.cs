using UnityEngine;

namespace MixerControllerExample
{
    /// <summary>
    /// BGM 재생용 예제 SoundObject.
    /// 씬이 시작되면 자동으로 지정된 BGM을 루프 재생한다.
    /// </summary>
    public class BGMExampleSoundObject : ExampleSoundObject
    {
        public override ExampleSoundType SoundType => ExampleSoundType.BGM;

        protected override float spatialBlendSetting => 0f;

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
