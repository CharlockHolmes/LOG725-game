using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTile : MonoBehaviour
{
    public GameTimer gameTimer;
    public GameObject winUI;

    void Start()
    {
        winUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player reached the win tile!");
        WinGame();
    }

    void WinGame()
    {
        winUI.SetActive(true);
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
            AudioManager.Instance.Win();
        }
    }
}