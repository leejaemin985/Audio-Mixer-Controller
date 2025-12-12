using App.Utility;

namespace MixerControllerExample
{
    public class ExampleAudioMixerController : CommonAudioMixerController<ExampleSoundType>
    {
        private static ExampleAudioMixerController instance;
        public static ExampleAudioMixerController Instance => instance ?? (instance = GetNewInstance());

        private static ExampleAudioMixerController GetNewInstance()
        {
            ExampleAudioMixerController ret = new();
            ret.Initialize();
            return ret;
        }

        protected override string MIXER_PATH => "AudioMixer/ExampleAudioMixer";

        protected override string GROUP_BASE => "{0}_Group";

        protected override string VOLUME_BASE => "{0}_Volume";
    }
}
