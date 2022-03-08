using ArBird.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArBird.Services
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<PlayerInfo> _items;
        public PlayerInfo Selected { get; private set; }
        public List<PlayerInfo> BoughtItems { get; private set; }

        private void Awake()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            string selectedJson = PlayerPrefs.GetString(nameof(Selected));
            string boughtJson = PlayerPrefs.GetString(nameof(BoughtItems));

            try
            {
                Selected = JsonUtility.FromJson<PlayerInfo>(selectedJson);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (Selected == null)
                {
                    Selected = _items[0];
                }
            }

            try
            {
                BoughtItems = JsonUtility.FromJson<List<PlayerInfo>>(boughtJson);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                if (BoughtItems == null)
                {
                    BoughtItems = new List<PlayerInfo>() { _items[0] };
                }
            }
        }

        private void SaveItems()
        {
            PlayerPrefs.SetString(nameof(Selected), JsonUtility.ToJson(Selected));
            PlayerPrefs.SetString(nameof(BoughtItems), JsonUtility.ToJson(BoughtItems));
        }
    }
}
