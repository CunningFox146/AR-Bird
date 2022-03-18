using ArBird.Pipes;
using ArBird.Player;
using ArBird.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Zenject;

namespace ArBird.World
{
    public class SpawnDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _model;
        [SerializeField] private string _data;

        private WorldSpawner _world;
        private ARRaycastManager _raycastManager;
        private Camera _camera;
        private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
        private Pose? _pose;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Init(ARRaycastManager raycastManager, WorldSpawner world)
        {
            _raycastManager = raycastManager;
            _world = world;
        }

        private void Update()
        {
            var screenCenter = _camera.ViewportPointToRay(Vector2.one * 0.5f);
            _hits.Clear();

            if (_raycastManager.Raycast(screenCenter, _hits) && _hits.Count > 0)
            {
                _pose = _hits[0].pose;
            }
            else
            {
                _pose = null;
            }

            if (_pose != null)
            {
                _data = _pose.Value.ToString();
                _model.SetActive(true);
                transform.position = _pose.Value.position;

                var camForward = _camera.transform.forward;
                transform.rotation = Quaternion.LookRotation(new Vector3(camForward.x, 0f, camForward.z).normalized);
            }
            else
            {
                _data = "ERR";
                _model.SetActive(false);
            }
        }
    }
}
