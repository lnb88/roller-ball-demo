using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_Home : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void OnBtnClick_Play()
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
