using ArBird.Pipes;
using ArBird.Player;
using ArBird.World;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Zenject;

namespace ArBird.Services
{
    public class WorldSpawner : MonoBehaviour
    {
        public event Action PlanesReady;

        [SerializeField] private Vector2 _gameFieldScale;
        [SerializeField] private GameObject _displayPrefab;

        private Transform _display;
        private ARPlaneManager _planeManager;
        private PipeSpawner _pipeSpawner;
        private PlayerSpawner _playerSpawner;
        private ARRaycastManager _raycastManager;

        public Vector2 GameFieldScale => _gameFieldScale;

        private async void Start()
        {
            //await TrackingPlanes();

            InstantiateDisplay();
        }

        [Inject]
        private void Constructor(ARPlaneManager planeManager, PipeSpawner pipeSpawner, PlayerSpawner playerSpawner, ARRaycastManager raycastManager)
        {
            _planeManager = planeManager;
            _pipeSpawner = pipeSpawner;
            _playerSpawner = playerSpawner;
            _raycastManager = raycastManager;
        }

        public void SpawnOnPose(Pose pose)
        {
            _pipeSpawner.transform.position = pose.position;
            _pipeSpawner.transform.rotation = pose.rotation;
        }

        private void InstantiateDisplay()
        {
            _display = Instantiate(_displayPrefab).transform;
            _display.localScale = new Vector3(
                _gameFieldScale.x * transform.localScale.x,
                transform.localScale.y,
                _gameFieldScale.y * transform.localScale.z);
            _display.GetComponent<SpawnDisplay>().Init(_raycastManager, this);
        }

        private async Task TrackingPlanes()
        {
            while (_planeManager.trackables.count <= 0) await Task.Yield();
            PlanesReady?.Invoke();
        }
    }
}