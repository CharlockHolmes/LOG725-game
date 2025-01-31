using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int redAmmo = 1;
    public int greenAmmo = 1;
    public int blueAmmo = 1;

    public static PlayerState Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddAmmo(string type, int amount)
    {
        if (type == "Red") redAmmo += amount;
        else if (type == "Green") greenAmmo += amount;
        else if (type == "Blue") blueAmmo += amount;

        AmmoUI.Instance.UpdateAmmoDisplay();
    }

    public bool UseAmmo(string type)
    {
        if (type == "Red" && redAmmo > 0) { redAmmo--; }
        else if (type == "Green" && greenAmmo > 0) { greenAmmo--; }
        else if (type == "Blue" && blueAmmo > 0) { blueAmmo--; }
        else return false;

        AmmoUI.Instance.UpdateAmmoDisplay();
        return true;
    }
}