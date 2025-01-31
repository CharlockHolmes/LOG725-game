using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text redAmmoText;
    public Text greenAmmoText;
    public Text blueAmmoText;

    public static AmmoUI Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateAmmoDisplay();
    }

    public void UpdateAmmoDisplay()
    {
        if (PlayerState.Instance == null) return;

        redAmmoText.text = "Red: " + PlayerState.Instance.redAmmo;
        greenAmmoText.text = "Green: " + PlayerState.Instance.greenAmmo;
        blueAmmoText.text = "Blue: " + PlayerState.Instance.blueAmmo;
    }
}