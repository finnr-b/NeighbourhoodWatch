using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteWalk : MonoBehaviour
{
    public Vector3 startingPoint;
    public Vector3 targetPoint;
    public float speed = 0.5f;
    public float damageAmount = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HouseHealth houseComponent))
        {
            Destroy(gameObject);
        }
    }
}