using UnityEngine;

public class ShieldGain : PlayerCollision
{
	[SerializeField] private int shieldValue = 1;
	public override void OnPlayerCollision()
	{
		GameManager.Instance.IncreaseShield(shieldValue);
		base.OnPlayerCollision();
	}
}
