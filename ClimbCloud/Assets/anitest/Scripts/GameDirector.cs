using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject king;
    public GameObject pig;
    
    void Update()
    {
        float distance = Vector3.Distance(king.transform.position, pig.transform.position);
        Debug.Log($"¿ÕÀÌ¶û µÅÁö¿Õ °Å¸®: {distance}");
    }
}
