using UnityEngine;

public class CandleLightEffect : MonoBehaviour
{
    public Light candleLight; // 인스펙터 창에서 연결할 포인트 라이트
    public float minIntensity = 0.8f; // 최소 밝기
    public float maxIntensity = 1.2f; // 최대 밝기
    public float flickerSpeed = 0.1f; // 깜빡임 속도

    private float randomOffset;

    void Start()
    {
        if (candleLight == null)
        {
            candleLight = GetComponent<Light>();
        }
        // 모든 촛불이 똑같이 깜빡이지 않도록 시작값에 랜덤을 줍니다.
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Perlin Noise를 사용하여 부드럽고 자연스러운 깜빡임을 만듭니다.
        float noise = Mathf.PerlinNoise(randomOffset, Time.time * flickerSpeed);
        candleLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}