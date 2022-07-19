using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Поделить скрипт на UI и общая логика solid 
    private Image _healthBar;

    [SerializeField] private float health = 4;
    private float _initialHealth;

    private void Start()
    {
        _initialHealth = health;
        _healthBar = GetComponentInChildren<Image>();
    }

    void Update()
    {
        transform.position += new Vector3(-1f, 0, 0)*Time.deltaTime;
        _healthBar.transform.position = gameObject.transform.position + new Vector3(0,1,0);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        _healthBar.fillAmount -= damage / _initialHealth;
        if (health <= 0)
        {
            StartCoroutine(TravelFastToEscapeZone());
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
    IEnumerator TravelFastToEscapeZone()
    {
        if(gameObject.transform.position.x<-100||gameObject.transform.position.z>100)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0.01f);
        transform.position += new Vector3(-5f, 0, 5f);
        StartCoroutine(TravelFastToEscapeZone());
    }
}
