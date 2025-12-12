using App.Utility;

namespace MixerControllerExample
{

    /// <summary>
    /// ExampleSoundType 기반으로 AudioMixer 그룹/파라미터를 제어하는 예제 컨트롤러.
    /// 실제 프로젝트에서는 이 클래스를 참고해서
    /// 프로젝트에 맞는 전용 컨트롤러를 구현하면 된다.
    /// </summary>
    public class ExampleAudioMixerController : CommonAudioMixerController<ExampleSoundType>
    {

        /// <summary>
        /// 전역에서 접근 가능한 싱글턴 인스턴스.
        /// 내부적으로 new 로 생성되는 순수 C# 객체이며, 씬에 붙는 컴포넌트가 아니다.
        /// </summary>
        private static ExampleAudioMixerController instance;
        public static ExampleAudioMixerController Instance => instance ?? (instance = GetNewInstance());

        private static ExampleAudioMixerController GetNewInstance()
        {
            ExampleAudioMixerController ret = new();
            ret.Initialize(); // CommonAudioMixerController 쪽 초기화
            return ret;
        }

        // Resources/AudioMixer/ExampleAudioMixer.mixer 를 로드하는 예제 경로.
        protected override string MIXER_PATH => "AudioMixer/ExampleAudioMixer";

        // 그룹 이름 포맷 예: "BGM_Group", "Effect_Group"
        protected override string GROUP_BASE => "{0}_Group";

        // 볼륨 파라미터 이름 포맷 예: "BGM_Volume", "Effect_Volume"
        protected override string VOLUME_BASE => "{0}_Volume";
    }
}
