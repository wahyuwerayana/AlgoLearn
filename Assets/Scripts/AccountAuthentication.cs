using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountAuthentication : MonoBehaviour
{
    public TMP_InputField usernameRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField usernameSignInField;
    public TMP_InputField passwordSignInField;
    public AuthManager authManager;

    public async void OnRegisterButtonClicked(){
        string username = usernameRegisterField.text;
        string password = passwordRegisterField.text;
        await authManager.SignUpWithUsernamePasswordAsync(username, password);
    }

    public async void OnSignInButtonClicked(){
        string username = usernameSignInField.text;
        string password = passwordSignInField.text;
        await authManager.SignInWithUsernamePasswordAsync(username, password);
    }
}
