namespace BankSystem.Shared
{
    public class Client
    {
        public int clientId { get; set; }
        public int accountNumber { get; set; }
        public int personId { get; set; }
        public int pinCode { get; set; }
        public decimal balance { get; set; }
        public Client()
        {
            clientId = -1;
            accountNumber = 0;
            personId = -1;
            pinCode = 0;
            balance = 0;
        }

        public Client(int clientId, int accountNumber, int personId, int pinCode, decimal balance)
        {
            this.clientId = clientId;
            this.accountNumber = accountNumber;
            this.personId = personId;
            this.pinCode = pinCode;
            this.balance = balance;
        }

    }
}
