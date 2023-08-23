using System.Globalization;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class TimeRuleCanvasCntrl : CanvasBase
    {
        [SerializeField] private int _secondsCount;
        [SerializeField] private Text _timerText;
        [SerializeField] private Text _countText;

        private int _count;
        private float _timerCount;
        private bool _isEndGame;

        private void Start()
        {
            _timerCount = _secondsCount;
            _timerText.text = "Time: " + _timerCount.ToString(CultureInfo.InvariantCulture);
            _countText.text = "Score: " + _count;
            GameplayManager.Instance().OnShootSignal.AddListener(UpdateState);
        }
        
        private void Update()
        {
            if (_isEndGame)
            {
                return;
            }
            
            _timerCount -= Time.deltaTime;
            if (_timerCount <= 0)
            {
                GameplayManager.Instance().SendEndGameSignal();
                GameplayManager.Instance().SendToggleCanvasSignal(CanvasId.EndGame);
                _timerCount = 0;
                _isEndGame = true;
            }

            _timerText.text = "Time: " + Mathf.Round(_timerCount).ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateState(bool isCorrectShoot)
        {
            if (!isCorrectShoot)
            {
                return;
            }
            _count++;
            _countText.text = "Score: " + _count;
        }
    }
}
