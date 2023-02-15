using DG.Tweening;
using Drag;
using Managers;
using UnityEngine;

namespace Montage
{
    public class ObjectMontage : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Draggable _draggable;

        [SerializeField] private float offset;
        [SerializeField] private float silhouetteOffset;
        [SerializeField] private float montageRotation;

        private bool _isMontage;

        private void Start()
        {
            InvokeRepeating(nameof(MontageControl), 0, 0.2f);
        }

        private void MontageControl()
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < offset && !_isMontage)
            {
                GameManager.Instance.montageCount++;
                _draggable.isDrag = false;
                _isMontage = true;
                _target.SetActive(false);

                transform.DOMove(_target.transform.position, 1f);
                transform.DOLocalRotate(new Vector3(montageRotation + 360, 360, 0), 1f, RotateMode.FastBeyond360);
                
                GameManager.Instance.SuccessControl();
            }

            if (Vector3.Distance(transform.position, _target.transform.position) > offset && _isMontage)
            {
                GameManager.Instance.montageCount--;
                _isMontage = false;
            }
            

            _target.SetActive(Vector3.Distance(transform.position, _target.transform.position) < silhouetteOffset);
        }
    }
}