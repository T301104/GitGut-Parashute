using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject baseEnemyPrefab;
    [SerializeField] private GameObject valuableEnemyPrefab;
    [SerializeField] private GameObject shieldingEnemyPrefab;
    private GameObject currentEnemy;
    private Collider2D spawnLimits;
    [SerializeField] private float minSpawnTime = 1;
    [SerializeField] private float maxSpawnTime = 2;
    private int score = 0;
    private int lives = 5;
    private int shield = 0;
    private bool shouldSpawn = true;
    private float spawnTime;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize
        spawnLimits = gameObject.GetComponent<Collider2D>();
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        //set the text correctly
        scoreText.text = "Score: " + score.ToString();
		livesText.text = "Lives: " + lives.ToString() + " Shield: " + shield.ToString();
	}

	// Update is called once per frame
	void Update()
    {
        //if the lives get to 0 move to the game over screen
        if (lives <=0)
        {
            SceneManager.LoadScene("GameOver");
        }

        //if should spawn execute the spawn coroutine
        if (shouldSpawn)
        {
            //randomly decide what enemy should be spawned
            int enemy = Random.Range(0, 10);
            Debug.Log("enemy:" + enemy);
            if (enemy == 0)
            {
                StartCoroutine(Spawn(valuableEnemyPrefab));
            }
            else if (enemy == 1)
            {
                StartCoroutine (Spawn(shieldingEnemyPrefab));
            }
            else
            {
                StartCoroutine(Spawn(baseEnemyPrefab));
            }
        }
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
    }

    private IEnumerator Spawn(GameObject objectToSpawn)
    {
        //wait for the timer value then spawn an enemy and randomise the spawn timer
        shouldSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        currentEnemy = Instantiate(objectToSpawn, new Vector2(Random.Range(spawnLimits.bounds.min.x, spawnLimits.bounds.max.x), spawnLimits.bounds.center.y), Quaternion.identity);
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        shouldSpawn = true;
    }
}
