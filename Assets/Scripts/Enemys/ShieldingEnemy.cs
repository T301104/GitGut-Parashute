using UnityEngine;

public class ShieldingEnemy : EnemyMovement
{
	private int shieldValue = 1;
	private void Start()
	{
		OnStartBase();
	}

	public override void OnPlayerCollision()
	{
		GameManager.Instance.IncreaseShield(shieldValue);
		base.OnPlayerCollision();
	}

	public override void OnFloorCollision()
	{
		base.OnFloorCollision();
	}

}
