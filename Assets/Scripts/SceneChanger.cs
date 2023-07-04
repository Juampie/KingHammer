using UnityEngine;
using UnityEngine.SceneManagement;
using LevelControlNS;

namespace SceneChangerNS
{
    public class SceneChanger : MonoBehaviour
    {
        public static int SceneNow = 1;

        public void NextScane()
        {
            SceneNow = SceneManager.GetActiveScene().buildIndex;
            SceneNow++;
            if (LevelControl.maxLevel < SceneNow )
            {
                LevelControl.maxLevel = SceneNow ;
                
            }
            SceneManager.LoadScene(SceneNow);

        }
        public void ChangeScane(int index) 
        {
            SceneManager.LoadScene(index);
        }
    }
}

