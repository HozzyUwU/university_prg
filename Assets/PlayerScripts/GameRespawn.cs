using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRespawn : MonoBehaviour
{
    private Transform player;
    [SerializeField]  private float treshhold;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Transform>();
        treshhold = -5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < treshhold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
