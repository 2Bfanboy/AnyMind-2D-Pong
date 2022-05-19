using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnyMind.Pong2D
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Stage model;
        
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject stageClearedPanel;

        #region Setup
        private void Start()
        {
            model.OnLifePointsChanged += LifePointsChangedHandler;
            model.OnStageSuccessfullyCleared += AllBricksRemovedHandler;
            
            gameOverPanel.SetActive(false);
            stageClearedPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            model.OnLifePointsChanged -= LifePointsChangedHandler;
            model.OnStageSuccessfullyCleared -= AllBricksRemovedHandler;
        }
        #endregion

        #region Event Handlers
        // This listens for lifePoints == 0 event trigger
        private void LifePointsChangedHandler(int amount)
        {
            if (amount < 1)
            {
                GameOver();
            }
        }

        private void AllBricksRemovedHandler()
        {
            StageCleared();
        }

        // Life points reached 0
        private void GameOver()
        {
            gameOverPanel.SetActive(true);
        }

        // All bricks successfully cleared
        private void StageCleared()
        {
            stageClearedPanel.SetActive(true);
        }
        #endregion
        
        
        #region Button calls
        public void LoadSceneViaButton(string sceneName)
        {
            try
            {
                SceneManager.LoadScene(sceneName);
            }
            catch (Exception e)
            {
                Debug.Log("<color=red>[Warning] Attempted load scene <b><color=white>" + 
                          sceneName + "</color></b> but it isn't included in the build index. " +
                          "Returning to menu instead...");
                SceneManager.LoadScene(0);
            }
        }
        #endregion
    }
}
