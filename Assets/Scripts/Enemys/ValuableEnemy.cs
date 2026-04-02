using UnityEngine;
using System.Collections;

public class ValuableEnemy : EnemyMovement
{
	[SerializeField] private int valuablePoints = 5;
	[SerializeField] private float speedMultiplier = 1.5f;
	[SerializeField] private float secondsGoingUp = 1;
	[SerializeField] private float secondsGoingDown = 2;

	private bool shouldChangeDirection = true;

	//the valuable enemy will move faster, and give more points when picked up.
	//it won't make the player lose HP if they miss it since it might at times be impossible to get

	public void Start()
	{
		points = valuablePoints;
		minXSpeed *= speedMultiplier;
		maxXSpeed *= speedMultiplier;
		minYSpeed *= speedMultiplier;
		maxYSpeed *= speedMultiplier;

		SetUp();
	}

	public override void Move()
	{
		if (shouldChangeDirection)
		{
			StartCoroutine(ChangeFallingDirection());
		}
		base.Move();
	}

	private IEnumerator ChangeFallingDirection()
	{
		shouldChangeDirection = false;
		if (ySpeed < 0)
		{
			yield return new WaitForSeconds(secondsGoingDown);

		}
		else
		{
			yield return new WaitForSeconds(secondsGoingUp);
		}
		ySpeed *= -1;
		shouldChangeDirection = true;
	}

	public override void OnPlayerCollision()
	{
		GameManager.Instance.IncreaseScore(points);
		base.OnPlayerCollision();
	}

	public override void OnFloorCollision()
	{
		base.OnFloorCollision();
	}
}
