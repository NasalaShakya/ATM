using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
     
    public cardHolder(string cardnum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardnum; 
        this.pin = pin; 
        this.firstName = firstName; 
        this.lastName = lastName;
        this.balance = balance;
    }
    public string getNum()
    {
        return cardNum;
    }
        public int getpin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    
    public void setpin(int newPin)
        { pin = newPin; }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("1.Deposite");
            Console.WriteLine("2.withdraw");
            Console.WriteLine("3.show balance");
            Console.WriteLine("4.exit");
        }

        void deposit(cardHolder currentuser)
        {
            Console.WriteLine("how much $$ would you like to deposite?");
            double deposit = Double.Parse(Console.ReadLine());
            currentuser.setBalance(deposit+currentuser.getBalance());
            Console.WriteLine("thank you for your $$. Your new balance is: " + currentuser.getBalance());

        }

        void withdraw(cardHolder currentuser)
        {
            Console.WriteLine("how much $$ would you like to with draw:");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentuser.getBalance() > withdraw)
            {
                Console.WriteLine("insufficient balance");
            }
            else
            {
                currentuser.setBalance(currentuser.getBalance() - withdraw);
                Console.WriteLine("you are good to go");
            }
        }
        void balance(cardHolder currentuser)
        {
            Console.WriteLine("current balance:" + currentuser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1", 2222, "john", "browns", 55000.00));
        cardHolders.Add(new cardHolder("2", 1234, "elsa", "den", 790.00));

        Console.WriteLine("welcome");
        Console.WriteLine("please insert your debit card");
        string debitCardNum = "";
        cardHolder currentuser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentuser= cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentuser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("card not recognized. Please try again");
                }
            }
            catch { Console.WriteLine("card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                
                if (currentuser.getpin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin . Please try again");
                }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }
        Console.WriteLine("Welcome"+currentuser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            { 
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if(option == 1) { deposit(currentuser); }
            else if(option == 2) { withdraw(currentuser); }
            else if(option == 3) { balance(currentuser); }
            else if(option==4) { break; }

        }
        while (option != 4);
        Console.WriteLine("have a nice day. Thank You");


    }
    
}
