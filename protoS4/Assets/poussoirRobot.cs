using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poussoirRobot : MonoBehaviour {
    public GameObject rondelle;
    public previson patinoire;
    public float yPos = 4.5f;
    public float xMin = -2.5f;
    public float xMax = 1.8f;
    public float deplacementMax = 0.5f;
    public float degagement = 3;
    public Vector2 v;

    public Transform but1;
    public Transform but2;

    Vector2 previousP;
    // Use this for initialization
    Vector2 posRondelle;
    public Vector2 prediction;
	void Start () {
        previousP = posRondelle;
        posRondelle = rondelle.transform.position;
        transform.position = new Vector2(transform.position.x, yPos);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        posRondelle = rondelle.transform.position;


        Vector3 hitRecu = patinoire.prediction;
        Vector2 hit = new Vector2(hitRecu.x, hitRecu.y);
        float angle1 = Mathf.Atan(Mathf.Abs(hitRecu.z))*Mathf.Rad2Deg * -1;

        if (hitRecu.z > 0)
            angle1 = -180-angle1;

        if (angle1 == 0)
            angle1 = -90;
        // Vector2.SignedAngle(new Vector2(tempXBut, yBUT), pos)
        /*if (hitRecu.z > 0)
            Debug.Log("+");
        else
            Debug.Log("-");*/
        if(hit.x > 3||hit.x < -3)
        {
            hit.x = 0.2f;
        }
        
        
        
        //Debug.Log(Vector2.SignedAngle(previousP, posRondelle));
        //prediction = (posRondelle - previousP) * 1000;//new Vector2(Mathf.Sin((Vector2.Angle(posRondelle, previousP))), Mathf.Cos((Vector2.Angle(posRondelle, previousP)))) + posRondelle;
        //RaycastHit2D hit = Physics2D.Raycast(posRondelle, prediction);
        //Debug.DrawLine(posRondelle, hit.transform.position,Color.red);
        //Debug.Log(hit.point);
        //Debug.DrawLine(posRondelle, hit.point, Color.red);
        
        
        
        /*
        if(hit.point.y>6)//Ligne supérieure
        {
            //Debug.DrawLine(hit.point, new Vector2((hit.point.x - posRondelle.x)+hit.point.x, posRondelle.y),Color.red);
        }
        else if(hit.point.y>1.4f)
        {
            if (hit.point.x > 0)//Ligne verticale droite
            {
                
            }
            else//Ligne verticale gauche
            {
                
            }
        }*/

        //Debug.DrawRay(posRondelle, prediction, Color.green);

        //prevision.SetPosition(0, posRondelle);
        //Debug.Log((posRondelle - previousP)*100);
        //prevision.SetPosition(1,)
        //for(int i = 0; i<10; i++)
        //{
        //    prevision.SetPosition(i + 1, prevision.GetPosition(i));
        //}
        //prevision.SetPosition(0, posRondelle);
        previousP = posRondelle;


        /*if(v.x < 0.1 && v.y < 0.1 && posRondelle.y>degagement && posRondelle.y < transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - deplacementMax);
        }
        */

        /*
        if(transform.position.y != yPos)
        {
            if (Mathf.Abs(transform.position.y - yPos) < deplacementMax)
                transform.position = new Vector2(transform.position.x, yPos);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y + deplacementMax);
        }
        */
        float tempPosX;
        float angle2;
        if(hit.y > 4.3f)//5.7f)
        {
            


            tempPosX = hit.x;
            float anglef =-(Vector2.Angle(transform.position, but1.position));//C'EST L'ANGLE QUI CHIE LOL

            angle2 = (anglef + angle1) / 2;
            Debug.Log(anglef);
            tempPosX = tempPosX-Mathf.Sin((angle2)*Mathf.Deg2Rad)*0.5f;
            Debug.DrawRay(transform.position, new Vector3(Mathf.Cos(angle1 * Mathf.Deg2Rad), Mathf.Sin(angle1 * Mathf.Deg2Rad)), Color.red);
            Debug.DrawRay(transform.position, new Vector3(Mathf.Cos(angle2 * Mathf.Deg2Rad), Mathf.Sin(angle2 * Mathf.Deg2Rad)), Color.blue);
            Debug.DrawRay(transform.position, new Vector3(Mathf.Cos(anglef * Mathf.Deg2Rad), Mathf.Sin(anglef * Mathf.Deg2Rad)), Color.green);
        }
        else
        {
            tempPosX = posRondelle.x;
        }

        //Debug.Log(transform.position.x - tempPosX);

        if(Mathf.Abs(transform.position.x - tempPosX)> deplacementMax)
        {
            if(transform.position.x > tempPosX)
            {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x- deplacementMax, xMin, xMax), yPos);
            }
            else
            {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x + deplacementMax, xMin, xMax), yPos);
            }
        }
        else
            transform.position = new Vector2(Mathf.Clamp(tempPosX, xMin, xMax), yPos);

        
	}
}
