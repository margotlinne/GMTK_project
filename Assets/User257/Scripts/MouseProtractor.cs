using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    public class MouseProtractor : MonoBehaviour
    {
        [SerializeField] Transform mouseFollower; 

        public Vector2 GetAngle()
        {
            Vector2 dirToMouse = transform.position - mouseFollower.transform.position;

            return dirToMouse.normalized * -1f; //-1f 는 월드 기준이 아니라 모니터 기준으로 하기 위함
        }
    }
}
