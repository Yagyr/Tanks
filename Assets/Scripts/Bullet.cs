using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    public bool isActive;

    public void Hide()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public void Shot(Vector3 position, Quaternion rotation)
    {
        isActive = true;
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = rotation;  
    }

    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.GetComponent<Brick>();
        if (brick)
        {

            Collider[] collider = Physics.OverlapBox(transform.position, new Vector3(0.4f, 0.1f, 0.1f), transform.rotation);
            for (int i = 0; i < collider.Length; i++)
            {
                Brick overlapedpBrick = collider[i].GetComponent<Brick>();
                if (overlapedpBrick)
                {
                    overlapedpBrick.TakeDamage();
                }

            }
        }

        Tank tank = other.GetComponent<Tank>();
        if (tank)
        {
            tank.TakeDamage();
        }
        Hide();
    }
}
