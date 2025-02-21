﻿using UnityEngine;

namespace Model
{
    public class PlayerBack : MonoBehaviour
    {
        private PlayerBaby _playerBaby;

        public PlayerBack(PlayerBaby playerBaby)
        {
            _playerBaby = playerBaby;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "FirstBotFront":
                    StartCoroutine(PlayerBaby.TimeCry());
                    Debug.Log($"PlayerBack -> FirstBotFront");
                    return;
                case "SecondBotFront":
                    StartCoroutine(PlayerBaby.TimeCry());
                    Debug.Log($"PlayerBack -> SecondBotFront");
                    return;
                case "FirstBotBack":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerBack -> FirstBotBack");
                    return;
                case "SecondBotBack":
                    StartCoroutine(PlayerBaby.TimeIdle());
                    Debug.Log($"PlayerBack -> SecondBotBack");
                    return;
            }
            
        }
    }
}