using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ColumnsBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject columnsPref;
    public Transform columnsParent;
    public Transform positionInstance;
    public Transform limitPosition;
    public float upperLimit;
    public float lowerLimit;

    public float time;
    public float timeLimit;

    private void Update()
    {
        CreateColumn();
    }

    public void CreateColumn()
    {
        time += Time.deltaTime;
        if (time >= timeLimit)
        {
            var newColumn = Instantiate(columnsPref, positionInstance.position, Quaternion.identity, columnsParent);
            newColumn.transform.position = new(newColumn.transform.position.x, Random.Range(lowerLimit, upperLimit), 0);
            newColumn.GetComponent<CoilBehaviour>().limitPoint = limitPosition;
            newColumn.GetComponent<CoilBehaviour>().gameManager = gameManager;

            time = 0;
        }

        
    }


}*/
