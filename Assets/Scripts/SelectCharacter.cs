using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;
    private int[] positions = new int[6];
    private int contP1;
    private int contP2;
    public ActivateSelectionChar activateSelectionChar;

    public GameObject ready1;
    public GameObject ready2;
    private bool isReady1;
    private bool isReady2;
    // Start is called before the first frame update
    void Start()
    {
        contP1 = 0;
        contP2 = 1;
        positions[0] = 1;
        positions[1] = 2;
        LeanTween.moveLocalX(P2, 12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            contP1 = moveRight(P1, contP1, 1);
            activateSelectionChar.activeCharacter(contP1, 1);
            isReady1 = false;
            ready1.SetActive(false);
            activateSelectionChar.isReady(false, 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            contP1 = moveLeft(P1, contP1, 1);
            activateSelectionChar.activeCharacter(contP1, 1);
            isReady1 = false;
            ready1.SetActive(false);
            activateSelectionChar.isReady(false, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            contP2 = moveRight(P2, contP2, 2);
            activateSelectionChar.activeCharacter(contP2, 2);
            isReady2 = false;
            ready2.SetActive(false);
            activateSelectionChar.isReady(false, 2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            contP2 = moveLeft(P2, contP2, 2);
            activateSelectionChar.activeCharacter(contP2, 2);
            isReady2 = false;
            ready2.SetActive(false);
            activateSelectionChar.isReady(false, 2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isReady1)
                activateSelectionChar.startGame();
            else
            {
                activateSelectionChar.isReady(true, 1);
                ready1.SetActive(true);
                isReady1 = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isReady2)
                activateSelectionChar.startGame();
            else
            {
                activateSelectionChar.isReady(true, 2);
                ready2.SetActive(true);
                isReady2 = true;
            }
        }
    }

    private int moveRight(GameObject P, int contP, int value)
    {
        clearValues(value);
        int from = contP;
        contP++;
        if (contP > 5)
            contP--;
        if (positions[contP] == ((value == 1) ? 2 : 1))
            contP++;
            if (contP > 5)
                contP -= 2;
        positions[contP] = value;
        moveX(P, contP);
        if ((from < 3) & (contP > 2))
            moveY(P, contP);
        return contP;
    }

    private int moveLeft(GameObject P, int contP, int value)
    {
        clearValues(value);
        int from = contP;
        contP--;
        if (contP < 0)
            contP++;
        if (positions[contP] == ((value == 1) ? 2 : 1))
            contP--;
            if (contP < 0)
                contP += 2;
        positions[contP] = value;
        moveX(P, contP);
        if ((from > 2) & (contP < 3))
            moveY(P, contP);
        return contP;
    }

    public void moveX(GameObject P, int contP)
    {
        LeanTween.moveLocalX(P, 12 * ((contP > 2) ? (contP-3) : contP), 0.3f);
    }

    public void moveY(GameObject P, int contP)
    {
        LeanTween.moveLocalY(P, -11 * ((contP > 2) ? 1 : 0), 0.3f);
    }

    private void clearValues(int value)
    {
        for (int i = 0; i < 6; i++)
        {
            if (positions[i] == value)
                positions[i] = 0;
        }
    }

}
