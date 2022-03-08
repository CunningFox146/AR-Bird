using UnityEngine;

namespace ArBird.Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player Info")]
    public class PlayerInfo : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _price;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public GameObject PlayerPrefab => _playerPrefab;
        public float Price => _price;
        public string Name => _name;
        public string Description => _description;
    }
}