using UnityEngine;

public class LibraryTask : MonoBehaviour
{
    public static int booksCollected = 0; // Static to keep track across all books
    private bool isGrabbed = false;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void GrabBook()
    {
        isGrabbed = true;
    }

    public void ReleaseBook()
    {
        isGrabbed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGrabbed && other.CompareTag("Player"))
        {
            CollectBook();
        }
    }

    private void CollectBook()
    {
        gameObject.SetActive(false);
        booksCollected++;
        Debug.Log("Book collected: " + booksCollected);

        // Assuming you have 3 books
        if (booksCollected == 3)
        {
            CompleteTask();
        }
    }

    private void CompleteTask()
    {
        // Ensure that SceneNavigation is attached to a GameObject in the scene
        SceneNavigation sceneNavigation = FindObjectOfType<SceneNavigation>();
        if (sceneNavigation != null)
        {
            sceneNavigation.LoadScene("ScienceLabScene");
        }
        else
        {
            Debug.LogError("SceneNavigation not found in the scene.");
        }
    }
}
