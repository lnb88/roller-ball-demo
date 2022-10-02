using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    public GameObject ballObject;
    public GameObject lockedDoor;

    private int starsCollected = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Texture2D tex = UIManager_Splash.ballTexture;
        if (tex != null)
        {
            Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            ballObject.GetComponent<SpriteRenderer>().sprite = mySprite;
        }

        StartGame();
    }

    public void StartGame()
    {
        starsCollected = 0;

        lockedDoor.SetActive(true);
    }

    public void SetStarsCollectedCount()
    {
        starsCollected += 1;

        if (starsCollected > 3)
        {
            starsCollected = 3;
        }
    }

    public int GetStarsCollectedCount()
    {
        if (starsCollected > 3)
        {
            starsCollected = 3;
        }

        return starsCollected;
    }

    public void OpenLockedDoor()
    {
        lockedDoor.SetActive(false);
    }
}
