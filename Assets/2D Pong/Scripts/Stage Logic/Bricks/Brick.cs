using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class Brick : MonoBehaviour
    {
        [SerializeField]
        protected int lifePoints;

        protected virtual void RespondToHit()
        {
            // Default functionality when taking a hit
            CheckIsDefeated();
        }

        private void CheckIsDefeated()
        {
            if (lifePoints < 1)
            { 
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var ball = col.gameObject.GetComponent<Ball>();

            if (ball != null)
            {
                ball.Hit(this);
            }
            RespondToHit();
        }
        
        #region External Callers
        public void ReduceLifePoints(int amount)
        {
            lifePoints -= amount;
        }
        #endregion
    }
}
