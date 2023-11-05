using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cm;

    [Header("Shake Control")]
    [SerializeField] private float shakeTime = 0.5f;
    [SerializeField] private float amplitudeGain=1;
    [SerializeField] private float frequencyGain=1;
    [SerializeField] private float newFieldOfView;
    [SerializeField] private float oldFieldOfView;
    private CinemachineBasicMultiChannelPerlin noise;



    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerGetDamage,OnPlayerGetDamage);
        EventManager.AddHandler(GameEvent.OnCollectKey,OnCollectKey);
        EventManager.AddHandler(GameEvent.OnLevelEnd,OnLevelEnd);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerGetDamage,OnPlayerGetDamage);
        EventManager.RemoveHandler(GameEvent.OnCollectKey,OnCollectKey);
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,OnLevelEnd);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
    }

    

    private void Start() 
    {
        noise=cm.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        if(noise == null)
            Debug.LogError("No MultiChannelPerlin on the virtual camera.", this);
        else
            Debug.Log($"Noise Component: {noise}");

    }


    private void OnCollectKey()
    {
        Noise(amplitudeGain,frequencyGain,shakeTime);
    }

    private void OnLevelEnd()
    {
        ChangeFieldOfView(newFieldOfView,1);
    }

    private void OnNextLevel()
    {
        ChangeFieldOfView(oldFieldOfView,1);
    }

    private void OnPlayerGetDamage()
    {

    }

    private void Noise(float amplitudeGain,float frequencyGain,float shakeTime) 
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        StartCoroutine(ResetNoise(shakeTime));    
    }

    private IEnumerator ResetNoise(float duration)
    {
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;    
    }
    public void ChangeFieldOfView(float fieldOfView, float duration = 1)
    {
        DOTween.To(() => cm.m_Lens.FieldOfView, x => cm.m_Lens.FieldOfView = x, fieldOfView, duration);
    }

    

    public void ChangeFieldOfViewHit(float newFieldOfView, float oldFieldOfView, float duration = 1)
    {
        DOTween.To(() => cm.m_Lens.FieldOfView, x => cm.m_Lens.FieldOfView = x, newFieldOfView, duration).OnComplete(()=>{
            DOTween.To(() => cm.m_Lens.FieldOfView, x => cm.m_Lens.FieldOfView = x, oldFieldOfView, duration);
        });
    }

    public void ChangeFollow(Transform Ball)
    {
        cm.m_Follow=Ball;
    }
}
