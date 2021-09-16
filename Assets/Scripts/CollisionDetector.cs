using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Game Over");
            gameManager.playerState = GameManager.PlayerState.Dead;
            gameManager.PlayDeadFX(transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Score")
        {
            if (gameManager.playerState == GameManager.PlayerState.Lives)
            {
                gameManager.IncreaseScore();
                gameManager.PlayScoreFX(collision.gameObject.transform.position,Quaternion.Euler(-90,0,0));
                Destroy(collision.gameObject);
            }
            else
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
}
