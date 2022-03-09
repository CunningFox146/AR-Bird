using UnityEngine;

namespace ArBird.World
{
    public class PipeBlock : MonoBehaviour
    {
        [SerializeField] private Pipe _top;
        [SerializeField] private Pipe _bottom;
        [SerializeField] private float _spacing = 1f;
        [SerializeField] private float _maxTop = 10f;
        [SerializeField] private float _minTop = 1f;

        private void Start()
        {
            _top.transform.localPosition = Vector3.up * _maxTop;
        }

        public void SetCenter(float center)
        {
            center = Mathf.Clamp(center, _minTop, _maxTop - _spacing);

            _top.SetSize(_maxTop - center - _spacing);
            _bottom.SetSize(center - _spacing);
        }

        private void Update()
        {
            SetCenter(Remap(Mathf.Sin(Time.time), -1f, 1f, _minTop, _maxTop - _spacing));
        }

        public static float Remap(float val, float in1, float in2, float out1, float out2)
        {
            return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
        }
    }
}
