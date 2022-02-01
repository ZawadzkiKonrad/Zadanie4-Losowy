
using Zadanie4_Losowy;

String[] imie = { "Ania", "Kasia", "Basia", "Zosia" };
String[] nazwisko = { "Kowalska", "Nowak" };



List<User> listToSave = new List<User>();
Random random = new Random();

for (int i = 0; i < 100; i++)
{
    User user = new User();
    user.LP = i + 1;

    user.Imie = imie[random.Next(0, 3)];
    user.Nazwisko = nazwisko[random.Next(0, 2)];
    user.Rok = random.Next(1990, 2000);
    listToSave.Add(user);

}

void SaveUsers(List<User> listToSave)
{
    DateTime thisDay = DateTime.Now;
    var date = thisDay.ToString().Replace("-", "_").Replace(":","_").Replace(" ","-");
    StreamWriter writer = new StreamWriter(@"C:\test\users-"+date+".csv", false);
    if (writer != null)
    {
        writer.WriteLine(@"LP;IMIE;NAZWISKO;ROK");//Pierwszy wiersz to dodanie nazw kolumn
        foreach (User user in listToSave)
        {
            writer.WriteLine(String.Format(@"{0};{1};{2};{3}", user.LP, user.Imie, user.Nazwisko, user.Rok));
        }
        writer.Close();
    }
}
SaveUsers(listToSave);
