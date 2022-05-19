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

        private enum PlatformStates
        {
            MovingLeft,
            MovingRight,
            NotMoving
        }
        private PlatformStates state = PlatformStates.NotMoving;

        private void FixedUpdate()
        {
            if (rigidbodyReference == null)
            {
                return;
            }
            
            switch (state)
            {
                case PlatformStates.MovingLeft:
                    rigidbodyReference.velocity = Vector2.right * -1 * dragSpeed;
                    return;
                case PlatformStates.MovingRight:
                    rigidbodyReference.velocity = Vector2.right * 1 * dragSpeed;
                    return;
                case PlatformStates.NotMoving:
                    rigidbodyReference.velocity = Vector2.zero;
                    return;
            }
        }

        #region Controls (via UI buttons)
        // Note: Because this is just a demo, I'm using this simple movement controller.
        // If the user pressed both left and right, it'll move in the direction of the most recently pressed button
        // On release of either buttons, movement will stop. Ideally the user will only request movement in 1 direction
        // at a time.
        public void LeftPressed()
        {
            state = PlatformStates.MovingLeft;
        }

        public void RightPressed()
        {
            state = PlatformStates.MovingRight;
        }
        
        public void RightOrLeftReleased()
        {
            state = PlatformStates.NotMoving;
        }
        #endregion
    }
}
