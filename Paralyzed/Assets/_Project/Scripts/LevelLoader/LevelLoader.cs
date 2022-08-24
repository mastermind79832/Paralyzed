using System.Collections;
using Enums;
using Managers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    public string levelToLoad;
    public GameObject[] spirits; // collectibles that decide your unlocking 
    public GameObject triggerthingy; //or the trigger of the end level
    public GameObject levelLockedWarning;

    private void Start()
    {
        int spiritsYouSaved = PlayerPrefs.GetInt(levelToLoad + "spiritsYouSaved");
       
        for (int i = 0; i < spiritsYouSaved; i++)
        {
            spirits[i].SetActive(true);
        }

        //trigger {};
    }

    public void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelToLoad);
        switch (levelStatus)
        {

            case LevelStatus.Locked:
                SoundManager.Instance.Play(SoundTypes.ButtonClick);
                levelLockedWarning.SetActive(true);

                StartCoroutine(DeactivateLevelLockedScreen());
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(SoundTypes.ButtonClick);
                SceneManager.LoadScene(levelToLoad);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(SoundTypes.ButtonClick);
                SceneManager.LoadScene(levelToLoad);
                break;
        }


    }

    private IEnumerator DeactivateLevelLockedScreen()
    {
        yield return new WaitForSeconds(2);
        levelLockedWarning.SetActive(false);
    }
}