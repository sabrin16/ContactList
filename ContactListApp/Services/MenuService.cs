namespace ContactListApp.Services
{
    class MenuService
    {
        private ContactService contactService;
        public MenuService(ContactService contactService)
        {
            this.contactService = contactService;
        }
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till kontaktlistan!");
                Console.WriteLine("1. Lista alla kontakter");
                Console.WriteLine("2. Lägg till en kontakt");
                Console.WriteLine("3. Avsluta");
                Console.Write("Välj ett alternativ: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        contactService.listContacts();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        contactService.AddContact();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("You want to close the app? (y/n)");
                        string response = Console.ReadLine().ToLower();
                        
                        if (response == "y")
                        {
                            contactService.saveContacts();
                            Environment.Exit(0);
                        }else if (response != "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter either y or n");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter either 1 or 2 or 3");
                        break;
                }
            }
        }
    }
}
