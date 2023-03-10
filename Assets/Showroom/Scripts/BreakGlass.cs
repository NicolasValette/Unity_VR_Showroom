using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Showroom
{
    public class BreakGlass : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private float _timeBeforeRepair;
        [SerializeField]
        private GameObject _repairCube;
        [SerializeField]
        private GameObject _brokenCube;
        [SerializeField]
        private Collider _collider;

        private bool _isBreakable = true;

        private void Awake()
        {
            _repairCube.SetActive(true);
            _brokenCube.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Break");
            if (_isBreakable)
            {
                ToggleStateCube();
                _audioSource.Play();
                _animator.SetTrigger("Break");
                StartCoroutine(WaitBeforeRepair());
            }
        }

        private IEnumerator WaitBeforeRepair ()
        {
            yield return new WaitForSeconds(_timeBeforeRepair);
            _animator.SetTrigger("Repair");
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(info.length);
            ToggleStateCube();
        }
        private void ToggleStateCube()
        {
            Debug.Log("Toggle");
            _isBreakable = !_isBreakable;
            _collider.enabled = !_collider.enabled;
            _repairCube.SetActive(!_repairCube.activeSelf);
            _brokenCube.SetActive(!_brokenCube.activeSelf);
        }
    }
}
