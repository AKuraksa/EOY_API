namespace EOY_API.Tables
{
    public class Worker
    {
        public Guid ID { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public string WorkerFirstName { get; set; }

        public string WorkerLastName { get; set; }

        public string AuthentificatorID {get; set;}

        public string? LoggedWorkplace { get;set;}


    }
}
