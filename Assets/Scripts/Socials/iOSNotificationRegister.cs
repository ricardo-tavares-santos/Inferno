using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class iOSNotificationRegister : MonoBehaviour
{/*
    public static iOSNotificationRegister instance;
    // Use this for initialization
    void Start()
    {
        MakeSingleton();
        RegisterForNotif();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS
        if (UnityEngine.iOS.NotificationServices.localNotificationCount > 0)
        {
			UnityEngine.iOS.NotificationServices.ClearLocalNotifications();

			UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
        }
#endif
    }
    void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	void RegisterForNotif()

	{

		UnityEngine.iOS.NotificationServices.RegisterForNotifications(
			UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound);
	}
	void ScheduleNotification()

	{
		// schedule notification to be delivered in 24 hours

		UnityEngine.iOS.LocalNotification notif = new UnityEngine.iOS.LocalNotification();

        notif.fireDate = DateTime.Now.AddHours(GameInfo.Notification.TimeShowNotification);

        notif.alertBody = GameInfo.Notification.Message;
        notif.alertAction = GameInfo.Notification.Button;
        notif.soundName = UnityEngine.iOS.LocalNotification.defaultSoundName;
		UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);

	}
    private void OnApplicationQuit()
    {
#if UNITY_IOS

		UnityEngine.iOS.NotificationServices.ClearLocalNotifications();

		UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();

		ScheduleNotification();

#endif
	}
    private void OnApplicationPause(bool pause)
	{
		if (pause) // App going to background

		{

			// cancel all notifications first.

#if UNITY_IOS

			UnityEngine.iOS.NotificationServices.ClearLocalNotifications();

			UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();

			ScheduleNotification();

#endif



		}

		else
		{

#if UNITY_IOS
			// cancel all notifications first.

			UnityEngine.iOS.NotificationServices.ClearLocalNotifications();

			UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();



#endif

		}


	} */
}
