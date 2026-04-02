using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float minXSpeed = -3;
    [SerializeField] protected float maxXSpeed = 3;
    [SerializeField] protected float minYSpeed = -3;
    [SerializeField] protected float maxYSpeed = -4;

    protected int damage = 1;
    protected int points = 1;
    private float xSpeed;
    protected float ySpeed;

	public void SetUp()
	{
		//set the speeds to a value between the random ranges
		xSpeed = Random.Range(minXSpeed, maxXSpeed);
		ySpeed = Random.Range(minYSpeed, maxYSpeed);
	}

	void FixedUpdate()
    {
        //move enemy
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //turn orb around when hitting a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            xSpeed = xSpeed * -1;
        }
        //Run Player collision on hitting player
        else if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision();
        }
        //Run floor collision on hitting the floor
        else if (collision.gameObject.CompareTag("Floor"))
        {
            OnFloorCollision();
        }
    }

    public virtual void Move()
    {
		transform.position = transform.position + new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
	}

	public virtual void OnPlayerCollision()
    {
        Debug.Log(points);
		Destroy(gameObject);
	}

	public virtual void OnFloorCollision()
    {
        Debug.Log(damage);
		Destroy(gameObject);
	}
}
