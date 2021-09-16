using UnityEngine;

public class SideWalls : MonoBehaviour
{
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] private float scaleX = 2f;


    private void Start()
    {
        SetLeftWallPosition();
        SetRightWallPosition();
        SetScaleOfSideWalls();
    }

    private void SetLeftWallPosition()
    {
        float _mid = .5f;

        Vector2 screenPos = new Vector2(0, _mid);
        Vector2 leftPos = Camera.main.ViewportToWorldPoint(screenPos);

        float leftWallScaleX = leftWall.transform.localScale.x;

        Vector2 finalPos = leftPos;
        finalPos.x += leftWallScaleX / 2;

        leftWall.transform.position = finalPos;
    }

    private void SetRightWallPosition()
    {
        float _mid = .5f;

        Vector2 screenPos = new Vector2(1, _mid);
        Vector2 rightPos = Camera.main.ViewportToWorldPoint(screenPos);

        float rightWallScaleX = rightWall.transform.localScale.x;

        Vector2 finalPos = rightPos;
        finalPos.x -= rightWallScaleX / 2;

        rightWall.transform.position = finalPos;
    }

    private void SetScaleOfSideWalls()
    {
        Vector2 topOfViewPos = new Vector2(0, 1);
        Vector2 bottomOfViewPos = new Vector2(0, 0);

        Vector2 topMinusBottom = Camera.main.ViewportToWorldPoint(topOfViewPos) - Camera.main.ViewportToWorldPoint(bottomOfViewPos);
        leftWall.transform.localScale = Vector2.one * new Vector2(scaleX, topMinusBottom.y);
        rightWall.transform.localScale = Vector2.one * new Vector2(scaleX, topMinusBottom.y);    
    }

}
