using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class CountRuleCanvasCntrl : CanvasBase
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private float _timeForLose;
        [SerializeField] private Text _stopWatchText;
        [SerializeField] private Text _countText;

        private int _count;
        private float _timerCount;
        private bool _isEndGame;
    
        private void Start()
        {
            _stopWatchText.text = "Time: " + _timerCount.ToString("F2");
            _countText.text = "Score: " + _count;
            GameplayManager.Instance().OnShootSignal.AddListener(UpdateState);
        }

        private void Update()
        {
            if (_isEndGame)
            {
                return;
            }
            _timerCount += Time.deltaTime;
            _stopWatchText.text = "Time: " + _timerCount.ToString("F2");
        }

        private void UpdateState(bool isCorrectShoot)
        {
            if (!isCorrectShoot)
            {
                _timerCount += _timeForLose;
                return;
            }
            
            _count++;
            if (_count > _maxCount)
            {
                _isEndGame = true;
                GameplayManager.Instance().SendEndGameSignal();
                GameplayManager.Instance().SendToggleCanvasSignal(CanvasId.EndGame);
            }
            _countText.text = "Score: " + _count;
        }
    }
}
