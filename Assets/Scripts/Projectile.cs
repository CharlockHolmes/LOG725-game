using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public float scaleDuration = 0.2f;
    public float fadeDuration = 1.5f;
    public LayerMask obstacleLayer;
    public Color projectileColor = Color.white;

    private Vector3 moveDirection;
    private SpriteRenderer spriteRenderer;
    private bool hasCollided = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifetime);
    }

    public void Initialize(Vector3 direction, Color color)
    {
        AudioManager.Instance.Shoot();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveDirection = direction.normalized;
        if (spriteRenderer != null)
        {
            projectileColor = color;
            spriteRenderer.color = color;
        }
    }

    void Update()
    {
        if (!hasCollided)
        {
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided) return;
        if (((1 << collision.gameObject.layer) & obstacleLayer) != 0)
        {
            hasCollided = true;
            StartCoroutine(HandleImpact());
        }
    }

    IEnumerator HandleImpact()
    {
        speed = 0f;

        AudioManager.Instance.Explode();
        yield return StartCoroutine(ScaleOverTime(transform.localScale * 2, scaleDuration));
        yield return StartCoroutine(ScaleOverTime(transform.localScale * 2, scaleDuration));
        yield return StartCoroutine(FadeOut(fadeDuration));

        Destroy(gameObject);
    }

    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
    
    public Color GetProjectileColor()
    {
        return projectileColor;
    }
}
