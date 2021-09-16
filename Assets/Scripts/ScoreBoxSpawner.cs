using UnityEngine;

public class ScoreBoxSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private Vector2 minMaxTimeBetweenScoreBoxSpawns = new Vector2(2, 5);

    private float nextSpawnTime = Mathf.Infinity;

    private void Start()
    {
        CalculateNextSpawnTime();
    }

    private void SpanwScoreBox()
    {
        float _mid = .5f;
        Vector2 screenPos = new Vector2(_mid, 1);
        Vector2 finalPos = Camera.main.ViewportToWorldPoint(screenPos);

        float scaleY = gameManager.scoreBoxPrefab.transform.localScale.y;
        finalPos = new Vector2(finalPos.x, finalPos.y + scaleY / 2);

        Instantiate(gameManager.scoreBoxPrefab, finalPos, Quaternion.identity);
        CalculateNextSpawnTime();
    }

    private void CalculateNextSpawnTime()
    {
        nextSpawnTime = Mathf.Lerp(minMaxTimeBetweenScoreBoxSpawns.y, minMaxTimeBetweenScoreBoxSpawns.x, Difficulty.GetDifficultyPercent());
        Invoke("SpanwScoreBox", nextSpawnTime);
    }
}
