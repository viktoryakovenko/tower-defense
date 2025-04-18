using System.Collections.Generic;
using UnityEngine;

namespace Code.StaticData.Sounds
{
    [CreateAssetMenu(fileName = "SoundLibrary", menuName = "StaticData/Sound Library")]
    public class SoundStaticData : ScriptableObject
    {
        public List<SoundConfig> Configs;
    }
}
