using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableWall : MonoBehaviour
{
    public Color breakableColor = Color.red;
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wall triggered by: " + collision.gameObject.name);
        Projectile projectile = collision.GetComponent<Projectile>();
        if (projectile != null && projectile.GetProjectileColor() == breakableColor)
        {
            Debug.Log("Condition met - Removing all tiles within 0.1 unit range");
            Vector3 impactPoint = collision.transform.position;
            RemoveTilesInRadius(impactPoint, 0.2f);
        }
    }


    void RemoveTilesInRadius(Vector3 center, float radius)
    {
        Vector3Int centerTile = tilemap.WorldToCell(center);
        for (float x = -radius; x <= radius; x += 0.1f)
        {
            for (float y = -radius; y <= radius; y += 0.1f)
            {
                Vector3Int tilePos = tilemap.WorldToCell(center + new Vector3(x, y, 0));

                if (tilemap.HasTile(tilePos))
                {
                    tilemap.SetTile(tilePos, null);
                    Debug.Log("Removed tile at: " + tilePos);
                }
            }
        }
    }
}