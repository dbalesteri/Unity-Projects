using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectActivator : MonoBehaviour
{

    public GameObject objectToActivate;

    public string questToCheck;

    public bool activeIfComplete;
    public bool deactivateIfComplete;

    private bool initalCheckDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!initalCheckDone)
        {
            initalCheckDone = true;
            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            if (activeIfComplete)
            {

                objectToActivate.SetActive(activeIfComplete);

            }

            if (deactivateIfComplete)
            {
                objectToActivate.SetActive(false);
            }
        }
    }
}
