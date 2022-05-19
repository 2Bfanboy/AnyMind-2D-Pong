using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AnyMind.Pong2D
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        protected float speed = 10f;

        [SerializeField]
        private Rigidbody2D rigidbodyReference;

        [SerializeField] 
        protected int hitPower;

        private void Awake()
        {
            Spawn();
        }

        public virtual void Hit(Brick targetBrick)
        {
            targetBrick.ReduceLifePoints(hitPower);
        }

        public virtual void Spawn()
        {
            var platformReference = FindObjectOfType<Platform>();
            if (platformReference != null)
            {
                var platformPosition = platformReference.transform.position;
                var newPosition = new Vector3(platformPosition.x, platformPosition.y + 1f, platformPosition.z);
                transform.position = newPosition;
            }

            if (rigidbodyReference != null)
            {
                rigidbodyReference.velocity = Random.insideUnitCircle.normalized * speed;
            }
        }
    }
}
