using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private int rotationSpeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
