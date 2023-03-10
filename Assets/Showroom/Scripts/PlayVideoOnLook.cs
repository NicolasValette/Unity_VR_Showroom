using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Showroom
{

    public class PlayVideoOnLook : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerHead;

        private VideoPlayer _videoPlayer;

        // Start is called before the first frame update
        void Start()
        {
            _videoPlayer = GetComponent<VideoPlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 toPlayer = _playerHead.position - transform.position;
            float dotResult = Vector3.Dot(toPlayer.normalized, _playerHead.transform.forward);
            PlayOrStopVideo(dotResult);
        }

        private void PlayOrStopVideo(float dotResult)
        {
            if (_videoPlayer != null)
            {
                if (!_videoPlayer.isPlaying && dotResult <= -0.5f)
                {
                    _videoPlayer.Play();
                }
                else if (_videoPlayer.isPlaying && dotResult > -0.5f)
                {
                    _videoPlayer.Pause();
                }

            }
        }
    }
}
