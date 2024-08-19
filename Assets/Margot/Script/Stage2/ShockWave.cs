using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class ShockWave : MonoBehaviour
    {
        [SerializeField] private float shockWaveTime = 0.75f;

        Coroutine shockWaveCoroutine;
        Material mateiral;

        private static int waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");


        void Awake()
        {
            mateiral = GetComponent<SpriteRenderer>().material;
        }

        public void CallShockWave()
        {
            shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
        }

        IEnumerator ShockWaveAction(float startPos, float endPos)
        {
            mateiral.SetFloat(waveDistanceFromCenter, startPos);

            float lerpedAmount = 0f;
            float elapsedTime = 0f;

            while(elapsedTime < shockWaveTime)
            {
                elapsedTime += Time.deltaTime;

                lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
                mateiral.SetFloat(waveDistanceFromCenter, lerpedAmount);

                yield return null;
            }
        }

    }
}

