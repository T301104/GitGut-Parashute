using UnityEngine;

public class BaseMovement : MonoBehaviour
{
	[SerializeField] protected float minXSpeed = -3;
	[SerializeField] protected float maxXSpeed = 3;
	[SerializeField] protected float minYSpeed = -3;
	[SerializeField] protected float maxYSpeed = -4;

	private float xSpeed;
	protected float ySpeed;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
    {
        SetUp();
    }
	public void SetUp()
	{
		//set the speeds to a value between the random ranges
		xSpeed = Random.Range(minXSpeed, maxXSpeed);
		ySpeed = Random.Range(minYSpeed, maxYSpeed);
	}

	public virtual void move()
	{
		transform.position = transform.position + new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
	}

	public void OnWallCollision()
	{
		//turn orb around when hitting a wall
		xSpeed = xSpeed * -1;
	}
	}
