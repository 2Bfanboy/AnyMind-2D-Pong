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
            var ball = collider.GetComponent<Ball>();
            // Just temporary for testing
            ball.Spawn();
        }
    }
}
