using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnyMind.Pong2D
{
    public sealed class OpenGithub : MonoBehaviour
    {
        
        private const string githubUrl = "https://github.com/2Bfanboy/AnyMind-2D-Pong";

        public void Redirect()
        {
            Application.OpenURL(githubUrl);
        }
    }
}
