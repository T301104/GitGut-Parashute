using UnityEngine;

public abstract class PlayerCollision : MonoBehaviour
{
	public virtual void OnPlayerCollision()
	{
		Destroy(gameObject);
	}
}
