using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    enum STATE {TIRED, OK, HAPPY, SAD}
    STATE myState;
    [SerializeField] int currentState = 0;
    // Update is called once per frame
    void Update()
    {
        
    }

    void State()
    {       
        switch (currentState)
        {
            case 1:
                myState = STATE.TIRED;
                break;
            case 2:
                myState = STATE.OK;
                break;
            case 3:
                myState = STATE.HAPPY;
                break;
            case 4:
                myState = STATE.SAD;
                break;
        }        

    }
}
    

