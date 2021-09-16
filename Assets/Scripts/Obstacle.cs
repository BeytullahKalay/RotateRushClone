using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Transform startPos;
    private Transform secondPos;
    private Transform targetPos;

    private void Start()
    {
        startPos = transform.parent.GetChild(1);
        secondPos = transform.parent.GetChild(2);
    }

    private void Update()
    {
        if (transform.position == startPos.position)
        {
            targetPos = secondPos;
        }
        else if (transform.position == secondPos.position)
        {
            targetPos = startPos;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);
    }
}
