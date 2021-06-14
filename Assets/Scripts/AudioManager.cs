using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        // The only existing instance
        public static AudioManager instance = null;

        // Contain all the playable sounds
        public Sound[] sounds;

        /// <summary>
        /// Initialize the class using Singleton patern.
        /// </summary>
        /// <remarks>The class is a DontDestroy</remarks>
        void Awake()
        {
            // Singleton pattern
            if (instance == null) { instance = this; }
            else
            {
                Destroy(gameObject);
                return;
            }

            // Dont destroy when changing scene
            DontDestroyOnLoad(gameObject);

            // Foreach sounds we initialized every parameter
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;

                s.source.outputAudioMixerGroup = s.audioMixerGroup;
            }
        }

        /// <summary>
        /// Play the Theme sound at startup
        /// </summary>
        private void Start() { Play("Theme"); }

        /// <summary>
        /// Stop the specified sound.
        /// If it is not found, we print a warning call.
        /// </summary>
        /// <param name="name">The sound's name</param>
        private void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s != null && s.source.isPlaying) { s.source.Stop(); }
            else if (s == null) { Debug.LogWarning("Sound : " + name + " not found !"); }
        }

        /// <summary>
        /// Play the specified sound.
        /// If it is not found, we print a warning call.
        /// </summary>
        /// <param name="name">The sound's name</param>
        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s != null) { s.source.Play(); }
            else { Debug.LogWarning("Sound : " + name + " not found !"); }
        }
    }
}