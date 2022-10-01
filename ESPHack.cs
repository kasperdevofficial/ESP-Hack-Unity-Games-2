using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000343 RID: 835
public class ESPHack : MonoBehaviour
{
	// Token: 0x060014B5 RID: 5301
	public void OnGUI()
	{
		if (this.Esp)
		{
			this.ESP();
		}
	}

	// Token: 0x060014B6 RID: 5302
	public ESPHack()
	{
		ESPHack.LineMaterial.hideFlags = HideFlags.HideAndDontSave;
		ESPHack.LineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
	}

	// Token: 0x060014B7 RID: 5303
	private void ESP()
	{
		if (this.gameObjects == null)
		{
			return;
		}
		for (int i = 0; i < this.gameObjects.Count; i++)
		{
			ESPHack.enemy enemy = this.gameObjects[i];
			if (enemy.gameObject != null)
			{
				Vector3 position = enemy.gameObject.transform.position;
				Vector3 vector = Camera.main.WorldToScreenPoint(position);
				if (vector.z >= 1f)
				{
					Vector3 position2 = position;
					position2.y += 0.7f + enemy.hight;
					Vector3 vector2 = Camera.main.WorldToScreenPoint(position2);
					float num = Math.Abs(vector2.y - vector.y) * (enemy.size / enemy.hight);
					float num2 = num * 0.6f;
					Rect rect = new Rect(vector2.x - num2 / 2f, (float)Screen.height - vector2.y, num2, num);
					position2.y -= 0.1f;
					Vector3 vector3 = Camera.main.WorldToScreenPoint(position2);
					float num3 = Math.Abs(vector3.y - vector.y) * (enemy.size / enemy.hight);
					float num4 = num3 * 0.6f;
					Rect rect2 = new Rect(vector3.x - num4 / 2f, (float)Screen.height - vector3.y, num4, num3);
					if (this.EspName)
					{
						ESPHack.DrawText(enemy.name, rect2.x + rect2.width / 2f, rect2.y, enemy.clr, num3 * 0.07f);
					}
					if (this.EspBox)
					{
						ESPHack.DrawRectangle(rect, enemy.clr, 1.5f);
					}
					if (this.EspLine)
					{
						ESPHack.DrawLine(new Vector3((float)Screen.width / 2f, (float)Screen.height / 1000f), new Vector3(rect.x + rect.width / 2f, rect.y), enemy.clr, 1.5f);
					}
				}
			}
			else
			{
				this.removeEnemyGivenObject(enemy.gameObject);
			}
		}
	}

	// Token: 0x060014B8 RID: 5304
	static ESPHack()
	{
	}

	// Token: 0x060014B9 RID: 5305
	public bool isEnemyPresent(GameObject gameObject)
	{
		using (List<ESPHack.enemy>.Enumerator enumerator = this.gameObjects.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.gameObject == gameObject)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060014BA RID: 5306
	public void tryAddEnemy(GameObject gameObject, string name, Color clr, float hight, float size)
	{
		if (this.isEnemyPresent(gameObject))
		{
			return;
		}
		ESPHack.enemy enemy = new ESPHack.enemy();
		enemy.gameObject = gameObject;
		enemy.name = name;
		enemy.clr = clr;
		enemy.hight = hight;
		enemy.size = size;
		this.gameObjects.Add(enemy);
	}

	// Token: 0x060014BB RID: 5307
	public void removeEnemyGivenObject(GameObject gameObject)
	{
		foreach (ESPHack.enemy enemy in this.gameObjects)
		{
			if (enemy.gameObject == gameObject)
			{
				this.gameObjects.Remove(enemy);
				break;
			}
		}
	}

	// Token: 0x060014BC RID: 5308
	public static void DrawLine(Vector3 start, Vector3 end, Color color, float thickness)
	{
		ESPHack.LineMaterial.SetPass(0);
		if (thickness == 0f)
		{
			return;
		}
		if (thickness == 1f)
		{
			GL.Begin(1);
			GL.Color(color);
			GL.Vertex3(start.x, start.y, start.z);
			GL.Vertex3(end.x, end.y, end.z);
			GL.End();
			return;
		}
		thickness /= 2f;
		GL.Begin(7);
		GL.Color(color);
		GL.Vertex3(start.x - thickness, start.y - thickness, start.z - thickness);
		GL.Vertex3(start.x + thickness, start.y + thickness, start.z + thickness);
		GL.Vertex3(end.x + thickness, end.y + thickness, end.z + thickness);
		GL.Vertex3(end.x - thickness, end.y - thickness, end.z - thickness);
		GL.End();
	}

	// Token: 0x060014BD RID: 5309
	public static void DrawRectangle(Rect rect, Color color, float thickness)
	{
		Vector3 vector = new Vector3(rect.x, rect.y, 0f);
		Vector3 vector2 = new Vector3(rect.x + rect.width, rect.y, 0f);
		Vector3 vector3 = new Vector3(rect.x + rect.width, rect.y + rect.height, 0f);
		Vector3 vector4 = new Vector3(rect.x, rect.y + rect.height, 0f);
		ESPHack.DrawLine(vector, vector2, color, thickness);
		ESPHack.DrawLine(vector2, vector3, color, thickness);
		ESPHack.DrawLine(vector3, vector4, color, thickness);
		ESPHack.DrawLine(vector4, vector, color, thickness);
	}

	// Token: 0x060014BE RID: 5310
	public static void DrawText(string text, float X, float Y, Color color, float size)
	{
		ESPHack.LineMaterial.SetPass(0);
		GUIStyle guistyle = new GUIStyle();
		guistyle.normal.textColor = color;
		guistyle.alignment = TextAnchor.UpperCenter;
		guistyle.fontSize = (int)size;
	    GUI.Label(new Rect(new Vector2(X, Y), guistyle.CalcSize(new GUIContent())), text, guistyle);
	}

	// Token: 0x040011CB RID: 4555
	public bool Esp;

	// Token: 0x040011CC RID: 4556
	public bool EspLine;

	// Token: 0x040011CD RID: 4557
	public bool EspBox;

	// Token: 0x040011CE RID: 4558
	public bool NoFog = true;

	// Token: 0x040011CF RID: 4559
	private static readonly Material LineMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));

	// Token: 0x040011D0 RID: 4560
	public Color Color = Color.green;

	// Token: 0x040011D1 RID: 4561
	public List<ESPHack.enemy> gameObjects;

	// Token: 0x040011D2 RID: 4562
	public bool EspName;

	// Token: 0x02000344 RID: 836
	public class enemy
	{
		// Token: 0x060014BF RID: 5311
		public enemy()
		{
		}

		// Token: 0x040011D3 RID: 4563
		public GameObject gameObject;

		// Token: 0x040011D4 RID: 4564
		public string name;

		// Token: 0x040011D5 RID: 4565
		public float hight;

		// Token: 0x040011D6 RID: 4566
		public float size;

		// Token: 0x040011D7 RID: 4567
		public bool on;

		// Token: 0x040011D8 RID: 4568
		public Color clr;
	}
}
