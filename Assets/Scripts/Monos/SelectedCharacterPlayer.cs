using UnityEngine;
public class SelectedCharacterPlayer : MonoBehaviour
{
    [SerializeField] private Animator ani;
    private bool isFinishAnimation = true;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        if (isFinishAnimation)
        {
            isFinishAnimation = false;
            print("hola");
            ani.SetTrigger("dance");
        }
    }

    public void FinishAnimation()
    {
        isFinishAnimation = true;
    }
}
