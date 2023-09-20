using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRespawn : MonoBehaviour
{
    public CharacterController controller;
    public float treshhold;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        treshhold = -5f;
        spawnPoint = controller.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.transform.position.y < treshhold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
