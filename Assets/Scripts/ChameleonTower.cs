using UnityEngine;

public class ChameleonTower : MonoBehaviour
{
    private TowerController _tower;
    private GameObject _targetToAttack;
    private bool _rollForward;
    private Vector3 initialLocalScale;

    private SphereCollider _sphereCollider;

    //SO setup
    private int _towerLevel;
    private float _fireSpeed;
    private float _damage;
    private float _radius;
    public ChamilionTowerSO ChamilionTowerSO;


    void Start()
    {
        _tower = GetComponentInParent<TowerController>();
        _rollForward = true;
        initialLocalScale = gameObject.transform.localScale;
        _sphereCollider = GetComponentInParent<SphereCollider>();
        SetTowerStats();
    }

    private void SetTowerStats()
    {
        _towerLevel=ChamilionTowerSO.TowerLevel;
        _fireSpeed = ChamilionTowerSO.FireSpeed;
        _damage = ChamilionTowerSO.Damage;
        _radius = ChamilionTowerSO.Radius;

        _sphereCollider.radius = _radius;
        Debug.Log(_towerLevel);
        //same for other stats
    }

    private void Update()
    {
        if (_targetToAttack != _tower._target)
        {
            _targetToAttack = _tower._target;
            gameObject.transform.localScale = initialLocalScale;
        }
    }

    private void FixedUpdate()
    {
        if (_rollForward &&_targetToAttack!=null)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z * 1.1f);
        }
        if (!_rollForward && _targetToAttack != null)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z * 0.9f);
            if(gameObject.transform.localScale.z<= initialLocalScale.z)
            {
                _rollForward = true;
            }
        }
    }

    private GameObject _currentAttack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            if(_currentAttack!=other.gameObject)
            {
                _currentAttack = other.gameObject;
                _damage = ChamilionTowerSO.Damage;
            }

            _rollForward = false;
            other.GetComponent<EnemyController>().TakeDamage(_damage);

            if(_targetToAttack == _tower._target && _towerLevel>=2)
            {
                Debug.Log("Damage increased");
                _damage *= 2;
            }
        }
    }
}
