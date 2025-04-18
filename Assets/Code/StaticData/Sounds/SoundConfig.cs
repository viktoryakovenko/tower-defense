using System;
using Code.Audio.Services.SFXService;
using UnityEngine;

namespace Code.StaticData.Sounds
{
    [Serializable]
    public class SoundConfig
    {
        public SoundId Id;
        public AudioClip Clip;
        public float Volume = 1f;
        public bool Loop = false;
        public bool RandomPitch = false;
        public Vector2 PitchRange = new Vector2(0.95f, 1.05f);
    }
}
