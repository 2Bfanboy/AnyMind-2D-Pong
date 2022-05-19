using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnyMind.Pong2D
{
    // General utility for opening any scenes
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private GameObject stageSelectPanel;

        public void OpenStageSelect()
        {
            stageSelectPanel.SetActive(true);
        }
        
        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void SelectStage(StageData stage)
        {
            Stage.SetStageData(stage);
            OpenScene("Stage");
        }
    }
}
