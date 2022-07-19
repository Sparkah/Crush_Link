using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private List<GameObject> _enemies = new List<GameObject>();
    [HideInInspector]
    public GameObject _target;

    void FixedUpdate()
    {
        if(_target==null&&_enemies!=null)
        {
            ChooseEnemyToAttack();
        }

        if (_target != null)
        {
            gameObject.transform.LookAt(_target.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyController>()!=null)
        {
            _enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            _enemies.Remove(other.gameObject);
            if (other.gameObject==_target)
            {
                _target = null;
            }
        }
    }

    private void ChooseEnemyToAttack()
    {
        if(_target==null)
        {
            _target = CalculateEnemyDistance();
        }
        else
        {
            //ScripTowerGunFire
        }
    }

    public void RemoveTargetFromList(GameObject enemy)
    {
        _enemies.Remove(enemy);
    }

    private GameObject closestEnemy;
    private GameObject CalculateEnemyDistance()
    {
        float closestDistance = 999;
        foreach(GameObject enemy in _enemies)
        {
            float enemyDistance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            if (enemyDistance<closestDistance)
            {
                closestDistance = enemyDistance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}