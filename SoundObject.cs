using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable UDR0001
namespace App.Utility
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class SoundObject<TEnum> : MonoBehaviour where TEnum : Enum
	{
		private static bool isInitialized = false;
		private static HashSet<SoundObject<TEnum>> playingSoundObject;

		protected static void RegisterPlayingObject(SoundObject<TEnum> soundObject) => playingSoundObject?.Add(soundObject);
		protected static void UnregisterPlayingObject(SoundObject<TEnum> soundObject) => playingSoundObject?.Remove(soundObject);
		
		/// <summary>
		/// 각 구체 타입(파생 클래스)에서 RuntimeInitializeOnLoadMethod를 통해 반드시 호출해야 합니다.
		/// </summary>
		protected static void InitializeStaticContext()
		{
			if (isInitialized) return;

			playingSoundObject = new();
			AudioSettings.OnAudioConfigurationChanged += OnAudioConfigurationChanged;

			isInitialized = true;
			Debug.Log($"Set SoundObject Static Initialize (Type<{typeof(TEnum)}>)");
		}

		private static void OnAudioConfigurationChanged(bool deviceWasChanged)
		{
			foreach (var so in playingSoundObject)
			{
				so.ResolvePlayBackContinuation();
			}
		}

		private bool initialized = false;
		private AudioSource audioSource = default;

		public AudioSource Audio
		{
			get
			{
				if (initialized == false) throw new InvalidOperationException("SoundObject is not initialized.");
				if (audioSource == null)
				{
					audioSource = GetComponent<AudioSource>();
				}
				return audioSource;
			}
		}

		public abstract TEnum SoundType { get; }
		private double startDSP;

		public virtual void Initialize(AudioMixerGroup outputGroup)
		{
			if (outputGroup == null) return;

			initialized = true;
			Audio.outputAudioMixerGroup = outputGroup;
		}

		public void PlayClip(AudioClip audioClip, bool loop = false, float pitch = 1)
		{
			Audio.loop = loop;
			Audio.pitch = pitch;
			Audio.clip = audioClip;
			Audio.Play();

			startDSP = AudioSettings.dspTime;
			RegisterPlayingObject(this);
		}

		public void PlayOneShot(AudioClip audioClip)
		{
			Audio.PlayOneShot(audioClip);
		}

		public void SetSpatialBlend(float value)
		{
			Audio.spatialBlend = value;
		}

		public void SetDistance(float min, float max, AudioRolloffMode audioRolloffMode = AudioRolloffMode.Linear)
		{
			Audio.rolloffMode = audioRolloffMode;
			Audio.minDistance = min;
			Audio.maxDistance = max;
		}

		private void ResolvePlayBackContinuation()
		{
			if (Audio.clip == null ||
			!Audio.loop && Audio.clip.length < (AudioSettings.dspTime - startDSP))
            {
                UnregisterPlayingObject(this);
				return;
            }

			Audio.time = (float)(AudioSettings.dspTime - startDSP) % Audio.clip.length;
			Audio.Play();
		}

		private void OnDestroy()
		{
			UnregisterPlayingObject(this);
		}
	}
}
#pragma warning restore UDR0001
