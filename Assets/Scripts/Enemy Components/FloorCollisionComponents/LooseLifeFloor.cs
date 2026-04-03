using UnityEngine;

public class LooseLifeFloor : FloorCollision
{
	[SerializeField] private int damage = 1;

	public override void OnFloorCollision()
	{
		GameManager.Instance.LooseLives(damage);
		base.OnFloorCollision();
	}
}
