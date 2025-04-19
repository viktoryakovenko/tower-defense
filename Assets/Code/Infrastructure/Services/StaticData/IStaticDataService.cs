using Code.Audio.Services.SFXService;
using Code.StaticData;
using Code.StaticData.Sounds;
using Code.StaticData.Windows;
using Code.Towers;
using Code.UI.Services.Windows;

namespace Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        TowerStaticData ForTower(TowerTypeId typeId);
        WindowConfig ForWindow(WindowId windowId);
        SoundConfig ForSound(SoundId soundId);
    }
}
