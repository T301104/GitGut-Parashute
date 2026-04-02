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
		movementClass.move();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//turn orb around when hitting a wall
		if (collision.gameObject.CompareTag("Wall"))
		{
			movementClass.OnWallCollision();
		}
		//Run Player collision on hitting player
		else if (collision.gameObject.CompareTag("Player"))
		{
			playerCollisionClass.OnPlayerCollision();
		}
		//Run floor collision on hitting the floor
		else if (collision.gameObject.CompareTag("Floor"))
		{
			floorCollisionClass.OnFloorCollision();
		}
	}
}
