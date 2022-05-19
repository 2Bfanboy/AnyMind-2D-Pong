using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyMind.Pong2D
{
    [CreateAssetMenu(fileName = "StageData", menuName = "AnyMindDemo/Create Stage Data", order = 1)]
    public class StageData : ScriptableObject
    {
        [SerializeField] 
        private string stageName = "[Stage Name]";

        [SerializeField]
        private int lifePoints = 3;

        [SerializeField]
        private GameObject bricks;

        #region Accessors
        public string StageName => stageName;
        public int LifePoints => lifePoints;
        public GameObject Bricks => bricks;
        #endregion
    }
}
