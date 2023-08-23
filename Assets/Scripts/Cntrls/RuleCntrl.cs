using Canvas;
using Globals;
using UnityEngine;

namespace Cntrls
{
    public class RuleCntrl : MonoBehaviour
    {
        private MenuSettings _menuSettings;

        private void Start()
        {
            _menuSettings = GameplayManager.Instance().GetMenuSettings();
            GameplayManager.Instance().OnStartGameSignal.AddListener(StartCanvas);
        }

        private void StartCanvas()
        {
            switch (_menuSettings.RuleType)
            {
                case RuleType.TimerRule:
                    GameplayManager.Instance().SendToggleCanvasSignal(CanvasId.TimerRule);
                    break;
                case RuleType.CountRule:
                    GameplayManager.Instance().SendToggleCanvasSignal(CanvasId.CountRule);
                    break;
            }
        }
    }
}
