using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timer;
    public AudioSource audioSource;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        if(audioSource != null)
            audioSource.Play();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            if(GetComponent<SpriteRenderer>() != null)
                Destroy(GetComponent<SpriteRenderer>());
        }

        if(timer <= -0.5f)
            Destroy(gameObject);
    }
}
