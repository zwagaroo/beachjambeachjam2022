using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class MusicPlayer : MonoBehaviour
{
    
    public List<string> BGMList;
    public string nextUp;
    public List<string> alreadyPlayed;
    public AudioManager am;
    public bool BossLevel;
    // Start is called before the first frame update
    
    void Start()
    {

        am = FindObjectOfType<AudioManager>();
        if(!BossLevel)
        {
            var rand = UnityEngine.Random.Range(1,3);
        
            if(rand == 1){
                nextUp = "Onwards";
            }
            else if (rand == 2){
                nextUp = "Theme";
            }
        }

        else{
            nextUp = "TheFireAndTheSea";
        }

        StartCoroutine(CheckBGM());
    }

    // Update is called once per frame

        IEnumerator CheckBGM()
        {
            for (; ; )
            {
                PlayBGM();
                yield return new WaitForSeconds(1f);
            }
        }

        void PlayBGM()
        {       
            foreach (string name in BGMList)
            {
                if (Array.Find(am.GetComponent<AudioManager>().sounds, sound => sound.name == name).source.isPlaying == true) { print("hello"); return; }
            }

            am.GetComponent<AudioManager>().Play(nextUp);
            alreadyPlayed.Add(nextUp);
            nextUp = null;

            foreach (string name in BGMList)
            {
                if (alreadyPlayed.FirstOrDefault(x => x == name) == null)
                {
                    nextUp = name;
                    break;
                }
            }

            if (nextUp == null)
            {
                alreadyPlayed.Clear();
                nextUp = BGMList[0];
            }

    }
}
