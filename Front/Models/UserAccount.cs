namespace Front.Models
{
    public class UserAccount
    {
        public int AccountNumber { get; set; }
        public string Alias { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string? CBU { get; set; } //In case of CryptoCurrency, is null.
        public string? UUID { get; set; } //In case of fiduciary, is null.
    }
}
