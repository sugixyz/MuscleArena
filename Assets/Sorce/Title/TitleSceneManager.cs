using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "PlayScene";
    [SerializeField] private bool allowAnyKetyStart = true;

    //画面遷移中かどうかのフラグ
    private bool isTransitioning = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (isTransitioning) return;
        if (!allowAnyKetyStart) return;

        //キーボードの任意のキーが押されたら次のシーンに遷移
        if (Keyboard.current != null)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                OnStaretButtonPressed();
                return;
            }
        }

        //ゲームパッドの任意のボタンが押されたら次のシーンに遷移
        if(Gamepad.current != null)
        {
            if(Gamepad.current.buttonSouth.wasPressedThisFrame ||
                Gamepad.current.startButton.wasPressedThisFrame)
            {
                OnStaretButtonPressed();
                return;
            }
        }
    }

    public void OnStaretButtonPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;
        TransitionToNextScene();
    }

    public void TransitionToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
