using Code.Towers;
using UnityEngine;

namespace Code.Infrastructure.Services.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreateTower(TowerTypeId typeId, Transform parent);
    }
}
