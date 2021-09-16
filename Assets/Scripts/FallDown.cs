using UnityEngine;

public class FallDown : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2f;

    Vector2 worldPoint;
    float worldPointY;

    private void Start()
    {
        worldPoint = Camera.main.ViewportToWorldPoint(Vector2.zero);

        worldPointY = worldPoint.y;

        worldPointY -= transform.localScale.y;
    }

    private void Update()
    {
        if (transform.position.y < worldPointY)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.fixedDeltaTime);
    }
}
