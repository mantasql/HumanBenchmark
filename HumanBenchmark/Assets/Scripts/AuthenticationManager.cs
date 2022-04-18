using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase;
using Firebase.Auth;

public class AuthenticationManager : MonoBehaviour
{
    public static string signedInEmail;

    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    public GameObject signInPanel;
    public TMP_InputField signInEmail;
    public TMP_InputField signInPassword;

    public GameObject signUpPanel;
    public TMP_InputField signUpEmail;
    public TMP_InputField signUpPassword;
    public TMP_InputField signUpConfirmPassword;
    
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        auth.SignOut();
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool isSignedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!isSignedIn && user != null)
            {
                Debug.Log(user.Email + " signed out");
            }

            user = auth.CurrentUser;

            if (isSignedIn)
            {
                Debug.Log(user.Email + " signed in");
            }
        }
    }

    public void SignIn()
    {
        StartCoroutine(SignInAsync(signInEmail.text, signInPassword.text));
    }

    public void SignUp()
    {
        StartCoroutine(SignUpAsync(signUpEmail.text, signUpPassword.text, signUpConfirmPassword.text));
    }

    IEnumerator SignInAsync(string email, string password)
    {
        var signInTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => signInTask.IsCompleted);

        if (signInTask.Exception == null)
        {
            user = signInTask.Result;
            signedInEmail = user.Email;
            Debug.Log(user.Email + " signed in");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.LogError(signInTask.Exception);
            FirebaseException firebaseException = signInTask.Exception.GetBaseException() as FirebaseException;
            AuthError authError = (AuthError) firebaseException.ErrorCode;
            Debug.Log("Could not sign in: " + authError.ToString());
        }
    }

    IEnumerator SignUpAsync(string email, string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            Debug.LogError("Email musn't be empty");
        }
        else if (string.IsNullOrWhiteSpace(password))
        {
            Debug.LogError("Password musn't be empty");
        }
        else if (!password.Equals(confirmPassword))
        {
            Debug.LogError("Passwords must match");
        }
        else
        {
            var signUpTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            yield return new WaitUntil(() => signUpTask.IsCompleted);

            if (signUpTask.Exception == null)
            {
                user = signUpTask.Result;
                signedInEmail = user.Email;
                Debug.Log(user.Email + " signed up");
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.LogError(signUpTask.Exception);
                FirebaseException firebaseException = signUpTask.Exception.GetBaseException() as FirebaseException;
                AuthError authError = (AuthError) firebaseException.ErrorCode;
                Debug.Log("Could not sign up: " + authError.ToString());
            }
        }
    }

    public void OpenSignUp()
    {
        signInPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    public void OpenSignIn()
    {
        signUpPanel.SetActive(false);
        signInPanel.SetActive(true);
    }

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve Firebase dependencies: " + dependencyStatus);
            }
        });
    }
}
