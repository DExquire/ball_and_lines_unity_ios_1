using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsBehaviour : MonoBehaviour
{
//    public GameManager gameManager;
    public GameObject columnsPref;
    public Transform columnsParent;
    public Transform positionInstance;
    public Transform limitPosition;
    public float upperLimit;
    public float lowerLimit;
    public int currentColumnNumber;

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
            currentColumnNumber += 1;
            /*var newColumn = Instantiate(columnsPref, positionInstance.position, Quaternion.identity, columnsParent);
            newColumn.transform.position = new(newColumn.transform.position.x, Random.Range(lowerLimit, upperLimit), 0);
            newColumn.GetComponent<CoilBehaviour>().limitPoint = limitPosition;
            newColumn.GetComponent<CoilBehaviour>().gameManager = gameManager;*/

            var newColumn = transform.GetChild(currentColumnNumber);
            newColumn.gameObject.SetActive(true);
            newColumn.transform.GetChild(2).gameObject.SetActive(true);
            newColumn.transform.position = new(positionInstance.position.x, Random.Range(lowerLimit, upperLimit), 0);
    //        newColumn.GetComponent<CoilBehaviour>().limitPoint = limitPosition;
    //        newColumn.GetComponent<CoilBehaviour>().gameManager = gameManager;
            time = 0;
        }
        if(currentColumnNumber == transform.childCount-1)
        {
            currentColumnNumber = -1;
        }

        
    }


}
