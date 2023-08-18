using Canvas;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CountRuleCanvasCntrl : CanvasBase
{
    [SerializeField] private int _maxCount;
    [SerializeField] private float _timeForLose;
    [SerializeField] private Text _stopWatchText;
    [SerializeField] private Text _countText;

    private int _count;
    private float _timerCount;
    private SignalBus _signalBus;
    private bool _isEndGame;
    
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Start()
    {
        _stopWatchText.text = "Time: " + _timerCount.ToString("F2");
        _countText.text = "Score: " + _count.ToString();
        _signalBus.Subscribe<UserShootSignal>(UpdateState);
    }

    private void Update()
    {
        if(_isEndGame) return;
        _timerCount += Time.deltaTime;
        _stopWatchText.text = "Time: " + _timerCount.ToString("F2");
    }

    public void UpdateState(UserShootSignal userShootSignal)
    {
        if (userShootSignal.IsCorrectShoot)
        {
            _count++;
            if (_count >= _maxCount)
            {
                _signalBus.Fire(new EndGameSignal());
                var temp = new ToggleCanvasSignal();
                temp.CanvasId = CanvasId.EndGame;
                _signalBus.Fire(temp);
                _isEndGame = true;
            }
            _countText.text = "Score: " + _count.ToString();
        }
        else
        {
            _timerCount += _timeForLose;
        }
    }
}
