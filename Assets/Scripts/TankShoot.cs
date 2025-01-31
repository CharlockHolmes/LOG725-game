using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public LayerMask obstacleLayer;

    private Color redColor = Color.red;
    private Color greenColor = Color.green;
    private Color blueColor = Color.blue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.J)) Shoot("Red", redColor);
        if (Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.K)) Shoot("Green", greenColor);
        if (Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.L)) Shoot("Blue", blueColor);
    }

    void Shoot(string ammoType, Color projectileColor)
    {
        if (!PlayerState.Instance.UseAmmo(ammoType)) return;

        if (projectilePrefab == null || firePoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projScript = projectile.GetComponent<Projectile>();

        if (projScript != null)
        {
            Vector3 shootDirection = transform.up;
            projScript.Initialize(shootDirection, projectileColor);
            projScript.obstacleLayer = obstacleLayer;
        }
    }
}