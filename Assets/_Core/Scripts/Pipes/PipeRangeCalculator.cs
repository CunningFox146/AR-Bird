using UnityEngine;

namespace ArBird.Pipes
{
    public class PipeRangeCalculator
    {
        private float _lastPos;
        private float _range;
        private float _minTop;
        private float _maxTop;

        public PipeRangeCalculator(float range, float minTop, float maxTop)
        {
            _minTop = minTop;
            _maxTop = maxTop;

            _range = range;
            _lastPos = Random.Range(minTop, maxTop);
        }

        public float Get()
        {
            float newPos = _lastPos;

            if (_lastPos + _range >= _maxTop)
            {
                newPos += Random.Range(-_range, 0f);
            }
            else if (_lastPos - _range <= _minTop)
            {
                newPos += Random.Range(0f, _range);
            }
            else
            {
                newPos += Random.Range(-_range, _range);
            }

            _lastPos = newPos;
            return newPos;
        }
    }
}