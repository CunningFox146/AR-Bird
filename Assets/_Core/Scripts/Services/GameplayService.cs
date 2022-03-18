using ArBird.Pipes;
using UnityEngine;
using Zenject;

namespace ArBird.Services
{
    public class GameplayService : MonoBehaviour
    {
        private PipeSpawner _spawner;

        [Inject]
        private void Constructor(PipeSpawner spawner)
        {
            _spawner = spawner;
        }

        public void StartGame(Pose pose)
        {
            _spawner.transform.position = pose.position;
            _spawner.transform.rotation = pose.rotation;
            _spawner.gameObject.SetActive(true);
        }

        public void StopGame()
        {
            _spawner.gameObject.SetActive(false);
        }
    }
}
