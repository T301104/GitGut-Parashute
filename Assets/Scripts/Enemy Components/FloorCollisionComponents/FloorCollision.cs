using UnityEngine;

public class FloorCollision : MonoBehaviour
{
	public virtual void OnFloorCollision()
	{
		Destroy(gameObject);
	}
}
