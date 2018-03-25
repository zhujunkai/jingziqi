using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBeh : MonoBehaviour {
	private void Awake()
	{
		Debug.Log("Init Awake");
	}
	// Use this for initialization
	void Start () {
		Debug.Log("Init Start");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Init Update");
	}

	private string []t_buttom=new string[9];
	private int user_now = 1;
	private string []user_icon = {"","o","x" };
	private int [][] chessboard= new int[3][] { new int[3], new int[3], new int[3] };
	private string message = "Turn:   user1";
	private string t_start = "Restart";
	private int count = 0;
	private bool checkwin(int x,int y)
	{
		if (chessboard[x][0] == chessboard[x][1] && chessboard[x][0] == chessboard[x][2]) return true;
		else if (chessboard[0][y] == chessboard[1][y] && chessboard[0][y] == chessboard[2][y]) return true;
		else if (chessboard[0][0] !=0&&chessboard[0][0] == chessboard[2][2] && chessboard[0][0] == chessboard[1][1]) return true;
		else if (chessboard[2][0] != 0&&chessboard[2][0] == chessboard[1][1] && chessboard[2][0] == chessboard[0][2]) return true;
		else return false;
	}
	private void usercheck(int x, int y)
	{
		if (chessboard[x][y] == 0 && user_now != 0)
		{
			t_buttom[x + y * 3] = user_icon[user_now];
			chessboard[x][y] = user_now;
			count++;
			if (checkwin(x, y))
			{
				message = user_icon[user_now] + "   win";
				user_now = 0;
			}
			else if(count==9)
			{
				message = "draw";
				user_now = 0;
			}
			else
			{
				user_now = 3 - user_now;
				message= "Turn:   user"+user_now;
			}
		}
	}
	private void chess_AI()
	{

	}
	private void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 140, 220), "井字棋");
		GUI.Label(new Rect(30, 40, 120, 20), message);
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		for(int x = 0; x< 3; x++)
		{
			for(int y = 0; y < 3; y++)
			{
				if (GUI.Button(new Rect(20+40*x, 60+40*y, 40, 40), t_buttom[x+y*3]))
				{
					usercheck(x,y);
				}
			}
		}
		if (GUI.Button(new Rect(40, 200, 80, 20), t_start))
		{
			message = "";
			user_now = 1;
			count = 0;
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					chessboard[x][y] = 0;
					t_buttom[x+y*3] = "";
				}
			}
		}
	}
}
