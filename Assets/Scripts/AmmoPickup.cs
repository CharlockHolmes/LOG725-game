using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public string ammoType; // Red, Green, or Blue
    public int ammoAmount = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Ammo picked up: " + ammoType);

            if (PlayerState.Instance != null)
            {
                PlayerState.Instance.AddAmmo(ammoType, ammoAmount);
            }

            Destroy(gameObject);
        }
    }
}

