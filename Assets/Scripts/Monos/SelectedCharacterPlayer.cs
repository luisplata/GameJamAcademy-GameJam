using UnityEngine;
public class SelectedCharacterPlayer : MonoBehaviour
{
    [SerializeField] private Animator ani;
    private bool isFinishAnimation;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        if (isFinishAnimation)
        {
            ani.SetTrigger("power");
        }
    }

    public void FinishAnimation()
    {
        isFinishAnimation = true;
    }
}
