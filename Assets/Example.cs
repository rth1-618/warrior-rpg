using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake is called");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start is called");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is called");
    }



//called 50 times per second; useful for fixed physics calculation without dependency on fps of device
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate is called");
    }
}
