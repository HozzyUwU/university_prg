using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float _treshhold;

    private Transform _player;

    private Vector3 _spawnPoint;
    
    private void Awake()
    {
        _player = GetComponent<Transform>();
        _treshhold = -5f;
        _spawnPoint = _player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Die();
        }
        else if (other.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _spawnPoint = _player.transform.position;
        }
        else if (other.CompareTag("PrevLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            _spawnPoint = _player.transform.position;
        }
    }
    
    private void Die()
    {
        _player.transform.position = _spawnPoint;
    }

    void Update()
    {
        if (_player.position.y < _treshhold)
        {
            Die();
        }
    }
}
