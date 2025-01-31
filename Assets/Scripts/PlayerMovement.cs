using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveDuration = 0.5f;
    public float rotateDuration = 0.5f;
    public LayerMask obstacleLayer;

    private bool isMoving = false;
    private Vector3 currentDirection = Vector3.right;
    private Vector3? bufferedInput = null;

    void Update()
    {
        if (isMoving)
        {
            Vector3? nextDirection = GetInputDirection();
            if (nextDirection != null)
                bufferedInput = nextDirection;
            return;
        }

        Vector3? inputDirection = bufferedInput ?? GetInputDirection();

        if (inputDirection == null) return;
        bufferedInput = null;

        Vector3 newDirection = inputDirection.Value;

        if (newDirection == currentDirection)
        {
            Vector3 targetPosition = transform.position + newDirection * moveDistance;
            if (!IsBlocked(targetPosition))
            {
                StartCoroutine(SmoothMove(targetPosition));
            }
        }
        else
        {
            StartCoroutine(SmoothRotate(newDirection));
        }
    }

    Vector3? GetInputDirection()
    {
        if (Input.GetKeyDown(KeyCode.W)) return Vector3.up;
        if (Input.GetKeyDown(KeyCode.S)) return Vector3.down;
        if (Input.GetKeyDown(KeyCode.A)) return Vector3.left;
        if (Input.GetKeyDown(KeyCode.D)) return Vector3.right;
        return null;
    }

    bool IsBlocked(Vector3 targetPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, moveDistance, obstacleLayer);
        return hit.collider != null;
    }

    IEnumerator SmoothMove(Vector3 target)
    {
        isMoving = true;
        Vector3 start = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(start, target, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        isMoving = false;
    }

    IEnumerator SmoothRotate(Vector3 newDirection)
    {
        isMoving = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(Vector3.forward, newDirection);

        float elapsedTime = 0f;
        while (elapsedTime < rotateDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotateDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        currentDirection = newDirection;
        isMoving = false;
    }
}
