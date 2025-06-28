using UnityEngine;

public class Game_UI : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;

    public void SwitchUI(GameObject uiToEnable)
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }

        MenuClickSFX();

        uiToEnable.SetActive(true);
    }

    public void QuitGame()
    {
        MenuClickSFX();

        Application.Quit();
    }

    void MenuClickSFX() => AudioManager.instance.PlaySFX(0);
}
