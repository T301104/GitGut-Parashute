using UnityEngine;

public class PlayerCollisionPoint : PlayerCollision
{
	[SerializeField] private int pointsValue = 1;

	public override void OnPlayerCollision()
	{
		GameManager.Instance.IncreaseScore(pointsValue);
		base.OnPlayerCollision();
	}
}
