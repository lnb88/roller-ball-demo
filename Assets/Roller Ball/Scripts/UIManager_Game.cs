using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Game : MonoBehaviour
{
    public GameObject levelClearScreen;
    public GameObject levelFailScreen;
    public GameObject star_1, star_2, star_3;

    public Sprite star;
    public Sprite starOutline;

    private void Start()
    {
        levelClearScreen.SetActive(false);
        levelFailScreen.SetActive(false);
    }

    private void OnEnable()
    {
        BallManager.OnLevelClearEvent += ShowLevelClearScreen;
        BallManager.OnLevelFailEvent += ShowLevelFailScreen;
    }

    private void OnDisable()
    {
        BallManager.OnLevelClearEvent -= ShowLevelClearScreen;
        BallManager.OnLevelFailEvent -= ShowLevelFailScreen;
    }

    private void ShowLevelClearScreen()
    {
        levelClearScreen.SetActive(true);

        int starsCollected = GamePlayManager.instance.GetStarsCollectedCount();

        switch (starsCollected)
        {
            case 0:
                star_1.GetComponent<Image>().sprite = starOutline;
                star_2.GetComponent<Image>().sprite = starOutline;
                star_3.GetComponent<Image>().sprite = starOutline;
                break;

            case 1:
                star_1.GetComponent<Image>().sprite = star;
                star_2.GetComponent<Image>().sprite = starOutline;
                star_3.GetComponent<Image>().sprite = starOutline;
                break;

            case 2:
                star_1.GetComponent<Image>().sprite = star;
                star_2.GetComponent<Image>().sprite = star;
                star_3.GetComponent<Image>().sprite = starOutline;
                break;

            case 3:
                star_1.GetComponent<Image>().sprite = star;
                star_2.GetComponent<Image>().sprite = star;
                star_3.GetComponent<Image>().sprite = star;
                break;

            default:
                star_1.GetComponent<Image>().sprite = starOutline;
                star_2.GetComponent<Image>().sprite = starOutline;
                star_3.GetComponent<Image>().sprite = starOutline;
                break;
        }
    }

    private void ShowLevelFailScreen()
    {
        levelFailScreen.SetActive(true);
    }

    public void OnBtnClick_Home()
    {
        AudioManager.instance!.PlaySound(SoundName.click);

        ScenesManager.LoadScene(ScenesManager.Home);
    }

    public void OnBtnClick_Replay()
    {
        AudioManager.instance!.PlaySound(SoundName.click);

        ScenesManager.LoadScene(ScenesManager.GameScene);
    }

    public void OnBtnClick_Quit()
    {
        AudioManager.instance!.PlaySound(SoundName.click);

        ScenesManager.QuitGame();
    }
}
