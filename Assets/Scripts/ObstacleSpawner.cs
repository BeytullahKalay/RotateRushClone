using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private Vector2 minMaxTimeBetweenObstacleSpawns = new Vector2(1, 3);
    [SerializeField] private Vector2 spawnPositionLeftRight = new Vector2(-2, 1);

    private float nextSpawnTime = Mathf.Infinity;

    private void Start()
    {
        CalculateNextSpawnTime();
    }

    private void SpawnObstacle()
    {
        Vector2 screenPos = new Vector2(0, 1);
        Vector2 finalPos = Camera.main.ViewportToWorldPoint(screenPos);

        float _scaleY = gameManager.scoreBoxPrefab.transform.localScale.y;
        finalPos = new Vector2(finalPos.x, finalPos.y + _scaleY / 2);


        float _randomValue = Random.Range(1, 3);

        if (_randomValue == 1)
        {
            float _positionX = spawnPositionLeftRight.x;
            finalPos = new Vector2(_positionX, finalPos.y);
        }
        else
        {
            float _positionX = spawnPositionLeftRight.y;
            finalPos = new Vector2(_positionX, finalPos.y);
        }




        Instantiate(gameManager.obstaclePrefab, finalPos, Quaternion.identity);
        CalculateNextSpawnTime();
    }

    private void CalculateNextSpawnTime()
    {
        nextSpawnTime = Mathf.Lerp(minMaxTimeBetweenObstacleSpawns.y, minMaxTimeBetweenObstacleSpawns.x, Difficulty.GetDifficultyPercent());
        Invoke("SpawnObstacle", nextSpawnTime);
    }
}
