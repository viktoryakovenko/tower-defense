using System;

namespace Code.Audio.Services
{
    public interface IToggleable
    {
        event Action<bool> ToggleChanged;

        bool IsEnabled { get; }

        void Toggle();
    }
}
