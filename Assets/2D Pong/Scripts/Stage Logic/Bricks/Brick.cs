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

        [SerializeField]
        protected bool indestructible = false;

        public delegate void BrickDestroyed(Brick caller);
        public BrickDestroyed OnBrickDestroyed;

        /// <summary> If true, this brick can never leave the stage and is unaffected by life points. </summary>
        public bool Indestructible => indestructible;

        protected virtual void RespondToHit()
        {
            // Default functionality when taking a hit
            if (!indestructible)
            {
                CheckIsDefeated();   
            }
        }

        private void CheckIsDefeated()
        {
            if (lifePoints < 1)
            {
                OnBrickDestroyed(this);
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
