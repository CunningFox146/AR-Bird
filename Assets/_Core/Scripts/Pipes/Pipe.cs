using UnityEngine;

namespace ArBird.Pipes
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private Transform _top;
        [SerializeField] private Transform _base;
        [SerializeField] private float _topSize = 0.15f;

        public void SetSize(float size)
        {
            _base.localScale = new Vector3(1f, size - _topSize, 1f);
            _top.localPosition = Vector3.up * (size - _topSize);
        }
    }
}