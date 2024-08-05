using Code.StaticData;
using Code.Towers;

namespace Code.Infrastructure.Services
{
    public interface IStaticDataService
    {
        void Load();
        TowerStaticData ForTower(TowerTypeId typeId);
    }
}
