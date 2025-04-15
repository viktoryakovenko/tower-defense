using Code.Infrastructure.AssetManagement;
using Code.UI.Elements;
using Code.UI.Elements.Commands;
using Code.UI.Services.Windows;
using UnityEngine;

namespace Code.UI.Services.Factory
{
    public class MenuFactory : IMenuFactory
    {
        private readonly IAssets _assets;
        private readonly IWindowService _windowService;

        public MenuFactory(IAssets assets, IWindowService windowService)
        {
            _assets = assets;
            _windowService = windowService;
        }

        public GameObject CreateMenuHUD()
        {
            GameObject menuHud = _assets.Instantiate(AssetPath.MenuHudPath);

            foreach (OpenWindowCommand openWindowButton in menuHud.GetComponent<MenuUI>().OpenWindowCommands)
                openWindowButton.Construct(_windowService);

            return menuHud;
        }
    }
}
