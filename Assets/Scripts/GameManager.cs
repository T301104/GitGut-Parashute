using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [SerializeField] private float minSpawnTime = 1;
    [SerializeField] private float maxSpawnTime = 2;

    private int score = 0;
    private int lives = 5;
    private int shield = 0;

    private float spawnTime;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

	public delegate void PlayerDeathDelegate();
	public static event PlayerDeathDelegate OnPlayerDeath;

    public delegate void SpawnDelegate(int shield);
    public static event SpawnDelegate OnSpawn;
     
	private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp();
	}

    private void SetUp()
    {
		//initialize
		spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

		//set the text correctly
		scoreText.text = "Score: " + score.ToString();
		livesText.text = "Lives: " + lives.ToString() + " Shield: " + shield.ToString();

		StartCoroutine(Spawn());
	}

    public void IncreaseScore(int pointsGained)
    {
        score += pointsGained;
        scoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }

    public void IncreaseShield(int shieldValue)
    {
        shield += shieldValue;
		livesText.text = "Lives: " + lives.ToString() + " Shield: " + shield.ToString();
	}

	public void LooseLives (int damage)
    {
        if (shield > 0)
        {
            shield--;
			livesText.text = "Lives: " + lives.ToString() + " Shield: " + shield.ToString();
		}
		else
        {
        lives -= damage;
        livesText.text = "Lives: " + lives.ToString() + " Shield: " + shield.ToString();
        }

        if (lives <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    private IEnumerator Spawn()
    {
		//wait for the timer value then spawn an enemy and randomize the spawn timer
		spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
		yield return new WaitForSeconds(spawnTime);

		OnSpawn?.Invoke(shield);
        StartCoroutine(Spawn());
    }
}

