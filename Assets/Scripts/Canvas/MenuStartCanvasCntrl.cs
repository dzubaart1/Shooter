using Globals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Canvas
{
    public class MenuStartCanvasCntrl : MonoBehaviour
    {
        private MenuSettings _menuSettings
;
        private void Start()
        {
            _menuSettings = GameplayManager.Instance().GetMenuSettings();
        }

        public void OnClickTimeRule()
        {
            _menuSettings.RuleType = RuleType.TimerRule;
            SceneManager.LoadScene("LevelScene");
        }

        public void OnClickCountRule()
        {
            _menuSettings.RuleType = RuleType.CountRule;
            SceneManager.LoadScene("LevelScene");
        }
    }
}
