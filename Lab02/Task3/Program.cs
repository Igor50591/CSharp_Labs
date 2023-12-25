namespace Task3
{
    public class program
    {
        public class DocumentWorker
        {
            public void OpenDocument()
            {
                Console.WriteLine("Документ открыт");
            }
            public virtual void EditDocument()
            {
                Console.WriteLine("Редактирование документа доступно в версии Pro");
            }
            public virtual void SaveDocument()
            {
                Console.WriteLine("Сохранение документа доступно в версии Pro");
            }
        }
        public class ProDocumentWorker: DocumentWorker
        {
            public override void EditDocument()
            {
                Console.WriteLine("Документ отредактирован");
            }
            public override void SaveDocument()
            {
                Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");   
            }
        }

        public class ExpertDocumentWorker : ProDocumentWorker
        {
            public override void SaveDocument()
            {
                Console.WriteLine("Документ сохранен в новом формате");
            }

        }

        public static void Main()
        {
            const string proKey = "757-2573155";
            const string expKey = "100-1208613";
            Console.Write("Введите ключ: ");
            string key = Console.ReadLine();
            DocumentWorker dw;
            switch (key)
            {
                case proKey:
                    dw = new ProDocumentWorker();
                    break;
                case expKey:
                    dw = new ExpertDocumentWorker();
                    break;
                case "":
                    dw = new DocumentWorker();
                    break;
                default:
                    dw = new DocumentWorker();
                    break;
            }
            dw.OpenDocument();
            dw.EditDocument();
            dw.SaveDocument();
        }
    }
}

