namespace eXam
{
    [Newtonsoft.Json.JsonObject(Title = "questions")]
    public class QuizQuestion
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public bool Answer { get; set; }
        public string Explanation { get; set; }
    }

}