using Canvas;
using UnityEngine.Events;

namespace Globals
{
    public class GameplayManager
    {
        private MenuSettings _menuSettings;
        
        public UnityEvent<bool> OnShootSignal = new();
        public UnityEvent OnUpdateColorSignal = new();
        public UnityEvent OnStartGameSignal = new();
        public UnityEvent OnEndGameSignal = new();
        public UnityEvent<CanvasId> OnToggleCanvasSignal = new();
        
        private static GameplayManager _singleton;
        public static GameplayManager Instance()
        {
            return _singleton ??= new GameplayManager();
        }

        private GameplayManager()
        {
            _menuSettings = new MenuSettings();
        }
        
        public void SendShootSignal(bool isCorrectShoot)
        {
            OnShootSignal.Invoke(isCorrectShoot);
        }
        public void SendUpdateColorSignal()
        {
            OnUpdateColorSignal.Invoke();
        }
        public void SendStartGameSignal()
        {
            OnStartGameSignal.Invoke();
        }
        public void SendEndGameSignal()
        {
            OnEndGameSignal.Invoke();
        }
        public void SendToggleCanvasSignal(CanvasId canvasId)
        {
            OnToggleCanvasSignal.Invoke(canvasId);
        }

        public MenuSettings GetMenuSettings()
        {
            return _menuSettings;
        }
    }
}