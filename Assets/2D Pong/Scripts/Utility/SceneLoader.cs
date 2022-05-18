using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnyMind.Pong2D
{
    // General utility for opening any scenes
    public class SceneLoader : MonoBehaviour
    {
        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
