
public static class GameInfo
{
    public const string GameName = "Inferno";
    public const string URL_img = "";
#if UNITY_IOS
    public static readonly string[] C0_leaderboard_BestTime = { "c0_l1_bt", "c0_l2_bt", "c0_l3_bt", "c0_l4_bt", "c0_l5_bt" };

    public static readonly string[] C0_leaderboard_Deaths = { "c0_l1_d", "c0_l2_d", "c0_l3_d", "c0_l4_d", "c0_l5_d" };

    public static readonly string[] C1_leaderboard_BestTime = {
        "c1_l1_bt", "c1_l2_bt", "c1_l3_bt", "c1_l4_bt", "c1_l5_bt",
        "c1_l6_bt", "c1_l7_bt", "c1_l8_bt", "c1_l9_bt", "c1_l10_bt",
        "c1_l11_bt" , "c1_l12_bt", "c1_l13_bt", "c1_l14_bt", "c1_l15_bt",
        "c1_l16_bt" , "c1_l17_bt", "c1_l18_bt", "c1_l19_bt", "c1_l20_bt",
        "c1_l21_bt" , "c1_l22_bt", "c1_l23_bt", "c1_l24_bt", "c1_l25_bt"};

    public static readonly string[] C1_leaderboard_Deaths = {
        "c1_l1_d", "c1_l2_d", "c1_l3_d", "c1_l4_d", "c1_l5_d",
        "c1_l6_d", "c1_l7_d", "c1_l8_d", "c1_l9_d", "c1_l10_d",
        "c1_l11_d" , "c1_l12_d", "c1_l13_d", "c1_l14_d", "c1_l15_d",
        "c1_l16_d" , "c1_l17_d", "c1_l18_d", "c1_l19_d", "c1_l20_d",
        "c1_l21_d" , "c1_l22_d", "c1_l23_d", "c1_l24_d", "c1_l25_d"};

#else
	
//??? LeaderBoardController ???

    public static readonly string[] C0_leaderboard_BestTime = { "c0_l1_bt", "c0_l2_bt", "c0_l3_bt", "c0_l4_bt", "c0_l5_bt" };

    public static readonly string[] C0_leaderboard_Deaths = { "c0_l1_d", "c0_l2_d", "c0_l3_d", "c0_l4_d", "c0_l5_d" };

    public static readonly string[] C1_leaderboard_BestTime = { "CgkItbv2qIoDEAIQAQ","CgkItbv2qIoDEAIQAg","CgkItbv2qIoDEAIQAw","CgkItbv2qIoDEAIQBA","CgkItbv2qIoDEAIQBQ"
        ,"CgkItbv2qIoDEAIQBg","CgkItbv2qIoDEAIQBw","CgkItbv2qIoDEAIQCA","CgkItbv2qIoDEAIQCQ","CgkItbv2qIoDEAIQCg","CgkItbv2qIoDEAIQCw","CgkItbv2qIoDEAIQDA"
        ,"CgkItbv2qIoDEAIQDQ","CgkItbv2qIoDEAIQDg","CgkItbv2qIoDEAIQDw"};

    public static readonly string[] C1_leaderboard_Deaths = { "CgkItbv2qIoDEAIQEA","CgkItbv2qIoDEAIQEQ","CgkItbv2qIoDEAIQEg","CgkItbv2qIoDEAIQEw","CgkItbv2qIoDEAIQFA"
        ,"CgkItbv2qIoDEAIQFQ","CgkItbv2qIoDEAIQFg","CgkItbv2qIoDEAIQFw","CgkItbv2qIoDEAIQGA","CgkItbv2qIoDEAIQGQ","CgkItbv2qIoDEAIQGg","CgkItbv2qIoDEAIQGw"
        ,"CgkItbv2qIoDEAIQHA","CgkItbv2qIoDEAIQHQ","CgkItbv2qIoDEAIQHg"};

#endif

    //IOS
    public static class IOS
    {
        public const string URL_RateApp = "";
        public const string URL_MoreApp = "";
        public const string UnityAdsID = "";
        public const string GoogleAds_BannerAds = "";
        public const string GoogleAds_FullAds = "";
        public const string GoogleAds_VideoAds = "";
    }
    //Android
    public static class Android
    {
        public const string URL_RateApp = "https://play.google.com/store/apps/details?id=com.RWdesenv.Inferno";
        public const string URL_MoreApp = "https://fb.me/rwdesenvgames";
        public const string UnityAdsID = "";
        public const string GoogleAds_BannerAds = "";//"ca-app-pub-2697339358784861/7639688232";
        public const string GoogleAds_FullAds = "ca-app-pub-2697339358784861/4630381511";
        public const string GoogleAds_VideoAds = "ca-app-pub-2697339358784861/5368748115";
    }
    //Notification
    public static class Notification
    {
        public const int TimeShowNotification = 12;
        public const string Title = "Inferno";
        public const string Message = "Rise up and save your soul!!!";
        public const string Button = "Play";
    }
}
