using UnityEngine;

public abstract class FloorCollision : MonoBehaviour
{
	public virtual void OnFloorCollision()
	{
		Destroy(gameObject);
	}
}
