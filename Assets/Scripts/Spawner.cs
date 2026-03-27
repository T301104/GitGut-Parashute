using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject baseEnemyPrefab;
	[SerializeField] private GameObject valuableEnemyPrefab;
	[SerializeField] private GameObject shieldingEnemyPrefab;

	private Collider2D spawnLimits;

	private GameObject currentEnemy;

	public void Awake()
	{
		spawnLimits = gameObject.GetComponent<Collider2D>();
		GameManager.OnSpawn += Spawn;
	}

	public void Spawn(int shield)
	{
		//randomly decide what enemy should be spawned
		int enemy = Random.Range(0, 20);
		Debug.Log("enemy:" + enemy);
		if (enemy == 0 || enemy == 1)
		{
			Spawn(valuableEnemyPrefab);
		}
		else if (enemy == 2 && shield < 2)
		{
			Spawn(shieldingEnemyPrefab);
		}
		else
		{
			Spawn(baseEnemyPrefab);
		}
	}


	private void Spawn(GameObject objectToSpawn)
	{
		//wait for the timer value then spawn an enemy and randomise the spawn timer
		currentEnemy = Instantiate(objectToSpawn, new Vector2(Random.Range(spawnLimits.bounds.min.x, spawnLimits.bounds.max.x), spawnLimits.bounds.center.y), Quaternion.identity);
	}
}

