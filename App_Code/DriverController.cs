using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class DriverController : ApiController
{
    private Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();

    [Route("api/driver/id")]

    // GET api/<controller>
    public IEnumerable<string> GetProjects(int id)
    {
        List<string> projects = new List<string>();
        var hours_per_project = db.Log_driver.Where(l => l.id_user == id).GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
        foreach (var proj in hours_per_project)
        {
            var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
            if (project_name != null)
            {
                projects.Add(project_name);
                projects.Add(proj.Amount.ToString());
            }

        }
        return projects;
    }

    [Route("api/driver/id/date_start/date_finish")]

    // GET api/<controller>
    public IEnumerable<string> GetProjects(int id, DateTime date_start, DateTime date_finish)
    {
        List<string> projects = new List<string>();
        var hours_per_project = db.Log_driver.Where(l => l.id_user == id && l.date >= date_start && l.date <= date_finish).GroupBy(l => l.id_project).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
        foreach (var proj in hours_per_project)
        {
            var project_name = (from p in db.Projects where p.id == proj.Name select p.name).FirstOrDefault();
            if (project_name != null)
            {
                projects.Add(project_name);
                projects.Add(proj.Amount.ToString());
            }

        }
        return projects;
    }

}
