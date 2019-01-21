using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Unity.Editor;


    public class User//clase usuario para el registro de datos 
    {
        public string nombre;
        public string email;
        public string mensage;
        public string version;
        public string machine;
        public string code = "";

        public User()
        {

        }

        public User(string nombre_, string email_,string mensage_)//funcion actualizar el mensage
        {
            this.nombre = nombre_;
            this.email = email_;
            this.mensage = mensage_;
            this.version = "modelo:_" + SystemInfo.deviceModel;
            this.version = version.Replace(" ", "");
            this.machine = "_sistema_operativo:_" + SystemInfo.operatingSystem;
            this.version = version.Replace(" ", "");
        }
    }

public class AppList
{
    public string App;
    public string version;
    public string machine;
    public string User;

    public AppList()
    {

    }

    public AppList(string Name,string User)
    {
        this.App = Name;
        this.App = App.Replace("com.educar.", "");
        this.version = "modelo:_" + SystemInfo.deviceModel;
        this.version = version.Replace(" ", "");
        this.machine = "_sistema_operativo:_" + SystemInfo.operatingSystem;
        this.version = version.Replace(" ", "");
        this.User = User;
    }
}

public class firebase : MonoBehaviour {
    DatabaseReference reference;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    int longi = 11;
    string id="";
    string[] posibles = new string[] {"0","1","2","3","4","5","6","7","8","9",
                    "a","b","c","d","e","f","g","h","i","j",
                    "k","l","m","n","o","p","q","r","s","t",
                    "u","v","w","x","y","z"};//variables del codigo a asignar por aplicacion

    void Start()
    {

        if (PlayerPrefs.HasKey("Id"))//ver si existe la variable id guardada en el celular
        {

        }
        else
        {
            Code();//Generar codigo
        }
        dependencyStatus = FirebaseApp.CheckDependencies();
        if (dependencyStatus != DependencyStatus.Available)
        {
            FirebaseApp.FixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = FirebaseApp.CheckDependencies();
                if (dependencyStatus == DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }
        else
        {
            InitializeFirebase();
        }
        
        // Set these values before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://directorio-5030a.firebaseio.com/");
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseAnalytics.LogEvent("begin_app", "percent", 1);
    }

    public void Code()//Generar elc codigo para el ID
    {
        string code = "";
        for (int i = 0; i < longi; i++)
        {
            code = code + posibles[Random.Range(0, posibles.Length-1)];
        }
        PlayerPrefs.SetString("Id",code);
    }

    public string Code_sim()//Generar codigo para identificar distintos mensages que el usuario puede mandar
    {
        string code = "";
        for (int i = 0; i < longi; i++)
        {
            code = code + posibles[Random.Range(0, posibles.Length - 1)];
        }
        return code;
    }

    public void AppVista(string userId, string Name)//enviar datos del una vez se descargen aplicaciones
    {
        AppList app = new AppList(Name, userId);
        string json = JsonUtility.ToJson(app);
        reference.Child("aplicacion").Child(Name).SetRawJsonValueAsync(json);
    }

    public void Contacto(string userId, string nombre, string email, string mensage)//enviar los datos convirtiendo la clase a un dato json
    {
        User user = new User(nombre, email, mensage);
        user.code = PlayerPrefs.GetString("Id");
        string json = JsonUtility.ToJson(user);
        reference.Child("user").Child(PlayerPrefs.GetString("Id")+ "/"+ Code_sim()).SetRawJsonValueAsync(json);
    }

    // Handle initialization of the necessary firebase modules:
    void InitializeFirebase()
    {
        DebugLog("Enabling data collection.");
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        DebugLog("Set user properties.");
        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty(
          FirebaseAnalytics.UserPropertySignUpMethod,
          "Google");
        // Set the user ID.
        FirebaseAnalytics.SetUserId("uber_user_510");
    }

    public void AnalyticsLogin()
    {
        // Log an event with no parameters.
        DebugLog("Logging a login event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
    }

    // Output text to the debug log text field, as well as the console.
    public void DebugLog(string s)
    {
        print(s);
    }
}
