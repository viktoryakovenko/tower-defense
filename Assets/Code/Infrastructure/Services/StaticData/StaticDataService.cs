using System.Collections.Generic;
using System.Linq;
using Code.Audio.Services.SFXService;
using Code.StaticData;
using Code.StaticData.Sounds;
using Code.StaticData.Windows;
using Code.Towers;
using Code.UI.Services.Windows;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataTowersPath = "StaticData/Towers";
        private const string StaticDataWindowsPath = "StaticData/UI/WindowStaticData";
        private const string StaticDataSoundsPath = "StaticData/SoundLibrary";

        private Dictionary<TowerTypeId, TowerStaticData> _towers;
        private Dictionary<WindowId, WindowConfig> _windows;
        private Dictionary<SoundId, SoundConfig> _sounds;

        public StaticDataService() => Load();

        public void Load()
        {
            _towers = Resources
                .LoadAll<TowerStaticData>(StaticDataTowersPath)
                .ToDictionary(x => x.TowerTypeId, x => x);

            _windows = Resources
                .Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);

            _sounds = Resources
                .Load<SoundsStaticData>(StaticDataSoundsPath)
                .Configs
                .ToDictionary(x => x.SoundId, x => x);
        }

        public TowerStaticData ForTower(TowerTypeId typeId) =>
            _towers.TryGetValue(typeId, out TowerStaticData staticData)
                ? staticData
                : null;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windows.TryGetValue(windowId, out WindowConfig staticData)
                ? staticData
                : null;

        public SoundConfig ForSound(SoundId soundId) =>
            _sounds.TryGetValue(soundId, out SoundConfig staticData)
                ? staticData
                : null;
    }
}
