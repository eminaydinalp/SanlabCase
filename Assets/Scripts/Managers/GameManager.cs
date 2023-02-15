using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public int montageCount;
        public int needMontageCount;

        [SerializeField] private GameObject successText;
        private void Awake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        public void SuccessControl()
        {
            if (montageCount >= needMontageCount)
            {   
                DOVirtual.DelayedCall(1, () => successText.SetActive(true));
            }
        }
    }
}
