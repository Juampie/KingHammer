using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneChangerNS;
using UnityEngine.UI;

namespace LevelControlNS
{
    public class LevelControl : MonoBehaviour
    {
        [SerializeField] private GameObject[] buttons;
        public static int maxLevel = 1 ;

        private void Start()
        {
            RefreshButton();
            
        }

        private void RefreshButton()
        {
            for (int i = 0; i < maxLevel; i++)
            {
                buttons[i].GetComponent<Image>().color = Color.white;
                buttons[i].GetComponent<Button>().enabled= true;
            }
        }



    }

}
