using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayAudio : MonoBehaviour {

    void Start()
    {
        print("starting GetAudioClip()");
        StartCoroutine(GetAudioClip());
    }

    IEnumerator GetAudioClip()
    {

        // Song1 - https://raw.githubusercontent.com/jsambuo/TestAudioLagIssue/master/10min.ogg (6.32MB)
        // Song2 - https://raw.githubusercontent.com/jsambuo/TestAudioLagIssue/master/30min.ogg (18.9MB)
        // Song3 - https://raw.githubusercontent.com/jsambuo/TestAudioLagIssue/master/60min.ogg (37.9MB)
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://raw.githubusercontent.com/jsambuo/TestAudioLagIssue/master/60min.ogg", AudioType.OGGVORBIS))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                print("before getting content");
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                print("after getting content");
                print(myClip);
            }
        }
    }
}
