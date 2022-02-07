using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum EnemyType
{
    NormalA,
    NormalB,
    NormalC,
    Female,
    Male
}

public class EnemyManager : SerializedMonoBehaviour
{
    [SerializeField] 
    private Dictionary<EnemyType, GameObject> enemyObjDict
        = new Dictionary<EnemyType, GameObject>();
    
    // TODO: Instance pool
    public void SpawnEnemy(EnemyType type, Vector3 pos)
    {
        
    }
}
