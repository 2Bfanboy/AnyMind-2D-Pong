using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField]
        private Stage stageReference;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            stageReference.ReceiveDamage();
            stageReference.RequestBallSpawn();
        }
    }
}
