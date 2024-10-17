using System;
using UnityEngine;

namespace Sound
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Music")]
        [SerializeField] private AudioClip backgroundMusic;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            PlayMusicLooped(backgroundMusic);
        }

        public void PlayMusicLooped(AudioClip musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }

        public void PlayOneShotSound(AudioClip soundClip)
        {
            sfxSource.PlayOneShot(soundClip);
        }

        public void StopMusic()
        {
            if (musicSource != null)
            {
                musicSource.Stop();
            }
        }

        public void StopAllSounds()
        {
            if (musicSource != null)
            {
                musicSource.Stop();
            }
            if (sfxSource != null)
            {
                sfxSource.Stop();
            }
        }
    }
}
