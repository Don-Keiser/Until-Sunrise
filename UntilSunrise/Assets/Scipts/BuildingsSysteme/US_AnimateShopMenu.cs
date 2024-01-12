using UnityEngine;

public class US_AnimateShopMenu : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenCloseMenu()
    {
        if (isOpen)
        {
            isOpen = false;
            animator.SetTrigger("Close");
        }
        else if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Open");
        }
    }
}
