using System.Collections.Generic;
using Cntrls;
using Globals;
using UnityEngine;

namespace Colors
{
    public class ColorChangerCntrl : MonoBehaviour
    {
        [SerializeField] private List<TargetCntrl> _targetCntrls;
        [SerializeField] private List<GunCntrl> _gunsCntrls;
        private ColorCntrl _colorCntrl;
    
        private void Start()
        {
            _colorCntrl = new ColorCntrl();
            GameplayManager.Instance().OnUpdateColorSignal.AddListener(UpdateColors);
            GameplayManager.Instance().OnStartGameSignal.AddListener(SetColorsByStart);
            GameplayManager.Instance().OnEndGameSignal.AddListener(SetColorsByDefault);
        }

        private void UpdateColors()
        {
            _colorCntrl.ShuffleColors();
            foreach (var target in _targetCntrls)
            {
                target.ChangeColor(_colorCntrl.GetNextColor());
            }

            foreach (var gun in _gunsCntrls)
            {
                gun.ChangeColor(_colorCntrl.GetRandomColor());
            }
        }

        private void SetColorsByDefault()
        {
            foreach (var gun in _gunsCntrls)
            {
                gun.gameObject.SetActive(false);
            }
        }

        private void SetColorsByStart()
        {
            _colorCntrl.ShuffleColors();
            foreach (var target in _targetCntrls)
            {
                target.ChangeColor(_colorCntrl.GetNextColor());
            }

            foreach (var gun in _gunsCntrls)
            {
                gun.ChangeColor(_colorCntrl.GetRandomColor());
                gun.gameObject.SetActive(true);
            }
        }
    }
}
