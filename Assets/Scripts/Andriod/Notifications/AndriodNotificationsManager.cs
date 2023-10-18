using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif


public class AndriodNotificationsManager : MonoBehaviour
{

    private void Start() {
        ChallengePlayerNotifcation(new TimeSpan(4,0,0));
    }

    public const string channelId = "NotificationChannel";

#if UNITY_ANDROID

    // Function to schedule the notifications
    // Can be used at different places to schedule notifications

    public void ChallengePlayerNotifcation(TimeSpan repeatInterval){

        Debug.Log("Om");

        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = channelId,
            Name = "Notifications",
            Importance = Importance.Default,
            Description = "Used to push notifcations on andriod devices",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotification challengePlayer = new AndroidNotification
        {
            Title = "Game On, Loser!",
            Text = "Still a loser? Prove us wrong! Win now!!",
            SmallIcon = "default",
            LargeIcon = "default",
            RepeatInterval = repeatInterval
        };

        AndroidNotificationCenter.CancelAllScheduledNotifications();
        AndroidNotificationCenter.SendNotification(challengePlayer,channelId);

    }


#endif

}