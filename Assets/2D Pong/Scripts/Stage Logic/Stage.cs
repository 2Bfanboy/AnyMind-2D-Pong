using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class Stage : MonoBehaviour
    {
        [Header("Data to use while testing in editor")]
        [SerializeField] private StageData editorTesterStage;
        public static StageData CurrentStage;

        public delegate void LifePointsChanged(int lifePoints);
        public LifePointsChanged OnLifePointsChanged;

        public delegate void StageSuccessfullyCleared();
        public StageSuccessfullyCleared OnStageSuccessfullyCleared;

        // State
        private int currentLifePoints;
        private int remainingBricks;

        private void Start()
        {
            if (CurrentStage != null)
            {
                SetStageData(CurrentStage);
            }
            else
            {
                // Initialization was invoked via Editor play button
                LoadStageFromData(editorTesterStage);
            }
        }

        private void LoadStageFromData(StageData data)
        {
            if (data == null)
            {
                return;
            }
            SetLifePoints(data.LifePoints);
            var bricks = Instantiate(data.Bricks);
            remainingBricks = DetermineInitialBrickCount(bricks);
        }

        private int DetermineInitialBrickCount(GameObject bricks)
        {
            var result = 0;
            var potentialBricks = bricks.GetComponentsInChildren<Brick>();
            foreach (var brick in potentialBricks)
            {
                if (!brick.Indestructible)
                {
                    brick.OnBrickDestroyed += BrickDestroyedHandler;
                    result++;
                }
            }
            return result;
        }

        private void SetLifePoints(int amount)
        {
            currentLifePoints = amount;
            OnLifePointsChanged(amount);
        }

        private void BrickDestroyedHandler(Brick caller)
        {
            remainingBricks--;
            caller.OnBrickDestroyed -= BrickDestroyedHandler;
            
            // Check if all bricks have been destroyed
            if (remainingBricks < 1)
            {
                OnStageSuccessfullyCleared();
            }
        }

        public void ReceiveDamage()
        {
            SetLifePoints(currentLifePoints-1);
        }

        /// <summary> Assigns the data that loading methods will use </summary>
        public static void SetStageData(StageData data)
        {
            CurrentStage = data;
        }
        
    }
}
