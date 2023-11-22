using TMPro;
using UnityEngine;

namespace Heyipomoea
{
    /// <summary>
    /// 分數管理器:打擊到方塊後播放音效及累加分數
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        [SerializeField, Header("音效")]
        private AudioClip soundHit;
        [SerializeField, Header("分數文字")]
        private TextMeshProUGUI textScore;

        private AudioSource aud;
        private int score = 0;
        private int socrePerHit = 10;

        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 添加分數並播放音效
        /// </summary>
        /// <param name="min">最小音量</param>
        /// <param name="max">最大音量</param>
        public void AddScoreAndPlaySound(float min, float max)
        {
            float randomVolume = Random.Range(min, max);
            aud.PlayOneShot(soundHit, randomVolume);
            score += socrePerHit;
            textScore.text = score.ToString();
        }
    }
}

