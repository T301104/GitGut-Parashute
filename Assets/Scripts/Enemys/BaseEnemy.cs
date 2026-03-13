using UnityEngine;

public class BaseEnemy : EnemyMovement
{
	public void Start()
	{
		OnStartBase();
	}
	public override void OnPlayerCollision()
	{
		GameManager.Instance.IncreaseScore(points);
		base.OnPlayerCollision();
	}

	public override void OnFloorCollision()
	{
		GameManager.Instance.LooseLives(damage);
		base.OnFloorCollision();
	}

}
