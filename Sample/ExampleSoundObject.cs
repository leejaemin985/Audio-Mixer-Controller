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

    /// <summary>
    /// 예제용 SoundObject 베이스 클래스.
    /// - ExampleSoundType 기준으로 사운드를 구분하고
    /// - Start 시점에 ExampleAudioMixerController에 자신을 등록한다.
    /// </summary>
    public abstract class ExampleSoundObject : SoundObject<ExampleSoundType>
    {

        // 도메인 리로드/게임 재시작 시 SoundObject 쪽의 정적 상태 초기화
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitExampleStatic()
        {
            InitializeStaticContext();
        }

        /// <summary>
        /// 사운드별 공간감(2D/3D 비율) 설정.
        /// 파생 클래스에서 0f(완전 2D) ~ 1f(완전 3D) 로 지정.
        /// </summary>
        protected abstract float spatialBlendSetting { get; }


        /// <summary>
        /// 파생 클래스에서 초기 재생 로직 등을 넣는 훅.
        /// 기본 구현은 spatialBlend만 적용.
        /// </summary>
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
