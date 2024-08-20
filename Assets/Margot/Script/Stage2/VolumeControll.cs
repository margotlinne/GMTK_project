using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class VolumeControll : MonoBehaviour
    {
        public GameObject[] volumeBars;

        public StageTwoManager manager;
        public PhoneAnim phoneAnim;


        public float warningBGAdjustSize = 0.15f;

        void Update()
        {
            if (!manager.stageClear)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (ActiveVolumeBars() > 0)
                    {
                        volumeBars[ActiveVolumeBars() - 1].SetActive(false);
                        Debug.Log("lower volume");
                        //manager.distanceToDetect -= 1f;
                        manager.volumeLevel -= 1;
                        manager.shockWave.CallShockWave();

                        phoneAnim.VolumeDownAnimation();

                        SfxManager.instance.VolDownSoundPlay();

                        if (manager.withNegativeLight)
                        {
                            Debug.Log("---volume down next to negative sound");
                            manager.AdjustWarningBGColour(warningBGAdjustSize, false);
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (ActiveVolumeBars() < volumeBars.Length)
                    {
                        volumeBars[ActiveVolumeBars()].SetActive(true);
                        Debug.Log("increase volume");
                        //manager.distanceToDetect += 1f;

                        manager.volumeLevel += 1;
                        manager.shockWave.CallShockWave();

                        phoneAnim.VolumeUpAnimation();

                        SfxManager.instance.VolUpSoundPlay();

                        if (manager.withNegativeLight)
                        {
                            Debug.Log("---volume up next to negative sound");
                            manager.AdjustWarningBGColour(warningBGAdjustSize, true);
                        }
                    }
                }


                if (manager.volumeToZero)
                {
                    for (int i = 0; i < volumeBars.Length; i++)
                    {
                        volumeBars[i].SetActive(false);
                    }
                    manager.volumeToZero = false;
                }
            }

            int ActiveVolumeBars()
            {
                int activeNum = 0;

                for (int i = 0; i < volumeBars.Length; i++)
                {
                    if (volumeBars[i].activeSelf)
                    {
                        activeNum++;
                    }
                }

                return activeNum;
            }
        }
    }

}