using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
   async void Start(){
      await UnityServices.InitializeAsync();
   }

   public async Task SignUpWithUsernamePasswordAsync(string username, string password){
      try
      {
         await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);

         Debug.Log("SignUp successful");
         SceneManager.LoadScene(1);
      }
      catch (AuthenticationException ex)
      {
         Debug.LogException(ex);
      }
      catch (RequestFailedException ex)
      {
         Debug.LogException(ex);
      }
    }

   public async Task SignInWithUsernamePasswordAsync(string username, string password){
      try
      {
         await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
         Debug.Log("SignIn successful");
         SceneManager.LoadScene(1);
      }
      catch (AuthenticationException ex)
      {
         Debug.LogException(ex);
      }
      catch (RequestFailedException ex)
      {
         Debug.LogException(ex);
      }
   }
}
