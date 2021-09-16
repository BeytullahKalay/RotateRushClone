using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotatev Values")]
    [SerializeField] Vector2 rotateSpeed = new Vector2(4,6);
    private float currentRotateDir = 1;

    [Header("Circles Positions")]
    [SerializeField] Transform circle1;
    [SerializeField] Transform circle2;
    [SerializeField] float distanceBetweenCircles = 5f;

    [Space(10)]
    [SerializeField] GameManager gameManager;



    private void Start()
    {
        SetPositionOfCircles(); 
    }

    private void Update()
    {
        if (gameManager.playerState == GameManager.PlayerState.Lives)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetRotateDir();
            }
        }

    }

    private void FixedUpdate()
    {
        RotateCircles();
    }

    private void SetRotateDir()
    {
        currentRotateDir *= -1;
    }

    private void RotateCircles()
    {
        transform.Rotate(Vector3.forward * currentRotateDir * Mathf.Lerp(rotateSpeed.x,rotateSpeed.y,Difficulty.GetDifficultyPercent()));

    }


    private void SetPositionOfCircles()
    {
        float Xpos = transform.position.y;
        float circle1Pos = Xpos + distanceBetweenCircles;
        float circle2Pos = Xpos - distanceBetweenCircles;

        circle1.transform.position = new Vector2(circle1Pos, transform.position.y);
        circle2.transform.position = new Vector2(circle2Pos, transform.position.y);

    }
}
