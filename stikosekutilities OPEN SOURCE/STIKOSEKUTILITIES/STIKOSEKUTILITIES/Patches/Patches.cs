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

namespace STIKOSEKUTILITIES.Patches
{
	[HarmonyPatch]
	internal class MainPatches
	{
		public static string key = "LICKMYBALLSYOUSUSSYBAKAOWORAWRXD";
		public static string iv = "SUGMABALLZCUNTXD";
		public static string INPUT(string inputData)
		{
			AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
			AEScryptoProvider.BlockSize = 128;
			AEScryptoProvider.KeySize = 256;
			AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
			AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv);
			AEScryptoProvider.Mode = CipherMode.CBC;
			AEScryptoProvider.Padding = PaddingMode.PKCS7;
			byte[] txtByteData = Convert.FromBase64String(inputData);
			ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();
			byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
			return ASCIIEncoding.ASCII.GetString(result);
		}
		public static bool chams = true;
		public static bool chamsmob = false;
		public static bool chamsplayer = false;
		public static bool chamsdroped = false;
		public static bool flyhack = false;             //Main
		public static string flyHack;
		public static bool breakeverything = false;
		public static String breakEverything;
		public static bool godmode = false;
		public static String godMode;
		public static bool attack = false;
		public static String Attack;
		public static bool pickupall = false;
		public static String pickupAll;
		public static bool pingspammer = false;
		public static String pingSpammer;
		public static bool jumphack = false;
		public static String jumpHack;
		public static bool speedhack = false;
		public static String speedHack;
		public static bool mobteleporthit = false;
		public static String mobteleportHit;
		public static bool followplayer = false;
		public static String followPlayer;
		public static bool spawnboss = false;
		public static String spawnBoss;

		public static bool drawfov;
		public static String drawFov;
		public static float smoothingammount = 2;
		public static bool aimbot;
		public static String aimBot;
		public static float Radius = 100;

		public static int lineposition;         //ESP
		public static bool playeresp;
		public static bool chestesp;
		public static bool structureEsp;
		public static bool objesp;
		public static bool playersnapline;
		public static bool mobesp;
		public static bool mobsnaplines;
		public static bool resourceesp;
		public static bool resourcesnaplines;
		public static bool treeesp;
		public static bool treesnaplines;
		public static bool respawnshrine;
		public static bool bossshrine;
		public static bool mobshrine;



		public static int tabs = 1;       //MENU
		public static bool toggles = true;
		public static bool menu = false;

		//New and need to add to menu
		public static bool timechanger;
		public static String timeChanger;
		public static float time;
		public static bool nograss = true;
		public static String noGrass;
		public static bool instarevive;
		public static String instaRevive;
		public static bool raycastteleport;
		public static String raycastTeleport;
		public static bool freerespawn;
		public static String freeRespawn;
		public static bool fov;
		public static String Fov;
		public static float fovvalue = 90f;
		public static Vector3 SuFindPingPos()
		{
			Transform playerCam = PlayerMovement.Instance.playerCam;
			RaycastHit raycastHit;
			if (Physics.Raycast(playerCam.position, playerCam.forward, out raycastHit, 1500f))
			{
				Vector3 b = Vector3.zero;
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
				{
					b = Vector3.one;
				}
				return raycastHit.point + b;
			}
			return Vector3.zero;
		}


