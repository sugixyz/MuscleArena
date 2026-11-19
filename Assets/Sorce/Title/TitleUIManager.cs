using UnityEngine;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private Button p1startButton;
    [SerializeField] private Button p2startButton;
    [SerializeField] private TitleSceneManager titleSceneManager;

    private void Awake()
    {
        p1startButton.onClick.AddListener(titleSceneManager.OnStaretButtonPressed);
        p2startButton.onClick.AddListener(titleSceneManager.OnStaretButtonPressed);
    }

    private void Update()
    {
    }
}
