namespace Ripple.API.Modules.Core.Models
{
    public class AppConstants
    {
        public int ResetPasswordDuration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int AuthorisationTokenExpiration { get; set; }
        public int MinimumWithdrawal { get; set; }
        public int MaximumWithdrawal { get; set; }
        public int ReferralPoint { get; set; }
        public int ReferralThreshold { get; set; }
        public string? FCMTitle { get; set; }
        public string? AwsPubUrl { get; set; }
        public bool AllowKyclessWithdrawal { get; set; }
        public string? RegioUrl { get; set; }
        public decimal CollectibleBaseValue { get; set; }
        public decimal BurnCommission { get; set; }
        public decimal EntryFee { get; set; }
        public int PickRadius { get; set; }
    }
}