		[HarmonyPatch(typeof(PlayerStatus), "Awake")]
		private static void Prefix(PlayerStatus __instance)
		{
			MainPatches.SuVer = "1.1";
			MainPatches.Bcolor = UnityEngine.Color.green;
			MainPatches.Ccolor = UnityEngine.Color.white;
			MainPatches.SuPremiumRect = new Rect(100f, 74f, 350f, 50f);
			MainPatches.SuVisualsRect = new Rect(134f, 5f, 150f, 260f);
			MainPatches.SuItemSprites = new List<Sprite>();
			MainPatches.SuPwrSprites = new List<Sprite>();
			MainPatches.SuPowerupNames = new List<string>();
			MainPatches.SuItemAmount = 1f;
			for (int i = 0; i < 144; i++)
			{
				MainPatches.SuItemNamesDev.Add(UnityEngine.Object.FindObjectOfType<ItemManager>().allItems[i].name);
				MainPatches.SuItemSprites.Add(UnityEngine.Object.FindObjectOfType<ItemManager>().allItems[i].sprite);
			}
			for (int j = 0; j < 21; j++)
			{
				MainPatches.SuPwrSprites.Add(UnityEngine.Object.FindObjectOfType<ItemManager>().allPowerups[j].sprite);
				MainPatches.SuPowerupNames.Add(UnityEngine.Object.FindObjectOfType<ItemManager>().allPowerups[j].name);
			}
			WebClient webClient = new WebClient();
			SuCheckedVer = webClient.DownloadString("https://pastebin.com/raw/Z75Vk2Hg");
			
			if (SuCheckedVer != SuVer)
			{
				SuLockout = true;
			}
		}
		public static void replyToSender(ChatBox __instance, string message) { __instance.AppendMessage(-1, string.Concat(new object[3] { "<color=red> [CONFIG]: ", message, "<color=yellow>" }), ""); }
		[HarmonyPatch(typeof(ChatBox), "SendMessage")]
		private static void Postfix(ChatBox __instance, string message)
		{
			string[] array = message.Substring(1).Split(' ');
			switch (array[0].ToLower())
			{
			}
		}

		public static Rect SuwindowRect = new Rect(20f, 20f, 180f, 280f);

		public static bool SuPlayerUi;

		public static bool SuExploitUi;

		public static bool SuServerUi;

		public static bool SuItemUi;

		public static bool SuPowerUi;

		public static bool SuMobUi;

		public static Rect SuPlayerRect = new Rect(250f, 20f, 150f, 320f);

		public static Rect SuServerRect = new Rect(400f, 20f, 350f, 200f);

		public static Rect SuExploitRect = new Rect(750f, 20f, 200f, 350f);

		public static Rect SuItemRect = new Rect(340f, 340f, 500f, 300f);

		public static Rect SuPowerRect = new Rect(840f, 340f, 440f, 220f);

		public static Rect SuMobRect = new Rect(1340f, 340f, 180f, 370f);
		public static Rect SuPremiumRect;

		public static bool SuPremiumUi;

		public static bool SuGod;

		public static bool SuStamina;

		public static bool SuFood;

		public static bool SuNoClip;

		public static bool SuHover;

		public static bool SuClickTp;

		public static bool SuAtackSpeed;

		public static bool SuFlightBool;

		public static bool SuInstamineBool;

		public static bool SuInstakillBool;

		public static bool SuNocoinsBool;

		public static bool SuOmegajump;

		public static bool SuSpeed;

		public static int SuPlayerButtonsXValue;

		public static List<string> SuPowerupNames;

		public static List<string> SuItemNamesDev = new List<string>();

		public static List<Sprite> SuItemSprites;

		public static Vector2 SuScrollPosition;

		public static int SuXpos;

		public static int SuYpos;

		public static int SuCurrentId;

		public static float SuItemAmount;

		public static float SuPowerAmount;

		public static int SuCurrentPwrId;

		public static List<Sprite> SuPwrSprites;

		public static int SuPowerPh;

		public static bool SuMuckChat;

		public static bool SuDisableChatOwner;

		public static bool SuUnlock;
		public static string SuPassword = "*************";

		public static float SuPwrX;

		public static float SuPwrY;

		public static bool SuAdvertize;

		public static bool SuMainLock;

		public static UnityEngine.Color Bcolor;

		public static UnityEngine.Color Ccolor;

		public static bool SuAutoRevive;

		public static int SuPlayerSelection;

		public static int SuPlayersButY;

		public static UnityEngine.Color SuChatColor;

		public static string SuVer;

		public static string SuCheckedVer;

		public static bool SuLockout;

		public static bool SuCanCollectData;

		public static bool SuDisableWatermark;

		public static bool SuVisualsUi;

		public static Rect SuVisualsRect;

		public static bool SuItemRain;

		public static int SuRainCooldown;

		public static int SuRainItemId;

		public static bool SuPlayerEsp;

