using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.IO;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "Level01";
    //public string url;

    [SerializeField]
    public SceneFader scenefader;

    public GameObject overlayCanvas;
    public GameObject optionMenu;
    public GameObject imageLoadedCanvas;
    public GameObject helpPanel;

    public universalContainer universalContainer;

    public Text imageLoadedText;

    //public InputField inputfield;

	public void Play()
    {
        scenefader.FadeTo(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    public void Option()
    {
        optionMenu.SetActive(true);
        overlayCanvas.SetActive(false);
    }
    /*public void Insert()
    {

        universalContainer.instance.ChangeUrl(inputfield.text);
        Debug.Log(universalContainer.instance.Url);
    }*/
    public void Return()
    {
        overlayCanvas.SetActive(true);
        optionMenu.SetActive(false);
        if (helpPanel.activeInHierarchy == true)
        {
            helpPanel.SetActive(false);
        }
    }
    public void Help()
    {
        helpPanel.SetActive(true);
    }
    public void Browse()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));

        // Set default filter that is selected when the dialog is shown (optional)
        // Returns true if the default filter is set successfully
        // In this case, set Images filter as the default filter
        FileBrowser.SetDefaultFilter(".jpg");

        // Set excluded file extensions (optional) (by default, .lnk and .tmp extensions are excluded)
        // Note that when you use this function, .lnk and .tmp extensions will no longer be
        // excluded unless you explicitly add them as parameters to the function
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

        // Add a new quick link to the browser (optional) (returns true if quick link is added successfully)
        // It is sufficient to add a quick link just once
        // Name: Users
        // Path: C:\Users
        // Icon: default (folder icon)
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        // Show a save file dialog 
        // onSuccess event: not registered (which means this dialog is pretty useless)
        // onCancel event: not registered
        // Save file/folder: file, Initial path: "C:\", Title: "Save As", submit button text: "Save"
        // FileBrowser.ShowSaveDialog( null, null, false, "C:\\", "Save As", "Save" );

        // Show a select folder dialog 
        // onSuccess event: print the selected folder's path
        // onCancel event: print "Canceled"
        // Load file/folder: folder, Initial path: default (Documents), Title: "Select Folder", submit button text: "Select"
        // FileBrowser.ShowLoadDialog( (path) => { Debug.Log( "Selected: " + path ); }, 
        //                                () => { Debug.Log( "Canceled" ); }, 
        //                                true, null, "Select Folder", "Select" );

        // Coroutine example
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Initial path: default (Documents), Title: "Load File", submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(false, null, "Load File", "Load");

        // Dialog is closed
        // Print whether a file is chosen (FileBrowser.Success)
        // and the path to the selected file (FileBrowser.Result) (null, if FileBrowser.Success is false)
        Debug.Log(FileBrowser.Success + " " + FileBrowser.Result);
        universalContainer.ChangeUrl(FileBrowser.Result);
        Debug.Log("file changed");
        if (File.Exists(FileBrowser.Result))
        {
            StartCoroutine(SuccessPopup());
        }
        else
        {
            StartCoroutine(FailedPopup());
        }
    }
    IEnumerator SuccessPopup()
    {
        imageLoadedCanvas.SetActive(true);
        imageLoadedText.text = "Image Successfully Loaded";
        yield return new WaitForSeconds(2f);
        imageLoadedCanvas.SetActive(false);
    }
    IEnumerator FailedPopup()
    {
        imageLoadedCanvas.SetActive(true);
        imageLoadedText.text = "Image Failed To Load";
        yield return new WaitForSeconds(2f);
        imageLoadedCanvas.SetActive(false);
    }
}
