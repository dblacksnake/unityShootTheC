using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    private GameObject[] ennemies = new GameObject[10];
    //private Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    private GameObject ennemie;
    public GameObject target;
    private float attackSpeed = 2.5f;
    Vector3 ennemiePosition;

   void Awake()
    {
       Vector3 targetPosition = target.transform.position; 
    }

    // Start is called before the first frame update
    void Start()
    {   

       for(var i = 0 ; i <  ennemies.Length;i++){
            ennemies[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ennemies[i].transform.position = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(0.5f,1.5f), Random.Range(-100.0f, 100.0f));
            ennemies[i].name = $"ennemie{i}"; 

        }
    }

    // Update is called once per frame
    void Update()
    {
         for(var i = 0; i< ennemies.Length; i++){
            ennemies[i].transform.position = Vector3.MoveTowards(ennemies[i].transform.position, target.transform.position,attackSpeed * Time.deltaTime);
            
         }
    }
}
