using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MenuHandler : MonoBehaviour
    {
        public string tempName;
        public Text input;

        public MenuHandler()
        {

        }

        public void Start()
        {
            GameManager.started = true;
        }

        public void StartGame()
        {
            if (tempName == "") return;
            GameManager.Play(tempName);
        }

        public void SetTempName()
        {
            tempName = input.text;
        }


    }
}
