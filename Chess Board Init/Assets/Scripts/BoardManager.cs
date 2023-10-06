using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //set 2d board array
    private int[,] board;

    //set numbers to pieces
    enum Pieces
    {
        BLACK_KING,
        BLACK_QUEEN,
        BLACK_BISHOP,
        BLACK_KNIGHT,
        BLACK_ROOK,
        BLACK_PAWN,
        WHITE_KING,
        WHITE_QUEEN,
        WHITE_BISHOP,
        WHITE_KNIGHT,
        WHITE_ROOK,
        WHITE_PAWN
    }

    // Start is called before the first frame update
    void Start()
    {
        board = new int[8, 8]; //set board size
        InitializeBoard(); //set board spaces
        PopulateBoard(); //populate board spaces w nums
        PrintBoard(); //prints board values 
        FillBoard(); //fills board with prefabs
    }

    void FillBoard()
    {
        //for loop to set prefabs to their locations
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                //if loop to set every location on board with prefab
                if (board[x, y] > -1)
                {
                    Vector3 pos = new Vector3(x * 1.1142857f, 0, y * 1.1142857f); //calculation for exact locations
                    string name = GetPrefabName(board[x, y]); //string to getprefabname
                    Instantiate(Resources.Load(name), pos, Quaternion.identity); //instantiate prefab by name
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //print places
    void PrintBoard()
    {
        string s = "";
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                s += board[x, y] + "|";
            }

            s += "\n";

        }

        Debug.Log(s);

    }

    void InitializeBoard()
    {
        //for loop to set each space to -1
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                board[x, y] = -1;
            }

        }

    }

    void PopulateBoard()
    {
        //for loop to set white pawn values
        for (int i = 0; i < 8; i++)
        {
            board[1, i] = (int)Pieces.WHITE_PAWN;
        }

        //for loop to set black pawn values
        for (int i = 0; i < 8; i++)
        {
            board[6, i] = (int)Pieces.BLACK_PAWN;
        }

        //set values to all white non-pawn pieces
        board[0, 0] = (int)Pieces.WHITE_ROOK;
        board[0, 7] = (int)Pieces.WHITE_ROOK;
        board[0, 1] = (int)Pieces.WHITE_KNIGHT;
        board[0, 6] = (int)Pieces.WHITE_KNIGHT;
        board[0, 2] = (int)Pieces.WHITE_BISHOP;
        board[0, 5] = (int)Pieces.WHITE_BISHOP;
        board[0, 3] = (int)Pieces.WHITE_QUEEN;
        board[0, 4] = (int)Pieces.WHITE_KING;

        //set values to all black non-pawn pieces
        board[7, 0] = (int)Pieces.BLACK_ROOK;
        board[7, 7] = (int)Pieces.BLACK_ROOK;
        board[7, 1] = (int)Pieces.BLACK_KNIGHT;
        board[7, 6] = (int)Pieces.BLACK_KNIGHT;
        board[7, 2] = (int)Pieces.BLACK_BISHOP;
        board[7, 5] = (int)Pieces.BLACK_BISHOP;
        board[7, 3] = (int)Pieces.BLACK_QUEEN;
        board[7, 4] = (int)Pieces.BLACK_KING;
    }

    string GetPrefabName(int enumNumber)
    {
        switch (enumNumber)
        {
            case (int)Pieces.BLACK_KING: return "bKing"; break;
            case (int)Pieces.BLACK_QUEEN: return "bQueen"; break;
            case (int)Pieces.BLACK_BISHOP: return "bBishop"; break;
            case (int)Pieces.BLACK_KNIGHT: return "bKnight"; break;
            case (int)Pieces.BLACK_ROOK: return "bRook"; break;
            case (int)Pieces.BLACK_PAWN: return "bPawn"; break;
            case (int)Pieces.WHITE_KING: return "wKing"; break;
            case (int)Pieces.WHITE_QUEEN: return "wQueen"; break;
            case (int)Pieces.WHITE_BISHOP: return "wBishop"; break;
            case (int)Pieces.WHITE_KNIGHT: return "wKnight"; break;
            case (int)Pieces.WHITE_ROOK: return "wRook"; break;
            case (int)Pieces.WHITE_PAWN: return "wPawn"; break;
        }
        return "";
    }

}
