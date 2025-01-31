using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseOverlay;
    private bool isPaused = false;

    void Start()
    {
        pauseOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseOverlay.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}