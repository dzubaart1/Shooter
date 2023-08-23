using System.Collections;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class CountdownCanvasCntrl : CanvasBase
    {
        [SerializeField] private int _secondsCount;
        [SerializeField] private Text _timerText;

        private void Start()
        {
            _timerText.text = _secondsCount.ToString();
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            for (var i = _secondsCount; i >= 0; i--)
            {
                yield return new WaitForSeconds(1);
                _timerText.text = i.ToString();
            }
            GameplayManager.Instance().SendStartGameSignal();
            gameObject.SetActive(false);
        }
    }
}
