using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class VoicePower : MonoBehaviour {

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public GameObject Effect;

    void Start()
    {
        actions.Add("system call enhance armament", Enhance);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start(); 
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Enhance()
    {
        GameObject Sphere = Instantiate(Effect, transform) as GameObject;
       
        Rigidbody rb = Sphere.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20;

    }
}
