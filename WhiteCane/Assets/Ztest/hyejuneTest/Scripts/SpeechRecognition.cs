using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HuggingFace.API;
using HuggingFace.API.Examples;
using System.Text.RegularExpressions;
using UnityEngine.InputSystem;


public class SpeechRecognition : MonoBehaviour
{

    [SerializeField]
    private InputActionReference recordButton;


    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private TMP_Text text;

    [SerializeField] private GameObject micImage;

    private string recognizeResponse;
    private bool isResponseFirst = true;

    private AudioClip clip;
    private byte[] bytes;
    private bool recording;

    private void Start()
    {
        stopButton.interactable = false;
    }

    //public void RecognizeButton()
    //{
    //    selectState = skipButton.action.ReadValue<float>();

    //    if (selectState == 0)
    //    {
    //        isActive = true;
    //    }
    //    else
    //    {
    //        if (isActive)
    //        {
    //            SkipButton();
    //            isActive = false;
    //        }
    //    }
    //}


    private void Update()
    {
        if (recording && Microphone.GetPosition(null) >= clip.samples)
        {
            StopRecording();
        }
    }

    public void StartRecording()
    {
        isResponseFirst = true;
        text.color = Color.white;
        text.text = "Recording...";

        micImage.gameObject.SetActive(true);

        startButton.interactable = false;
        stopButton.interactable = true;
        clip = Microphone.Start(null, false, 10, 44100);
        recording = true;
    }

    public void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        recording = false;
        SendRecording();


    }

    private void SendRecording()
    {
        text.color = Color.yellow;
        text.text = "Sending...";

        micImage.gameObject.SetActive(true);

        stopButton.interactable = false;

        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            text.color = Color.white;
            text.text = response;
            micImage.gameObject.SetActive(false);


            if (isResponseFirst)
            {
                recognizeResponse = response.Trim();//공백제거

                string pattern = "[^a-zA-Z0-9 ]";
                recognizeResponse = Regex.Replace(recognizeResponse, pattern, "");
                recognizeResponse = recognizeResponse.ToLower();
                SendRocorginzeText();
                Debug.Log(recognizeResponse + "음성인식");


                Debug.Log("퀴즈활성화//맞으면");

                MainSystem.Instance.ObjectManager.quizAcitve = true;
            }
           
         

            startButton.interactable = true;
        }, error => {
            text.color = Color.red;
            text.text = error;
            startButton.interactable = true;
        });
    }

   
    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }

    public string SendRocorginzeText()
    {
        isResponseFirst = false;
        MainSystem.Instance.DataManager.QuizData.QuizDataController.currentquizObject.CheckAnswer(recognizeResponse);

        Debug.Log("음성인식 데이터 보내야함");
        return recognizeResponse;
    }
}
