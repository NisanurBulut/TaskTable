using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Business.Interfaces;

namespace TaskTable.Web.TagHelpers
{
    [HtmlTargetElement("GetTaskWithAppUserId")]
    public class AppUserIdTagHelper : TagHelper
    {
        private readonly ITaskService _taskService;
        public AppUserIdTagHelper(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tasks = _taskService.GetAllTasksWithUserId(AppUserId);
            int finisedTaskCount = tasks.Where(a => a.State).Count();
            int unFinisedTaskCount = tasks.Where(a => !a.State).Count();
            string htmlString = $"<p>Tamamlanan görev sayısı : {finisedTaskCount}</p>" +
                $"</br><p>Devam eden görev sayısı : {unFinisedTaskCount}</p>";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
