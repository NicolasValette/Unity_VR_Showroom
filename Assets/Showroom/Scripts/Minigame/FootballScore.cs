using Showroom.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shoowroom.Minigame
{
    public class FootballScore : MonoBehaviour
    {
        [SerializeField]
        private GameObject _scorePanel;
        [SerializeField]
        private TMP_Text _scoreText;

        private AudioSource _audioSource;

        private int _score;
        // Start is called before the first frame update
        void Start()
        {
            _audioSource= GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball")) //a ball is entering goal
            {
                Debug.Log("Goal : " + _score);
                if (!_scorePanel.GetComponent<PopupPanel>().IsPop)
                {
                    _scorePanel.GetComponent<PopupPanel>().PopupInfo();
                }
                _scoreText.text = $"Goal {++_score}";
                other.gameObject.GetComponent<ParticleSystem>().Play();
                _audioSource.Play();
            }
        }
    }
}
