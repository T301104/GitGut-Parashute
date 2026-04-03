using UnityEngine;
using System.Collections;

public class ValuableMovement : BaseMovement
{
	[SerializeField] private float speedMultiplier = 1.5f;
	[SerializeField] private float secondsGoingUp = 0.5f;
	[SerializeField] private float secondsGoingDown = 2;

	private bool shouldChangeDirection = true;
	public void Start()
	{
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

}
