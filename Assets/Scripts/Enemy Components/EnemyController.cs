using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerCollision playerCollisionClass;
	private BaseMovement movementClass;
	private FloorCollision floorCollisionClass;

	private void Awake()
	{
		playerCollisionClass = GetComponent<PlayerCollision>();
		movementClass = GetComponent<BaseMovement>();
		floorCollisionClass = GetComponent<FloorCollision>();
	}

	private void Update()
	{
		movementClass.Move();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//call apropriate function for hitting a wall
		if (collision.gameObject.CompareTag("Wall"))
		{
			movementClass.OnWallCollision();
		}
		//call apropriate function for hitting player
		else if (collision.gameObject.CompareTag("Player"))
		{
			playerCollisionClass.OnPlayerCollision();
		}
		//call apropriate function for hitting the floor
		else if (collision.gameObject.CompareTag("Floor"))
		{
			floorCollisionClass.OnFloorCollision();
		}
	}
}
