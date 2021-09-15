
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using BepInEx;
using Steamworks.Data;
using Steamworks;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Runtime.InteropServices;

namespace STIKOSEKUTILITIES.GUIscript
{
	internal class GUISys : MonoBehaviour
	{


		public void SuDrawMain(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			if (GUI.Button(new Rect(10f, 20f, 160f, 30f), "Player"))
			{
				Patches.MainPatches.SuPlayerUi = !Patches.MainPatches.SuPlayerUi;
			}
			if (GUI.Button(new Rect(10f, 50f, 160f, 30f), "Player actions"))
			{
				Patches.MainPatches.SuServerUi = !Patches.MainPatches.SuServerUi;
			}
			if (GUI.Button(new Rect(10f, 170f, 160f, 30f), "Mob spawning"))
			{
				Patches.MainPatches.SuMobUi = !Patches.MainPatches.SuMobUi;
			}
			if (GUI.Button(new Rect(10f, 110f, 160f, 30f), "Item spawning"))
			{
				Patches.MainPatches.SuItemUi = !Patches.MainPatches.SuItemUi;
			}
			if (GUI.Button(new Rect(10f, 200f, 160f, 30f), "Premium/dev"))
			{
				Patches.MainPatches.SuPremiumUi = !Patches.MainPatches.SuPremiumUi;
			}
			if (GUI.Button(new Rect(10f, 140f, 160f, 30f), "Powerup spawning"))
			{
				Patches.MainPatches.SuPowerUi = !Patches.MainPatches.SuPowerUi;
			}
			if (GUI.Button(new Rect(10f, 80f, 160f, 30f), "Exploit"))
			{
				Patches.MainPatches.SuExploitUi = !Patches.MainPatches.SuExploitUi;
			}
			if (GUI.Button(new Rect(10f, 230f, 160f, 30f), "Visuals"))
			{
				Patches.MainPatches.SuVisualsUi = !Patches.MainPatches.SuVisualsUi;
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}
		private void SuDrawPlayer(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			Patches.MainPatches.SuPlayerButtonsXValue = 10;
			Patches.MainPatches.SuAutoRevive = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 30f, 150f, 20f), Patches.MainPatches.SuAutoRevive, "Autorevive");
			Patches.MainPatches.SuGod = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 50f, 150f, 20f), Patches.MainPatches.SuGod, "Godmode");
			Patches.MainPatches.SuStamina = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 70f, 150f, 20f), Patches.MainPatches.SuStamina, "Infinite stamina");
			Patches.MainPatches.SuFood = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 90f, 150f, 20f), Patches.MainPatches.SuFood, "infinite food");
			Patches.MainPatches.SuFlightBool = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 110f, 150f, 20f), Patches.MainPatches.SuFlightBool, "Flight");
			Patches.MainPatches.SuInstamineBool = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 130f, 150f, 20f), Patches.MainPatches.SuInstamineBool, "Instamine");
			Patches.MainPatches.SuInstakillBool = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 150f, 150f, 20f), Patches.MainPatches.SuInstakillBool, "Instakill");
			Patches.MainPatches.SuNocoinsBool = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 170f, 150f, 20f), Patches.MainPatches.SuNocoinsBool, "Chests w/o gold");
			Patches.MainPatches.SuOmegajump = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 190f, 150f, 20f), Patches.MainPatches.SuOmegajump, "Omega jump");
			Patches.MainPatches.SuNoClip = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 210f, 150f, 20f), Patches.MainPatches.SuNoClip, "No clip");
			Patches.MainPatches.SuSpeed = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 230f, 150f, 20f), Patches.MainPatches.SuSpeed, "Speed");
			Patches.MainPatches.SuHover = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 250f, 150f, 20f), Patches.MainPatches.SuHover, "Hover");
			Patches.MainPatches.SuClickTp = GUI.Toggle(new Rect((float)Patches.MainPatches.SuPlayerButtonsXValue, 270f, 150f, 20f), Patches.MainPatches.SuClickTp, "Click tp");
			
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		public void SuDrawPremium(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;

			GUI.Label(new Rect(0f, 5f, 450f, 20f), "Donate to get premium :D discord.gg/stikosek");


			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		private void SuDrawServer(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			PlayerManager[] array = UnityEngine.Object.FindObjectsOfType<PlayerManager>();
			for (int i = 0; i < array.Length; i++)
			{
				Patches.MainPatches.SuPlayersButY = i * 20 + 20;
				if (GUI.Button(new Rect(20f, (float)Patches.MainPatches.SuPlayersButY, 100f, 20f), array[i].username))
				{
					Patches.MainPatches.SuPlayerSelection = i;
				}
			}
			GUI.Box(new Rect(140f, 20f, 200f, 160f), "Player actions");
			GUI.Label(new Rect(10f, 180f, 250f, 20f), "Thanks to Farliam for the cage code :)");
			GUI.Label(new Rect(150f, 40f, 70f, 20f), "Selected:");
			if (array[Patches.MainPatches.SuPlayerSelection].username == UnityEngine.Object.FindObjectOfType<PlayerManager>().username)
			{
				GUI.Label(new Rect(210f, 40f, 50f, 20f), "yourself [E]");
			}
			else
			{
				GUI.Label(new Rect(210f, 40f, 50f, 20f), array[Patches.MainPatches.SuPlayerSelection].username);
			}
			if (GUI.Button(new Rect(150f, 60f, 90f, 30f), "Kill[HOST]"))
			{
				ServerSend.HitPlayer(LocalClient.instance.myId, 69420, 0f, array[Patches.MainPatches.SuPlayerSelection].id, 1, array[Patches.MainPatches.SuPlayerSelection].transform.position);
			}
			if (GUI.Button(new Rect(150f, 90f, 90f, 30f), "Kick[HOST]"))
			{
				ServerSend.DisconnectPlayer(array[Patches.MainPatches.SuPlayerSelection].id);
			}
			if (GUI.Button(new Rect(240f, 90f, 90f, 30f), "Cage"))
			{
				Vector3 position = array[Patches.MainPatches.SuPlayerSelection].transform.position;
				position.y += 5f;
				Vector3 vector = position;
				Vector3 beuh = position;
				beuh.y -= 7f;
				vector.x -= 3.5f;
				vector.y -= 3.5f;
				Vector3 pos = vector;
				pos.x += 7f;
				Vector3 vector2 = position;
				vector2.y -= 3.5f;
				vector2.z -= 3.5f;
				Vector3 pos2 = vector2;
				pos2.z += 7f;
				ClientSend.RequestBuild(35, position, 0);
				ClientSend.RequestBuild(35, beuh, 0);
				ClientSend.RequestBuild(41, vector, 90);
				ClientSend.RequestBuild(41, pos, 90);
				ClientSend.RequestBuild(41, vector2, 180);
				ClientSend.RequestBuild(41, pos2, 180);
			}
			if (GUI.Button(new Rect(240f, 60f, 90f, 30f), "Tp me-player"))
			{
				PlayerMovement.Instance.GetRb().position = array[Patches.MainPatches.SuPlayerSelection].transform.position;
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		private void SuDrawExploit(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			Patches.MainPatches.SuMuckChat = GUI.Toggle(new Rect(10f, 30f, 100f, 30f), Patches.MainPatches.SuMuckChat, "Muck chat?");
			if (Patches.MainPatches.SuMuckChat)
			{
				UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("UGZTfugfgauzgfiGFUTGgzisgdbfUZKGUIFGSIUGfzug");
			}
			if (GUI.Button(new Rect(10f, 60f, 180f, 30f), "Unlock all advancments"))
			{
				foreach (Achievement achievement in SteamUserStats.Achievements)
				{
					achievement.Trigger(true);
				}
				SteamUserStats.StoreStats();
			}
			if (GUI.Button(new Rect(10f, 90f, 180f, 30f), "Reset all advancments"))
			{
				SteamUserStats.ResetAll(true);
			}
			if (Patches.MainPatches.SuAdvertize = GUI.Toggle(new Rect(100f, 30f, 180f, 30f), Patches.MainPatches.SuAdvertize, "Advertize?"))
			{
				ClientSend.SendChatMessage(string.Concat(new string[]
				{
				"<color=green>discord.gg/stikosek</color> <b><color=red>Best muck hack</color></b>"
				}));
			}
			/*
			GUI.Label(new Rect(10f, 140f, 180f, 20f), "Chat color:");

			if (GUI.Button(new Rect(10f, 160f, 180f, 20f), "Red"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.red;
			}
			if (GUI.Button(new Rect(10f, 180f, 180f, 20f), "Black"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.black;
			}
			if (GUI.Button(new Rect(10f, 200, 180f, 20f), "Yellow"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.yellow;
			}
			if (GUI.Button(new Rect(10f, 220, 180f, 20f), "Green"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.green;
			}
			if (GUI.Button(new Rect(10f, 240, 180f, 20f), "Blue"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.blue;
			}
			if (GUI.Button(new Rect(10f, 260, 180f, 20f), "Cyan"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.cyan;
			}
			if (GUI.Button(new Rect(10f, 280f, 180f, 20f), "Gray"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.gray;
			}
			if (GUI.Button(new Rect(10f, 300, 180f, 20f), "White"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.white;
			}
			if (GUI.Button(new Rect(10f, 320, 180f, 20f), "Magenta"))
			{
				Patches.MainPatches.SuChatColor = UnityEngine.Color.magenta;
			}
			*/
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		private void SuDrawItem(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			Patches.MainPatches.SuItemAmount = GUI.VerticalSlider(new Rect(460f, 50f, 50f, 230f), Patches.MainPatches.SuItemAmount, 1000f, 1f);
			GUI.Label(new Rect(450f, 40f, 60f, 20f), Patches.MainPatches.SuItemAmount.ToString());
			GUI.Label(new Rect(450f, 20f, 60f, 20f), "Amount:");
			Patches.MainPatches.SuScrollPosition = GUI.BeginScrollView(new Rect(10f, 20f, 440f, 270f), Patches.MainPatches.SuScrollPosition, new Rect(0f, 0f, 440f, 1500f), false, true);
			for (int i = 0; i < 21; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (Patches.MainPatches.SuCurrentId < 144)
					{
						GUI.Label(new Rect((float)(j * 60), (float)(i * 60), 60f, 60f), Patches.MainPatches.SuCurrentId.ToString());
						if (GUI.Button(new Rect((float)(j * 60), (float)(i * 60), 60f, 60f), Patches.MainPatches.SuItemSprites[Patches.MainPatches.SuCurrentId].texture))
						{
							foreach (InventoryItem inventoryItem in ItemManager.Instance.allItems.Values)
							{
								if (inventoryItem.id == Patches.MainPatches.SuCurrentId)
								{
									InventoryItem inventoryItem2 = inventoryItem;
									inventoryItem2.amount = (int)Patches.MainPatches.SuItemAmount;
									InventoryUI.Instance.AddItemToInventory(inventoryItem2);
									break;
								}
							}
						}
					}
					Patches.MainPatches.SuCurrentId++;
				}
			}
			Patches.MainPatches.SuCurrentId = 0;
			GUI.EndScrollView();
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		public int hmmm;

		public void SuDrawPower(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			Patches.MainPatches.SuPowerAmount = GUI.HorizontalSlider(new Rect(255f, 205f, 170f, 30f), Patches.MainPatches.SuPowerAmount, 1f, 50f);
			GUI.Label(new Rect(255f, 225f, 170f, 30f), "Amount: " + Patches.MainPatches.SuPowerAmount.ToString());
			for (int i = 0; i < 1; i++)
			{
				Patches.MainPatches.SuCurrentPwrId = 0;
				for (int j = 0; j < 4; j++)
				{
					Patches.MainPatches.SuPwrY = (float)(j * 60 + 20);
					for (int k = 0; k < 7; k++)
					{
						Patches.MainPatches.SuPwrX = (float)(k * 60 + 10);
						if (Patches.MainPatches.SuCurrentPwrId < 25 && GUI.Button(new Rect(Patches.MainPatches.SuPwrX, Patches.MainPatches.SuPwrY, 60f, 60f), Patches.MainPatches.SuPwrSprites[Patches.MainPatches.SuCurrentPwrId].texture))
						{
							hmmm = (int)Patches.MainPatches.SuPowerAmount;
							for (int l = 0; l < hmmm; l++)
							{
								PowerupInventory.Instance.AddPowerup(ItemManager.Instance.allPowerups[Patches.MainPatches.SuCurrentPwrId].name, ItemManager.Instance.allPowerups[Patches.MainPatches.SuCurrentPwrId].id, ItemManager.Instance.GetNextId());
							}
						}
						Patches.MainPatches.SuCurrentPwrId++;
					}
				}
				Patches.MainPatches.SuCurrentPwrId = 0;
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		private void SuDrawMob(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;
			GUI.Label(new Rect(0f, 0f, 160f, 20f), MobSpawner.Instance.allMobs.Length.ToString());
			for (int i = 0; i < 17; i++)
			{
				if (GUI.Button(new Rect(10f, (float)i * 20f + 20f, 160f, 20f), MobSpawner.Instance.allMobs[i].name))
				{
					MobSpawner.Instance.ServerSpawnNewMob(MobManager.Instance.GetNextId(), MobSpawner.Instance.allMobs[i].id, PlayerMovement.Instance.GetRb().position, 1f, 1f, Mob.BossType.None, -1);
				}
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		public static bool SuMobEsp;
		public static bool SuChestEsp;
		public static bool SuStructureEsp;
		public void SuDrawVisuals(int windowID)
		{
			GUI.backgroundColor = Patches.MainPatches.Bcolor;
			GUI.contentColor = Patches.MainPatches.Ccolor;


			Patches.MainPatches.SuPlayerEsp = GUI.Toggle(new Rect(10f, 20 * 1f, 120f, 15), Patches.MainPatches.SuPlayerEsp, "Player ESP");

			Patches.MainPatches.SuCoalEsp = GUI.Toggle(new Rect(10f, 20 * 2f, 170f, 15f), Patches.MainPatches.SuCoalEsp, "Coal ESP");
			Patches.MainPatches.SuStoneEsp = GUI.Toggle(new Rect(10f, 20 * 3f, 170f, 15f), Patches.MainPatches.SuStoneEsp, "Stone ESP");
			Patches.MainPatches.SuIronEsp = GUI.Toggle(new Rect(10f, 20 * 4f, 170f, 15f), Patches.MainPatches.SuIronEsp, "Iron ESP");
			Patches.MainPatches.SuGoldEsp = GUI.Toggle(new Rect(10f, 20 * 5f, 170f, 15f), Patches.MainPatches.SuGoldEsp, "Gold ESP");
			Patches.MainPatches.SuMithrilEsp = GUI.Toggle(new Rect(10f, 20 * 6f, 170f, 15f), Patches.MainPatches.SuMithrilEsp, "Mithril ESP");
			Patches.MainPatches.SuAdamantiteEsp = GUI.Toggle(new Rect(10f, 20 * 7f, 170f, 15f), Patches.MainPatches.SuAdamantiteEsp, "Adamantite ESP");
			Patches.MainPatches.SuObamiumEsp = GUI.Toggle(new Rect(10f, 20 * 8f, 170f, 15f), Patches.MainPatches.SuObamiumEsp, "Obamium ESP");
			Patches.MainPatches.SuRubyEsp = GUI.Toggle(new Rect(10f, 20 * 9f, 170f, 15f), Patches.MainPatches.SuRubyEsp, "Ruby ESP");

			


		
			//2 MOBS
			/*
			
			//1 CHEST
			
			

			SuObjApple = GUI.Toggle(new Rect(200f, 330, 170f, 15f), SuObjApple, "Apple ESP");
			SuObjFlint = GUI.Toggle(new Rect(200f, 345, 170f, 15f), SuObjFlint, "Flint ESP");
			SuObjCoalPickup = GUI.Toggle(new Rect(200f, 360, 170f, 15f), SuObjCoalPickup, "Coal Pickup ESP");
			SuObjRockPickup = GUI.Toggle(new Rect(200f, 375, 170f, 15f), SuObjRockPickup, "Rock Pickup ESP");
			SuObjFlower = GUI.Toggle(new Rect(200f, 390, 170f, 15f), SuObjFlower, "Flax/Flower ESP");
			SuObjWheat = GUI.Toggle(new Rect(200f, 405, 170f, 15f), SuObjWheat, "Wheat GOLD ESP");
			SuObjMushroomOrange = GUI.Toggle(new Rect(200f, 420, 170f, 15f), SuObjMushroomOrange, "Mushroom ORANGE ESP");
			SuObjMushRoomRed = GUI.Toggle(new Rect(200f, 435, 170f, 15f), SuObjMushRoomRed, "Mushroom RED ESP");
			SuObjMushRoomSus = GUI.Toggle(new Rect(200f, 450, 170f, 15f), SuObjMushRoomSus, "Mushroom SUS ESP");
			SuObjMushRoomPink = GUI.Toggle(new Rect(200f, 465, 170f, 15f), SuObjMushRoomPink, "Mushroom PINK ESP");

			SuCauldronEsp = GUI.Toggle(new Rect(5f, 575, 170f, 15f), SuCauldronEsp, "Cauldron ESP");
			SuFurnaceEsp = GUI.Toggle(new Rect(5f, 590, 170f, 15f), SuFurnaceEsp, "Furnace ESP");


			SuStairs = GUI.Toggle(new Rect(5f, 605, 170f, 15f), SuStairs, "Stairs ESP");
			SuWallwindow = GUI.Toggle(new Rect(5f, 620, 170f, 15f), SuWallwindow, "Window ESP");
			SuWallhalf = GUI.Toggle(new Rect(5f, 635, 170f, 15f), SuWallhalf, "Half-Wall ESP");
			SuDoorway = GUI.Toggle(new Rect(5f, 650, 170f, 15f), SuDoorway, "Doorway ESP");
			SuPlankstilt = GUI.Toggle(new Rect(5f, 665, 170f, 15f), SuPlankstilt, "Angle ESP");
			SuPlanksWall = GUI.Toggle(new Rect(5f, 680, 170f, 15f), SuPlanksWall, "Wall ESP");
			SuPlanksroof = GUI.Toggle(new Rect(5f, 695, 170f, 15f), SuPlanksroof, "Roof ESP");
			SuPlanksfloor = GUI.Toggle(new Rect(5f, 710, 170f, 15f), SuPlanksfloor, "Floor ESP");
			SuTorch = GUI.Toggle(new Rect(5f, 725, 170f, 15f), SuTorch, "Torch ESP");
			SuAnvil = GUI.Toggle(new Rect(5f, 740, 170f, 15f), SuAnvil, "Anvil ESP");
			SuPlankspole = GUI.Toggle(new Rect(5f, 755, 170f, 15f), SuPlankspole, "Pole ESP");

			Suworkbench = GUI.Toggle(new Rect(5f, 770, 170f, 15f), Suworkbench, "Workbench ESP");
			
			SuCartEsp = GUI.Toggle(new Rect(5f, 860, 170f, 15f), SuCartEsp, "Cart ESP");
			SuCaveEsp = GUI.Toggle(new Rect(5f, 875, 170f, 15f), SuCaveEsp, "Cave ESP");
			*/


			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}


		public void OnGUI()
		{
			

			if (!Patches.MainPatches.SuAutoRevive && PlayerStatus.Instance.IsPlayerDead())
			{
				ClientSend.RevivePlayer(LocalClient.instance.myId, -1, false);
			}

			if (Patches.MainPatches.SuLockout)
			{
				GUI.backgroundColor = UnityEngine.Color.white;
				GUI.contentColor = UnityEngine.Color.red;
				GUI.Label(new Rect(0f, 0f, 500f, 50f), "Outdated version of stikosekutilities! Please download the latest version on discord.gg/stikosek.");
				GUI.contentColor = UnityEngine.Color.blue;
				GUI.Label(new Rect(0f, 50f, 500f, 50f), "Current version:" + Patches.MainPatches.SuVer + "  Newest version:" + Patches.MainPatches.SuCheckedVer);
				return;
			}
			GUI.backgroundColor = UnityEngine.Color.white;
			GUI.contentColor = UnityEngine.Color.green;
			if (!Patches.MainPatches.SuDisableWatermark)
			{
				GUI.Label(new Rect(0f, 0f, 450f, 25f), "stikosekutilities V1.1 [B.V]  [discord.gg/stikosek]");
				
			}


			if (FindObjectOfType<PlayerMovement>() != null)
			{


				if (Patches.MainPatches.SuMainLock)
				{
					Patches.MainPatches.SuwindowRect = GUI.Window(0, Patches.MainPatches.SuwindowRect, new GUI.WindowFunction(SuDrawMain), "stikosekutilities V1.1");
					if (Patches.MainPatches.SuPlayerUi)
					{
						Patches.MainPatches.SuPlayerRect = GUI.Window(1, Patches.MainPatches.SuPlayerRect, new GUI.WindowFunction(SuDrawPlayer), "Player");
					}
					if (Patches.MainPatches.SuExploitUi)
					{
						Patches.MainPatches.SuExploitRect = GUI.Window(2, Patches.MainPatches.SuExploitRect, new GUI.WindowFunction(SuDrawExploit), "Exploit");
					}
					if (Patches.MainPatches.SuServerUi)
					{
						Patches.MainPatches.SuServerRect = GUI.Window(3, Patches.MainPatches.SuServerRect, new GUI.WindowFunction(SuDrawServer), "Player actions");
					}
					if (Patches.MainPatches.SuItemUi)
					{
						Patches.MainPatches.SuItemRect = GUI.Window(4, Patches.MainPatches.SuItemRect, new GUI.WindowFunction(SuDrawItem), "Item spawning");
					}
					if (Patches.MainPatches.SuPowerUi)
					{
						Patches.MainPatches.SuPowerRect = GUI.Window(5, Patches.MainPatches.SuPowerRect, new GUI.WindowFunction(SuDrawPower), "Powerup spawning");
					}
					if (Patches.MainPatches.SuMobUi)
					{
						Patches.MainPatches.SuMobRect = GUI.Window(6, Patches.MainPatches.SuMobRect, new GUI.WindowFunction(SuDrawMob), "Mob spawning [HOST]");
					}
					if (Patches.MainPatches.SuPremiumUi)
					{
						Patches.MainPatches.SuPremiumRect = GUI.Window(7, Patches.MainPatches.SuPremiumRect, new GUI.WindowFunction(SuDrawPremium), "Premium");
					}
					if (Patches.MainPatches.SuVisualsUi)
					{
						Patches.MainPatches.SuVisualsRect = GUI.Window(8, Patches.MainPatches.SuVisualsRect, new GUI.WindowFunction(SuDrawVisuals), "Visuals");
					}
				}
				if (Patches.MainPatches.SuGod)
				{
					PlayerStatus.Instance.hp = (float)PlayerStatus.Instance.maxHp;
					PlayerStatus.Instance.shield = (float)PlayerStatus.Instance.maxShield;
				}
				if (Patches.MainPatches.SuStamina)
				{
					PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
				}
				if (Patches.MainPatches.SuFood)
				{
					PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
				}
				if (Patches.MainPatches.SuNoClip)
				{
					UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetPlayerCollider().enabled = false;
				}
				else
				{
					UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetPlayerCollider().enabled = true;
				}
				if (Patches.MainPatches.SuHover)
				{
					UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetRb().velocity = new Vector3(0f, 1f, 0f);
				}
				if (Patches.MainPatches.SuClickTp && Input.GetKeyDown(KeyCode.Mouse1))
				{
					UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetRb().position = Patches.MainPatches.FindTpPos();
				}
				if (Patches.MainPatches.SuAtackSpeed)
				{
					if (PlayerStatus.Instance.speed != PlayerStatus.Instance.speed * 99999)
					{
						PlayerStatus.Instance.speed *= 99999;
						return;
					}
					if (PlayerStatus.Instance.speed == PlayerStatus.Instance.speed * 99999)
					{
						PlayerStatus.Instance.speed /= 99999;
					}


				}



			}
			

			// yo wtf


			if (Patches.MainPatches.drawfov)
			{
				GUIscript.GUIesp.SuDrawCircle(UnityEngine.Color.white, new Vector2(Screen.width / 2, Screen.height / 2), Patches.MainPatches.Radius);
			}
            if (Patches.MainPatches.SuSpeed)
            {
				PlayerStatus.Instance.currentSpeedArmorMultiplier = 25;
			}
            else
            {
				PlayerStatus.Instance.currentSpeedArmorMultiplier = 1;
			}





			if (Patches.MainPatches.SuPlayerEsp)
			{
				foreach (OnlinePlayer player in UnityEngine.Object.FindObjectsOfType(typeof(OnlinePlayer)) as OnlinePlayer[])
				{
					float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, player.transform.position);
					int distanceToint = (int)distance;
					GUIStyle style = new GUIStyle
					{
						alignment = TextAnchor.MiddleCenter
					};
					style.normal.textColor = UnityEngine.Color.white;
					Vector3 w2s = Camera.main.WorldToScreenPoint(player.transform.position);
					if (w2s.z > 0f)
					{
						GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), player.name.Replace("(Clone)", "") + " [" + distanceToint + "m]", style);//Name Esp
						if (Patches.MainPatches.playersnapline)
						{
							if (Patches.MainPatches.lineposition == 1)
							{
								GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(w2s.x, (float)Screen.height - w2s.y), UnityEngine.Color.red, 2f);//SnapLine
							}
							if (Patches.MainPatches.lineposition == 2)
							{
								GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s.x, (float)Screen.height - w2s.y), UnityEngine.Color.red, 2f);//SnapLine
							}
						}
					}
				}
			}



			foreach (HitableRock resource in UnityEngine.Object.FindObjectsOfType(typeof(HitableRock)) as HitableRock[])
			{
				if (resource.entityName.ToLowerInvariant().Contains("coal"))
				{
					if (Patches.MainPatches.SuCoalEsp)
					{
						GUIStyle style1 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style1.normal.textColor = UnityEngine.Color.black;
						Vector3 w2s1 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s1.z > 0f)
						{
							w2s1.z = w2s1.y + Screen.height;
							GUI.Label(new Rect(w2s1.x, (float)Screen.height - w2s1.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style1);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s1.x, (float)Screen.height - w2s1.y), UnityEngine.Color.black, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("stone") || resource.entityName.ToLowerInvariant().Contains("rock"))
				{
					if (Patches.MainPatches.SuStoneEsp)
					{
						GUIStyle style2 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style2.normal.textColor = UnityEngine.Color.grey;
						Vector3 w2s2 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s2.z > 0f)
						{
							w2s2.z = w2s2.y + Screen.height;
							GUI.Label(new Rect(w2s2.x, (float)Screen.height - w2s2.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style2);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s2.x, (float)Screen.height - w2s2.y), UnityEngine.Color.gray, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("iron"))
				{
					if (Patches.MainPatches.SuIronEsp)
					{
						GUIStyle style3 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style3.normal.textColor = UnityEngine.Color.white;
						Vector3 w2s3 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s3.z > 0f)
						{
							w2s3.z = w2s3.y + Screen.height;
							GUI.Label(new Rect(w2s3.x, (float)Screen.height - w2s3.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style3);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s3.x, (float)Screen.height - w2s3.y), UnityEngine.Color.white, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("gold"))
				{
					if (Patches.MainPatches.SuGoldEsp)
					{
						GUIStyle style4 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style4.normal.textColor = UnityEngine.Color.yellow;
						Vector3 w2s4 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s4.z > 0f)
						{
							w2s4.z = w2s4.y + Screen.height;
							GUI.Label(new Rect(w2s4.x, (float)Screen.height - w2s4.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style4);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s4.x, (float)Screen.height - w2s4.y), UnityEngine.Color.yellow, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("mithril"))
				{
					if (Patches.MainPatches.SuMithrilEsp)
					{
						GUIStyle style5 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style5.normal.textColor = UnityEngine.Color.cyan;
						Vector3 w2s5 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s5.z > 0f)
						{
							w2s5.z = w2s5.y + Screen.height;
							GUI.Label(new Rect(w2s5.x, (float)Screen.height - w2s5.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style5);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s5.x, (float)Screen.height - w2s5.y), UnityEngine.Color.cyan, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("adamantite"))
				{
					if (Patches.MainPatches.SuAdamantiteEsp)
					{
						GUIStyle style6 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style6.normal.textColor = UnityEngine.Color.green;
						Vector3 w2s6 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s6.z > 0f)
						{
							w2s6.z = w2s6.y + Screen.height;
							GUI.Label(new Rect(w2s6.x, (float)Screen.height - w2s6.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style6);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s6.x, (float)Screen.height - w2s6.y), UnityEngine.Color.green, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("obamium"))
				{
					if (Patches.MainPatches.SuObamiumEsp)
					{
						GUIStyle style7 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style7.normal.textColor = UnityEngine.Color.magenta;
						Vector3 w2s7 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s7.z > 0f)
						{
							w2s7.z = w2s7.y + Screen.height;
							GUI.Label(new Rect(w2s7.x, (float)Screen.height - w2s7.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style7);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s7.x, (float)Screen.height - w2s7.y), UnityEngine.Color.magenta, 2f);//SnapLine
						}
					}
				}
				if (resource.entityName.ToLowerInvariant().Contains("ruby"))
				{
					if (Patches.MainPatches.SuRubyEsp)
					{
						GUIStyle style7 = new GUIStyle
						{
							alignment = TextAnchor.MiddleCenter
						};
						style7.normal.textColor = UnityEngine.Color.magenta;
						Vector3 w2s7 = Camera.main.WorldToScreenPoint(resource.transform.position);
						if (w2s7.z > 0f)
						{
							w2s7.z = w2s7.y + Screen.height;
							GUI.Label(new Rect(w2s7.x, (float)Screen.height - w2s7.y, 0f, 0f), resource.name.Replace("(Clone)", "") + " [" + resource.hp + " HP]", style7);
							GUIscript.GUIesp.SuDrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s7.x, (float)Screen.height - w2s7.y), UnityEngine.Color.magenta, 2f);//SnapLine
						}
					}
				}








			}
			// yes yes i am retarted lol

		

	}
	}



	internal class GUIesp : MonoBehaviour
	{


		public static void SuDrawLine(Rect rect)
		{
			SuDrawLine(rect, GUI.contentColor, 1f);
		}

		public static void SuDrawLine(Rect rect, UnityEngine.Color color)
		{
			SuDrawLine(rect, color, 1f);
		}

		public static void SuDrawLine(Rect rect, float width)
		{
			SuDrawLine(rect, GUI.contentColor, width);
		}

		public static void SuDrawLine(Rect rect, UnityEngine.Color color, float width)
		{
			SuDrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width);
		}

		public static void SuDrawLine(Vector2 pointA, Vector2 pointB)
		{
			SuDrawLine(pointA, pointB, GUI.contentColor, 1f);
		}

		public static void SuDrawLine(Vector2 pointA, Vector2 pointB, UnityEngine.Color color)
		{
			SuDrawLine(pointA, pointB, color, 1f);
		}

		public static void SuDrawLine(Vector2 pointA, Vector2 pointB, float width)
		{
			SuDrawLine(pointA, pointB, GUI.contentColor, width);
		}

		public static Texture2D lineTex;
		public static void SuDrawLine(Vector2 pointA, Vector2 pointB, UnityEngine.Color color, float width)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (!lineTex)
			{
				lineTex = new Texture2D(1, 1);
			}
			UnityEngine.Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);
			if (pointA.y > pointB.y)
			{
				num = -num;
			}
			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}

		public static void DrawBox(float x, float y, float w, float h, UnityEngine.Color color)
		{
			SuDrawLine(new Vector2(x, y), new Vector2(x + w, y), color);
			SuDrawLine(new Vector2(x, y), new Vector2(x, y + h), color);
			SuDrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color);
			SuDrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color);
		}

		public static Material mat;
		public static void SuDrawCircle(UnityEngine.Color col, Vector2 Center, float Radius)
		{
			mat = new Material(Shader.Find("Hidden/Internal-Colored"))
			{
				hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy
			};

			mat.SetInt("_SrcBlend", 5);
			mat.SetInt("_DstBlend", 10);
			mat.SetInt("_Cull", 0);
			mat.SetInt("_ZTest", 8);
			mat.SetInt("_ZWrite", 0);
			mat.SetColor("_Color", col);

			GL.PushMatrix();
			mat.SetPass(0);
			GL.LoadPixelMatrix();
			GL.Color(col);
			GL.Begin(GL.LINES);
			for (float num = 0f; num < 6.28318548f; num += 0.05f)
			{
				GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
				GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * Radius + Center.x, Mathf.Sin(num + 0.05f) * Radius + Center.y));
			}
			GL.End();
			GL.PopMatrix();
		}

		static bool SuEspLoc;
		
		static HitableRock[] array2;
		static Mob[] array3;






		public static void ESPtest()
		{











		}
	}
}
