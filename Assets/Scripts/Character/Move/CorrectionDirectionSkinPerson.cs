using UnityEngine;

public class CorrectionDirectionSkinPerson : MonoBehaviour
{
    [SerializeField] private Transform personSkin;
    private Quaternion resetRotate; 
    public void SetNewDirectionSkin(Vector3 InputAxis, bool isKeyDown)
    {
        if (isKeyDown) //если нажата кнопка R экипировать лук
        {
            float horizontal = InputAxis.x < 0 ? 130 : -45;
            float vertical = InputAxis.z < 0 ? -130 : 45;
            float rotateY = InputAxis.x > InputAxis.z ?
                (InputAxis.z < 0 ? vertical : horizontal) : (InputAxis.x < 0 ? horizontal : vertical);
            personSkin.localRotation = Quaternion.Euler(0f, rotateY, 0f);  
        }
        else 
        { 
            if(InputAxis.z !=0)
                personSkin.localRotation = resetRotate;
            else
            {
                float horizontal = InputAxis.x < 0 ? 20 : -20;
                personSkin.localRotation = Quaternion.Euler(0f, horizontal, 0f);
            }
        }
    }
}
