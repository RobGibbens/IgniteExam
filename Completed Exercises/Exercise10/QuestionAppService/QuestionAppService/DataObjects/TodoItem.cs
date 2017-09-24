using Microsoft.Azure.Mobile.Server;

namespace QuestionAppService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}