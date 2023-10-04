using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{

    private PlayerLife _player;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_player.Die();
            Debug.Log("EMOTIONAL DAMAGE");
        }
    }
}