		public static bool SuCoalEsp;
		public static bool SuOreTracers;
		public static bool SuMobTracers;
		public static bool SuCaveEsp;

		public static bool SuIronEsp;
		public static bool SuGoldEsp;

		public static bool SuStoneEsp;

		public static bool SuMithrilEsp;

		public static bool SuAdamantiteEsp;

		public static bool SuObamiumEsp;
		public static bool SuRubyEsp;
		public static bool SuCowEsp;
		public static bool SuGoblinEsp;
		public static bool SuDaveEsp;
		public static bool SuWyvernEsp;
		public static bool SuGolemEsp;
		public static bool SuGronkEsp;
		public static bool SuBobEsp;
		public static bool SuWolfEsp;
		public static bool SuChunkEsp;
		public static bool SuGuardianEsp;
		public static bool SuWoodEsp;
		public static bool SuBirchEsp;
		public static bool SuFirEsp;
		public static bool SuOakEsp;
		public static bool SuDarkOakEsp;
		public static bool SuLootChestFree;
		public static bool SuLootChestBlue;
		public static bool SuLootChestWhite;
		public static bool SuLootChestOrange;
		public static bool SuObjApple;
		public static bool SuObjFlint;
		public static bool SuObjCoalPickup;
		public static bool SuObjRockPickup;
		public static bool SuObjFlower;
		public static bool SuObjWheat;
		public static bool SuObjMushroomOrange;
		public static bool SuObjMushRoomRed;
		public static bool SuObjMushRoomSus;
		public static bool SuObjMushRoomPink;


		public static bool SuBillyNewRigged;
		public static bool SuFletchingTable;

		public static bool Suworkbench;
		public static bool SuHouseWoodEsp;
		public static bool SuHouseSmithEsp;
		public static bool SuHouseMinerEsp;
		public static bool SuHouseFletchEsp;
		public static bool SuHouseCookEsp;
		public static bool SuBoat;
		public static bool SuCartEsp;

		public static bool SuChestPlayer;

		public static bool SuCauldronEsp;
		public static bool SuFurnaceEsp;


		public static bool SuStairs;
		public static bool SuWallwindow;
		public static bool SuWallhalf;
		public static bool SuDoorway;
		public static bool SuPlankstilt;
		public static bool SuPlanksWall;
		public static bool SuPlanksroof;
		public static bool SuPlanksfloor;
		public static bool SuTorch;
		public static bool SuAnvil;
		public static bool SuPlankspole;


		private LineRenderer LineRenderer;




		[DllImport("user32.dll")]
		static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
		public static void AimbotUpdate()
		{
			float minDist = 99999;
			Vector2 AimTarget = Vector2.zero;


			if (AimTarget != Vector2.zero)
			{
				double DistX = AimTarget.x - Screen.width / 2.0f;
				double DistY = AimTarget.y - Screen.height / 2.0f;

				DistX /= smoothingammount;
				DistY /= smoothingammount;

				if (Input.GetKey(KeyCode.Mouse1))
				{
					mouse_event(0x0001, (int)DistX, (int)DistY, 0, 0);
				}
			}
		}




		public static Vector3 FindTpPos()
		{
			Transform playerCam = PlayerMovement.Instance.playerCam;
			RaycastHit raycastHit;
			if (Physics.Raycast(playerCam.position, playerCam.forward, out raycastHit, 1500f))
			{
				Vector3 b = Vector3.zero;
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
				{
					b = Vector3.one;
				}
				return raycastHit.point + b;
			}
			return Vector3.zero;
		}





		public static void SuLineConnection(Vector3 first, Vector3 second, UnityEngine.Color color)
		{
			UnityEngine.Object.FindObjectOfType<LineRenderer>().startColor = color;
			UnityEngine.Object.FindObjectOfType<LineRenderer>().endColor = color;
			UnityEngine.Object.FindObjectOfType<LineRenderer>().startWidth = 0.3f;
			UnityEngine.Object.FindObjectOfType<LineRenderer>().endWidth = 0.3f;
			UnityEngine.Object.FindObjectOfType<LineRenderer>().SetPosition(0, first);
			UnityEngine.Object.FindObjectOfType<LineRenderer>().SetPosition(1, second);
		}

