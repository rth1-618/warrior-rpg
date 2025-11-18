using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]private float redDuration = 1; 

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }
    public void TakeDamage()
    {
        sr.color = Color.red;

        //Invoke(nameof(TurnWhite), redDuration);
    }

    private void TurnWhite()
    {
        sr.color = Color.white;
    }

}
