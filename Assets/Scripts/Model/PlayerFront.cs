using System;
using UnityEngine;

namespace Model
{
    public class PlayerFront : MonoBehaviour
    {
        private PlayerBaby _playerBaby;

        public PlayerFront(PlayerBaby playerBaby)
        {
            _playerBaby = playerBaby;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "FirstBotFront":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> FirstBotFront");
                    return;
                case "SecondBotFront":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> SecondBotFront");
                    return;
                case "FirstBotBack":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> FirstBotBack");
                    return;
                case "SecondBotBack":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerFront -> SecondBotBack");
                    return;
            }
        }
    }
}