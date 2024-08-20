using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class ShockWave : MonoBehaviour
    {

        [SerializeField] private float shockWaveTime = 0.75f;

        public StageTwoManager manager;

        Coroutine shockWaveCoroutine;
        Material _material;
        Camera mainCamera;

        public Transform player;
        public Transform shockWaveObj;

        private static int waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");


        void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        public void CallShockWave()
        {
            if (manager.withNegativeLight)
            {
                SfxManager.instance.ShockwaveNegSoundPlay();
            }
            else
            {
                SfxManager.instance.ShockwavePosSoundPlay();
            }
            shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f));
        }

        public void BackToPlayer()
        {
            shockWaveObj.position = player.position;
        }
        IEnumerator ShockWaveAction(float startPos, float endPos)
        {
            _material.SetFloat(waveDistanceFromCenter, startPos);

            float lerpedAmount = 0f;
            float elapsedTime = 0f;

            while(elapsedTime < shockWaveTime)
            {
                elapsedTime += Time.deltaTime;

                lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
                _material.SetFloat(waveDistanceFromCenter, lerpedAmount);

                

                yield return null;
            }
        }

    }
}

