using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float minXSpeed = -2f;
    [SerializeField] protected float maxXSpeed = 2f;
    [SerializeField] protected float minYSpeed = -2.4f;
    [SerializeField] protected float maxYSpeed = -3.8f;

    protected int damage = 1;
    protected int points = 1;
    private float xSpeed;
    protected float ySpeed;


	public void OnStartBase()
	{
		//set the speeds to a value between the random ranges
		xSpeed = Random.Range(minXSpeed, maxXSpeed);
		ySpeed = Random.Range(minYSpeed, maxYSpeed);
	}

	void FixedUpdate()
    {
        //move enemy
        move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //turn orb around when hitting a wall
        if (collision.gameObject.tag == "Wall")
        {
            xSpeed = xSpeed * -1;
        }

        //remove orb when hitting player and add score
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerCollision();
        }

        //remove orb when it gets too low and lower the lives
        if (collision.gameObject.tag == "Floor")
        {
            OnFloorCollision();
        }
    }

    public virtual void move()
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
