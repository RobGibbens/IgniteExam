using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsAppService.DataObjects;
namespace QuestionsAppService
{
    static class DataFactory
    {
        public static List<ExamQuestion> Questions
        {
            get
            {
                return new List<ExamQuestion>
            {
                new ExamQuestion { Id = Guid.NewGuid().ToString(),
                     Question = "Xamarin.Forms is a great choice when developing mobile business applications or prototypes.",
                     Answer = true,
                     Explanation = "Xamarin.Forms is ideal for creating line-of-business applications and can be used to rapidly create UIs that work on all supported plattforms."},
                new ExamQuestion { Id = Guid.NewGuid().ToString(),
                    Question = "Xamarin.Forms is a great choice when you're required to follow pixel-perfect mockups or leverage a lot of platform specific features.",
                    Answer = false,
                    Explanation = "To create highly customized or pixel perfect UIs, additional customization work is required on each platform can may, in some cases, substantially increase development time." },
                new ExamQuestion { Id = Guid.NewGuid().ToString(),
                    Question = "For the purposes of testing an application, simulators are just as good as physical devices.",
                    Answer = false,
                    Explanation = "Simulator features and performance can vary greatly from physical devices." },
                new ExamQuestion { Id = Guid.NewGuid().ToString(),
                    Question = "When using Xamarin.Forms, your Android head project should always target the latest Android framework avaliable.",
                    Answer = true,
                    Explanation = "Xamarin.Forms is developed and tested against the latest stable Android framework.  You should always keep your Android development tools up to date." },
                new ExamQuestion { Id = Guid.NewGuid().ToString(),
                    Question = "When developing an app using Xamarin.Forms, the application will look identical on all supported platforms.",
                    Answer = false,
                    Explanation = "Xamarin.Forms creates native views on each platform; the UI of your application will use the native visual styling on each platform." }
            };
            }
        }
    }
}

