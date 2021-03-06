using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ArBird.Pipes
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _pipeBlockPrefab;
        [SerializeField] private Vector2 _bounds;
        [SerializeField] private float _spawnPeriod;
        [SerializeField] private float _moveSpeed = 2f;
        [Space]
        [SerializeField] private float _spacing = 1f;
        [SerializeField] private float _maxTop = 10f;
        [SerializeField] private float _minTop = 1f;
        [SerializeField] private float _centerRange = 1f;

        private IObjectPool<PipeBlock> _pool;
        private Queue<PipeBlock> _pipesQueue = new Queue<PipeBlock>();
        private PipeRangeCalculator _calculator;
        private float _time;

        public Vector2 Bounds => _bounds;

        private void Awake()
        {
            _calculator = new PipeRangeCalculator(_centerRange, _minTop, _maxTop);

            CreatePool();
        }

        private void Update()
        {
            MovePipes();
            UpdateCurrentPipes();
        }


        public void Restart()
        {
            foreach (var pipe in _pipesQueue)
            {
                _pool.Release(pipe);
            }
            _time = 0f;
        }

        private void CreatePool()
        {
            _pool = new ObjectPool<PipeBlock>(
                            () => { return Instantiate(_pipeBlockPrefab, transform).GetComponent<PipeBlock>(); },
                            pipe => { pipe.gameObject.SetActive(true); },
                            pipe => { pipe.gameObject.SetActive(false); },
                            null,
                            false,
                            10
                        );
        }

        private void MovePipes()
        {
            foreach (var pipe in _pipesQueue)
            {
                pipe.transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
            }
        }

        private void UpdateCurrentPipes()
        {
            _time += Time.deltaTime;
            if (_time >= _spawnPeriod)
            {
                SpawnNewPipe();
                UpdateLastPipe();
                _time = 0f;
            }
        }

        private void SpawnNewPipe()
        {
            var newPipe = _pool.Get();
            newPipe.SetCenter(_calculator.Get(), _minTop, _maxTop, _spacing);
            newPipe.transform.position = Vector3.right * _bounds.x;
            _pipesQueue.Enqueue(newPipe);
        }


        private void UpdateLastPipe()
        {
            var lastPipe = _pipesQueue.Peek();
            if (lastPipe.transform.position.x <= _bounds.y)
            {
                _pipesQueue.Dequeue();
                _pool.Release(lastPipe);
            }
        }
    }
}
