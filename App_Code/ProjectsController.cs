using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class ProjectsController : ApiController
{
    private Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();


    [Route("api/projects/{id?}/{date_start?}/{date_finish?}")]

    // GET api/<controller>
    public IEnumerable<string> GetProjects([FromUri]int? id=null, [FromUri]DateTime? date_start=null, [FromUri] DateTime? date_finish=null)
    {
        List<string> projects = new List<string>();
        if (id == null && date_start == null && date_finish == null)
        {
            var hours_per_project = db.Logs.GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var proj in hours_per_project)
            {
                var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
                if (project_name != null)
                {
                    projects.Add(project_name);
                    projects.Add(proj.Amount.ToString());
                }

            }
        }
       
        if (id == null && date_start != null&&date_finish!=null)
        {
            var hours_per_project = db.Logs.Where(l => l.date >= date_start && l.date <= date_finish).GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var proj in hours_per_project)
            {
                var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
                if (project_name != null)
                {
                    projects.Add(project_name);
                    projects.Add(proj.Amount.ToString());
                }

            }

        }

        if (id != null && date_start == null && date_finish == null)
        {
            var hours_per_project = db.Logs.Where(l => l.id_user == id).GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var proj in hours_per_project)
            {
                var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
                if (project_name != null)
                {
                    projects.Add(project_name);
                    projects.Add(proj.Amount.ToString());
                }

            }
        }

        if (id != null && date_start != null && date_finish != null)
        {
            var hours_per_project = db.Logs.Where(l => l.id_user == id && l.date >= date_start && l.date <= date_finish).GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var proj in hours_per_project)
            {
                var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
                if (project_name != null)
                {
                    projects.Add(project_name);
                    projects.Add(proj.Amount.ToString());
                }

            }
        }

            return projects;
    }

    // http://localhost:8996/api/projects?id=9&date_start=2017-01-01&date_finish=2017-05-15 
}
