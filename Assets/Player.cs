using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName = "Bob";
    public int age = 25;
    public float moveSpeed = 2.5f;
    public bool gameOver = false;

    private void Start()
    {
        playerName = "Bob The Hero";
        Debug.Log(playerName + " - started the game!");
    }
}
