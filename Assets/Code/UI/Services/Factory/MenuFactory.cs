using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.States;
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
        private readonly IGameStateMachine _gameStateMachine;

        public MenuFactory(IAssets assets, IWindowService windowService, IGameStateMachine gameStateMachine)
        {
            _assets = assets;
            _windowService = windowService;
            _gameStateMachine = gameStateMachine;
        }

        public GameObject CreateMenuHUD()
        {
            GameObject menuHud = _assets.Instantiate(AssetPath.MenuHudPath);

            var menuUI = menuHud.GetComponent<MenuUI>();

            menuUI.PlayButtonHandler.Construct(new StartGameCommand(_gameStateMachine));
            menuUI.SettingsButtonHandler.Construct(new OpenWindowCommand(_windowService, WindowId.Settings));

            return menuHud;
        }
    }
}
