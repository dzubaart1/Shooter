using Globals;
using TMPro;
using UnityEngine;

namespace Cntrls
{
    public class TargetCntrl : MonoBehaviour
    {
        private const float ALPHAONHOVER = 0.5f;
        private const float ALPHAOUTHOVER = 1f;
        private Color _trueColor;
    
        public void Hit(Color weaponColor)
        {
            GameplayManager.Instance().SendShootSignal(weaponColor.Compare(_trueColor));
            GameplayManager.Instance().SendUpdateColorSignal();
        }

        public void OnHover()
        {
            var color = GetComponent<MeshRenderer>().material.color;
            color.a = ALPHAONHOVER;
            GetComponent<MeshRenderer>().material.color = color;
        }

        public void OutHover()
        {
            var color = GetComponent<MeshRenderer>().material.color;
            color.a = ALPHAOUTHOVER;
            GetComponent<MeshRenderer>().material.color = color;
        }

        public void ChangeColor(Color color)
        {
            GetComponent<MeshRenderer>().material.color = color;
            _trueColor = color;
        }
    }
}
