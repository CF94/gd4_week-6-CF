using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange = 4.5f;

    public float thrust;

    public int pointValue;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);
        rb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), ForceMode.Impulse);        
        transform.position = new Vector3(Random.Range(-xRange, xRange), -1, 0);
    }

    void Update()
    {
        if (transform.position.y < -4) Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        if (transform.tag == "Object Good") FindFirstObjectByType<GameManager>().score++;
        else FindFirstObjectByType<GameManager>().lives--;

        rb.AddForce(transform.up * thrust, ForceMode.Impulse);

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        
        gameManager.updateScore(pointValue);

        if (transform.tag == "Object Bad")
        {
            Destroy(gameObject);
        }
    }
}
