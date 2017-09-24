using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using QuestionAppService.Models;
using QuestionAppService.DataObjects;

namespace QuestionAppService.Controllers
{
    public class QuestionsController : TableController<ExamQuestion>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ExamQuestion>(context, Request);
        }

        // GET tables/Questions
        public IQueryable<ExamQuestion> GetAllExamQuestion()
        {
            return Query(); 
        }

        // GET tables/Questions/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ExamQuestion> GetExamQuestion(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Questions/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ExamQuestion> PatchExamQuestion(string id, Delta<ExamQuestion> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Questions
        public async Task<IHttpActionResult> PostExamQuestion(ExamQuestion item)
        {
            ExamQuestion current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Questions/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteExamQuestion(string id)
        {
             return DeleteAsync(id);
        }
    }
}
