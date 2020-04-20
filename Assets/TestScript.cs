using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// documentation : https://github.com/pixlpa/Unity-Synth-Experiments
public class TestScript : MonoBehaviour
{
    bool togglestatus;
    public float noteN;
    public int BPM;

    public int BPM_Subdivision=1;
    int oldBpmStep;
    public int BPMCountEvery;
    pxStrax audioSynt;

    // Start is called before the first frame update
    void Start()
    {
        audioSynt = GetComponent<pxStrax>();


    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;
        float bpmstep = (60f / (BPM * BPM_Subdivision));

        int currentbpmstep = (int)Mathf.Floor(currentTime / bpmstep);
        if (oldBpmStep != currentbpmstep)
        {
            PlayNote(currentbpmstep % BPMCountEvery );

            oldBpmStep = currentbpmstep;
        }

    }
    public void PlayNote(int note)
    {
        audioSynt.KeyOn(noteN+note*10);
    }
    [Button]
    void TogglePlay()
    {
        
        audioSynt.KeyOn(noteN);
    }

}
