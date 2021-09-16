using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject scoreBoxPrefab;
    public GameObject obstaclePrefab;
    public ParticleSystem playerDeadFX;
    public ParticleSystem scoreFX;

    public PlayerState playerState;
    public enum PlayerState
    {
        Lives,
        Dead
    }

    public Text scoreText;

    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }


    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }


    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public void PlayDeadFX(Vector3 position, Quaternion rotation)
    {
        playerDeadFX.transform.position = position;
        playerDeadFX.transform.rotation = rotation;
        playerDeadFX.Play();
    }

    public void PlayScoreFX(Vector3 position,Quaternion rotation)
    {
        scoreFX.transform.position = position;
        scoreFX.transform.rotation = rotation;
        scoreFX.Play();
    }
}
