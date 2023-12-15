using UnityEngine;
[CreateAssetMenu(fileName = "TestScriptableObject")]
public class TestUnityEvent : ScriptableObject
{
    public AudioSource _AudioSource;
    public GameObject[] objPrefabs;
    public AudioClip[] audioClips;
    public void PlayAudioClip(int i)
    {
        if (_AudioSource == null)
        {
            GameObject obj = GameObject.Find("Sounds");
            if (obj == null)
            {
                obj = new GameObject("Sounds");
                _AudioSource = obj.AddComponent<AudioSource>();
            }
            else
                _AudioSource = obj.GetComponent<AudioSource>();                
        }
        if (_AudioSource == null)
        {
            Debug.LogError("Can't find audiosource");
            return;
        }
        _AudioSource.clip = audioClips[i];
        _AudioSource.Play();
        
    }

    public void CreatePrefab(int i)
    {
        Instantiate(objPrefabs[i]);
    }
}