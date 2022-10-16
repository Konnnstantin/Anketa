using System.Text;
{
    var User = UserEnter();
    ShowAnketa(User.Name, User.LastName, User.Age, User.Color, User.Pets);
}
static (string Name, string LastName, byte Age, string HasPet, string[] Color, string[] Pets) UserEnter()
{
    (string Name, string LastName, byte Age, string HasPet, string[] Color, string[] Pets) User;


    int name;
    do
    {
        Console.WriteLine("Введите свое имя");
        User.Name = Console.ReadLine();
    } while (User.Name.Length == 0 || int.TryParse(User.Name, out name) == true);

    int lastname;
    do
    {
        Console.WriteLine("Введите свою фамилию");
        User.LastName = Console.ReadLine();
    } while (User.LastName.Length == 0 || int.TryParse(User.LastName, out lastname) == true);

    string age;
    byte intage;
    do
    {
        Console.WriteLine("Введите свой возвраст цифрами");
        age = Console.ReadLine();
    } while (ChekNum(age, out intage));

    User.Age = intage;

    Console.WriteLine("Если у вас есть питомцы то введите да");
    User.HasPet = Console.ReadLine();

    string res;
    byte Count = 0;

    if (User.HasPet == "да" || User.HasPet == "Да")
    {
        do
        {
            Console.WriteLine("Введите количество питомцев");
            res = Console.ReadLine();
        } while (ChekNum(res, out Count));
        Console.WriteLine("Введите клички своих питомцев");

    }
    else
    {
        Console.WriteLine("Нету питомцев");
    }

    User.Pets = ShowArray(Count);

    do
    {
        Console.WriteLine("Заполните кол-во любимых цветов");
        res = Console.ReadLine();

    } while (ChekNum(res, out Count));
    Console.WriteLine("Введите название любимых цветов");
    User.Color = ShowArray(Count);

    return User;

}
static string[] ShowArray(int Count)
{

    string[] NameArrays = new string[Count];

    for (int i = 0; i < NameArrays.Length; i++)
    {
        string str = Console.ReadLine();
        NameArrays[i] = str;
    }

    return NameArrays;
}
static void ShowAnketa(string name, string lastname, byte age, string[] color, string[] pets)
{

    StringBuilder showcolor = new StringBuilder(color.Length);
    for (int i = 0; i < color.Length; i++)
    {
        showcolor.AppendLine(color[i]);
    }

    StringBuilder showpets = new StringBuilder(pets.Length);
    for (int j = 0; j < pets.Length; j++)
    {
        showpets.AppendLine(pets[j]);
    }
    Console.WriteLine($"\nВаше имя:{name} \n\nВаша фамилия:{lastname} \n\nВаш возраст:{age} \n\nВаших питомцев зовут:{showpets}\nВаши любимые цвета:{showcolor}");
}
static bool ChekNum(string number, out byte corrnumber)
{
    if (byte.TryParse(number, out byte intnum))
    {
        if (intnum > 0)
        {
            corrnumber = intnum;
            return false;
        }
    }
    {
        corrnumber = 0;
        return true;
    }
}
