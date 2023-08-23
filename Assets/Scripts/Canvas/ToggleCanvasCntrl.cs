using System.Collections.Generic;
using Globals;
using UnityEngine;

namespace Canvas
{
    public class ToggleCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private List<CanvasBase> _canvasList;

        private void Start()
        {
            GameplayManager.Instance().OnToggleCanvasSignal.AddListener(ToggleCanvas);
        }

        private void ToggleCanvas(CanvasId canvasId)
        {
            var index = 0;
            for (; index < _canvasList.Count; index++)
            {
                var canvas = _canvasList[index];
                if (canvas.Id.Equals(canvasId))
                {
                    canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
                }
            }
        }
    }
}