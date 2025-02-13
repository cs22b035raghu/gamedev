using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 30f;  // Speed exposed to Inspector
    private float horizontalInput;
    private float verticalInput;
    //public bool enabled1=false;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);
        
    }
}
