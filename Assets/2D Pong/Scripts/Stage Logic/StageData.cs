using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    public class StageData : ScriptableObject
    {
        [SerializeField] 
        private string stageName = "[Stage Name]";

        [SerializeField]
        private int lifePoints = 3;
    }
}
