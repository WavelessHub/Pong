using UnityEngine;

public class GameOver_UI : MonoBehaviour
{
    void OnEnable()
    {
        AudioManager.instance.PlaySFX(3);

        GameManager.instance.SetHasGameStarted(false);
    }
}