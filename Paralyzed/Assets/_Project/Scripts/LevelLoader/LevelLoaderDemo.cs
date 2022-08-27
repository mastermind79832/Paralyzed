using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paralysed
{
    public class LevelLoaderDemo : MonoBehaviour
    {
        public void NextLevel()
        {
            int currentlevel = SceneManager.GetActiveScene().buildIndex;

            if (currentlevel >= PlayerPrefs.GetInt("levelsUnlocked"))
            {
                PlayerPrefs.SetInt("levelsUnlocked",currentlevel + 1);
            }
        }
    }
}
