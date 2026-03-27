using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
	void Awake()
	{
		GameManager.OnPlayerDeath += LoadGameOver;
	}

	private void LoadGameOver()
	{
		SceneManager.LoadScene("GameOver");
	}
}
