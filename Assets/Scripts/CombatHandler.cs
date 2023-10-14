using Unity.VisualScripting;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    
    //private CharacterController _playerController;
    private PlayerController _playerController;
    private EnemyLife _enemy;
    private PlayerLife _player;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _player = GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _playerController._isInCombat = true;
            //_enemy = other.gameObject.GetComponent<EnemyLife>();
            if(other.gameObject.TryGetComponent<EnemyLife>(out _enemy))
            {
                _playerController.transform.position = new Vector3(_enemy.transform.position.x - 1.0f, _playerController.transform.position.y, _playerController.transform.position.z);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(_playerController._isInCombat)
        {
            if(_enemy != null)
            {
                _player.TakeDamage(_enemy.DoDamage());
                _enemy.TakeDamage(_player.DoDamage());
            }
            else
            {
                _playerController._isInCombat = false;
            }
        }
        //if(_playerCollider.SendMessage);
    }
}
