using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    public class StageSelectManager : MonoBehaviour
    {
        [SerializeField] Selecter child;
        [SerializeField] Selecter student;
        [SerializeField] Selecter adult;
        [SerializeField] Selecter grandpa;

        private void Start()
        {
            child.enabled = true;
            student.enabled = false;
            adult.enabled = false;
            grandpa.enabled = false;

            if (GameManager.Instance.GetStageClear(GameManager.Stage.Child))
            {
                student.enabled = true;
                adult.enabled = false;
                grandpa.enabled = false;
            }
            if (GameManager.Instance.GetStageClear(GameManager.Stage.Student))
            {
                adult.enabled = true;
                grandpa.enabled = false;
            }
            if (GameManager.Instance.GetStageClear(GameManager.Stage.Adult))
                grandpa.enabled = true; 
        }
    }
}
