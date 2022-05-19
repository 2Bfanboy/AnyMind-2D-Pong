using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnyMind.Pong2D
{
    public class StageView : MonoBehaviour
    {
        [SerializeField]
        private Stage model;
        
        [SerializeField]
        private Text lifePointsText;

        private void Awake()
        {
            if (model != null)
            {
                model.OnLifePointsChanged += OnLifePointsChangedHandler;
            }
        }

        private void OnLifePointsChangedHandler(int value)
        {
            lifePointsText.text = "Life Points: <b>" + value + "</b>";
        }
        
        private void OnDestroy()
        {
            model.OnLifePointsChanged -= OnLifePointsChangedHandler;
        }
    }
}
