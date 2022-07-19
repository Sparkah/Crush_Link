using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTowerLevelCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _towerLocation;
    [SerializeField] private GameObject _level1Tower;
    [SerializeField] private GameObject _level2Tower;

    public void Level1()
    {
        foreach(var tower in _towerLocation.GetComponentsInChildren<TowerController>())
        {
            Destroy(tower.gameObject);
        }
        Instantiate(_level1Tower, _towerLocation.transform);
    }
    public void Level2()
    {
        foreach (var tower in _towerLocation.GetComponentsInChildren<TowerController>())
        {
            Destroy(tower.gameObject);
        }
        Instantiate(_level2Tower, _towerLocation.transform);
    }
}
