using ArBird.Services;
using UnityEngine;
using Zenject;

namespace ArBird.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnPoint;
        private Shop _shop;

        public GameObject Player { get; private set; }

        [Inject]
        private void Constructor(Shop shop)
        {
            _shop = shop;
        }

        public void SpawnSelectedPlayer()
        {
            Player = Instantiate(_shop.Selected.PlayerPrefab, _spawnPoint, Quaternion.identity);
        }
    }
}
