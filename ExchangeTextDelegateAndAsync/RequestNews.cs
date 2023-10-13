namespace ExchangeTextDelegateAndAsync
{
    public class RequestNews
    {
        public delegate void Request(string news);

        public Request? requestHandler { get; set; }

        private List<string> _news = new List<string>()
        {
            "Папа римский купил доллар",
            "Русская мафия продаёт евро",
            "Евросоюз выпустил новые купюры",
            "Нефть подскачила",
            "Страна закрывает границы",
            "Новости лучше чем новости",
            "Самолёт с долларами упал в Евросоюзе",
            "Евро обошёл доллар",
            "Америка продаёт все свои алмазы",
            "Взрыв на атомной станции",
            "Новость, которую лучше не слышать"
        };

        public void GetNews()
        {
            while (true)
            {
                int index = (new Random()).Next(11);


                requestHandler?.Invoke(_news[index]);

                Thread.Sleep(new Random().Next(5000, 10000));

            }
        }
    }
}
