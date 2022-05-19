using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class MultiHitBrick : Brick
    {
        [Header("Length must match life points!")]
        [SerializeField]
        private List<Color32> lifePointColors;

        private SpriteRenderer brickSprite;
        private int colorCycleCounter = 0;

        private void Awake()
        {
            brickSprite = GetComponent<SpriteRenderer>();
            SyncColorWithLifePoints();
        }

        protected override void RespondToHit()
        {
            base.RespondToHit();
            SyncColorWithLifePoints();
        }

        private void SyncColorWithLifePoints()
        {
            if (brickSprite != null)
            {
                // Wrap-around just in case there aren't enough colors provided
                // in the editor by the designer (me in this case)
                var colorIndex = lifePoints-1;
                
                // Check for out-of-bounds in the event that inspector isn't properly set
                if (colorIndex < 0 || colorIndex >= lifePointColors.Count)
                {
                    colorIndex = 0;
                }
                brickSprite.color = lifePointColors[colorIndex];
            }
        }
    }
}
