namespace CryptoVue.Dtos
{
    public class VestingScheduleDTO
    {
        public string Round { get; set; }
        public int Tokens { get; set; }
        public double Percentage { get; set; }
        public int TGEUnlock { get; set; }
        public int Cliff { get; set; }
        public DateTime UnlockStart { get; set; }
        public DateTime UnlockEnd { get; set; }
        public string Summary { get; set; }

    }
}