		[HarmonyPatch(typeof(PlayerStatus), "Update")]
		private static void Postfix(PlayerStatus __instance)
		{

			


			if (aimbot)
			{
				AimbotUpdate();
			}
			
			if (pingspammer)
			{
				Vector3 vector = SuFindPingPos();
				if (vector == Vector3.zero)
				{
					return;
				}
				UnityEngine.Object.Instantiate<GameObject>(PingController.Instance.pingPrefab, vector, Quaternion.identity).GetComponent<PlayerPing>().SetPing(GameManager.players[LocalClient.instance.myId].username, "");
				ClientSend.PlayerPing(vector);
			}
			if (Input.GetKeyDown(KeyCode.Q))
			{
				SuMainLock = !SuMainLock;
				if (SuMainLock && !Cursor.visible)
				{
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;
					return;
				}
				if (!SuMainLock && Cursor.visible)
				{
					Cursor.visible = false;
					Cursor.lockState = CursorLockMode.Locked;
				}
			}


			if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.LeftShift))
			{
				SuLockout = false;
			}




		}




	}

	[HarmonyPatch]
	internal class StikosekPatches
	{




		[HarmonyPatch(typeof(LootContainerInteract), "Interact")]
		private static void Postfix(LootContainerInteract __instance)
		{
			if (MainPatches.SuNocoinsBool)
			{
				ClientSend.PickupInteract(__instance.id);
				return;
			}
		}

		[HarmonyPatch(typeof(PlayerMovement), "Jump")]
		private static void Prefix(PlayerMovement __instance)
		{
			if (MainPatches.SuFlightBool)
			{

				__instance.jumps = 99999;
				__instance.rb.isKinematic = false;
				__instance.jumps = __instance.jumps;
				__instance.readyToJump = false;

				__instance.resetJumpCounter = 0;
				float d = __instance.jumpForce * PowerupInventory.Instance.GetJumpMultiplier(null);
				if (MainPatches.SuOmegajump)
				{
					__instance.rb.AddForce(Vector3.up * d * 5f, ForceMode.Impulse);
					__instance.rb.AddForce(__instance.normalVector * d * 5f, ForceMode.Impulse);
				}
				else
				{
					__instance.rb.AddForce(Vector3.up * d * 1.5f, ForceMode.Impulse);
					__instance.rb.AddForce(__instance.normalVector * d * 0.5f, ForceMode.Impulse);
				}
				Vector3 velocity = __instance.rb.velocity;
				if (__instance.rb.velocity.y < 0.5f)
				{
					__instance.rb.velocity = new Vector3(velocity.x, 0f, velocity.z);
				}
				else if (__instance.rb.velocity.y > 0f)
				{
					__instance.rb.velocity = new Vector3(velocity.x, 0f, velocity.z);
				}
				ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = UnityEngine.Object.Instantiate<GameObject>(__instance.playerJumpSmokeFx, __instance.transform.position, Quaternion.LookRotation(Vector3.up)).GetComponent<ParticleSystem>().velocityOverLifetime;
				velocityOverLifetime.x = __instance.rb.velocity.x * 2f;
				velocityOverLifetime.z = __instance.rb.velocity.z * 2f;
				__instance.playerStatus.Jump();
				return;

			}
		}

		


		[HarmonyPatch(typeof(HitableResource), "Hit", new Type[] { typeof(int), typeof(int), typeof(int), typeof(Vector3), typeof(int) })]
		private static void Prefix(HitableResource __instance, int hitEffect, Vector3 pos, int hitWeaponType)
		{
			if (MainPatches.SuInstamineBool)
			{

				ClientSend.PlayerHitObject(69420, __instance.id, hitEffect, pos, hitWeaponType);
				return;

			}
		}

		[HarmonyPatch(typeof(HitableMob), "Hit")]
		private static void Postfix(HitableMob __instance, int hitEffect, Vector3 hitPos)
		{
			if (MainPatches.SuInstakillBool)
			{
				ClientSend.PlayerDamageMob(__instance.id, 69420, 69420f, hitEffect, hitPos, 0);
				return;
			}
		}

		//
		
		

	}
}