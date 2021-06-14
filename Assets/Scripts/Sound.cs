using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
    [System.Serializable]
    public class Sound
    {
        public AudioClip clip;
        public AudioMixerGroup audioMixerGroup;

        public string name;

        [Range(0f, 1f)]
        public float volume;

        [Range(0f, 3f)]
        public float pitch;

        // Play in loop?
        public bool loop = false;

        // The audio source clip
        [HideInInspector]
        public AudioSource source;
    }
}