using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class CodeInputManager : MonoBehaviour
{
    public TMP_InputField inputField;  // Input field for code input
    public TMP_InputField outputField; // Output field
    public TMP_InputField log;         // Log for error messages
    public bool loopValidation;

    private string apiKey = "e5e6ec34-6f00-473e-b2fb-4c0782d7ffcf";
    private string apiUrl = "https://rextester.com/rundotnet/api";

    [TextArea(5, 100)]
    public string input;
    [TextArea(5, 100)]
    public string output;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.text = "#include <stdio.h>\r\n\r\nint main() {\r\n\r\n\tprintf(\"Hello World\");\r\n\r\n\treturn 0;\r\n}";
    }

    // Update is called once per frame
    void Update()
    {
        input = inputField.text;


    }

    // Method to be called when the user clicks the "Compile" button
    public void CompileCode()
    {
        if (!string.IsNullOrWhiteSpace(input))
            StartCoroutine(SendCodeToAPI(input));
    }

    // Coroutine to send C code to RexTester API
    IEnumerator SendCodeToAPI(string code)
    {
        // Escape double quotes in the JSON data
        string jsonData = "{\"LanguageChoice\":\"7\",\"Program\":\"" + EscapeJsonString(code) + "\",\"Input\":\"\",\"CompilerArgs\":\"source_file.cpp -o a.out\",\"ApiKey\":\"" + apiKey + "\"}";

        // Convert jsonData string into a byte array
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

        // Create UnityWebRequest using POST method
        UnityWebRequest www = new UnityWebRequest(apiUrl, "POST");
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        // Wait for the response
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            // Change output from web to CompilerOutput class
            string jsonOutput = www.downloadHandler.text;
            CompilerOutput cOutput = new CompilerOutput();
            cOutput = JsonUtility.FromJson<CompilerOutput>(jsonOutput);

            //Debug.Log(cOutput.Result);
            //Debug.Log(cOutput.Errors);

            if (cOutput.Errors == "")
            {
                //Debug.Log("jalans");

                output = cOutput.Result;
                outputField.text = output;
                log.text = "Code executed successfully with no errors!";
            
            } else
                log.text = cOutput.Errors;
        }
        else
        {
            // Handle errors
            output = "Error: " + www.error;
        }
    }

    // Method to escape special characters in code input to prevent JSON errors
    private string EscapeJsonString(string str)
    {
        return str.Replace("\\", "\\\\")  // Escape backslashes
                  .Replace("\"", "\\\"")  // Escape double quotes
                  .Replace("\n", "\\n")   // Escape newlines
                  .Replace("\r", "\\r");  // Escape carriage returns
    }

    [System.Serializable]
    public class CompilerOutput
    {
        public string Warnings;
        public string Errors;
        public string Result;
        public string Stats;
        public string[] Files;
        public bool NotLoggedIn;
    }
}
