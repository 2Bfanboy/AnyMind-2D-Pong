using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class Platform : MonoBehaviour
    {
        [SerializeField]
        private float dragSpeed = 5f;

        [SerializeField]
        private Rigidbody2D rigidbodyReference;

        private float input;

        private void Update()
        {
            input = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            if (rigidbodyReference != null)
            {
                // For quicker editor testing with keyboard -- release will use on-screen buttons
                rigidbodyReference.velocity = Vector2.right * input * dragSpeed;
            }
        }
    }
}
