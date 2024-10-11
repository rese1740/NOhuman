using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    #region Singleton
    public static DataBaseManager Instance;
   
    #endregion

    [Header("새")]
    public Bird birds;

    [Header("자원")]
    public Ore Wood;
    public Ore Stone;
    public Ore Mental;

    [Header("자원")]
    public int TreeCount;
    public int StoneCount;
    public float MentalCount = 100;

    public void Init()
    {
        Instance = this;
    }
}
