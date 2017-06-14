using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class ActivitiesController : ApiController
{
    private Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();


    [Route("api/activities/{id?}/{date_start?}/{date_finish?}")]

    public IEnumerable<string> GetActivities([FromUri]int? id = null, [FromUri]DateTime? date_start = null, [FromUri] DateTime? date_finish = null)
    {
        List<string> activities = new List<string>();

        if (id == null && date_start == null && date_finish == null)
        {
            var hours_per_activity = db.Logs.GroupBy(l => l.id_activity_type).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var act in hours_per_activity)
            {
                var activity_name = (from a in db.ActivityTypes where a.id == act.Name select a.name).FirstOrDefault();
                if (activity_name != null)
                {
                    activities.Add(activity_name);
                    activities.Add(act.Amount.ToString());
                }

            }
           
        }

        if (id != null && date_start == null && date_finish == null)
        {
            var hours_per_activity = db.Logs.Where(l => l.id_user == id).GroupBy(l => l.id_activity_type).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var act in hours_per_activity)
            {
                var activity_name = (from a in db.ActivityTypes where a.id == act.Name select a.name).FirstOrDefault();
                if (activity_name != null)
                {
                    activities.Add(activity_name);
                    activities.Add(act.Amount.ToString());
                }

            }
        }

        if(id == null && date_start != null && date_finish != null)
        {
            var hours_per_activity = db.Logs.Where(l => l.date >= date_start && l.date <= date_finish).GroupBy(l => l.id_activity_type).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var act in hours_per_activity)
            {
                var activity_name = (from a in db.ActivityTypes where a.id == act.Name select a.name).FirstOrDefault();
                if (activity_name != null)
                {
                    activities.Add(activity_name);
                    activities.Add(act.Amount.ToString());
                }

            }
        }

        if (id != null && date_start != null && date_finish != null)
        {
            var hours_per_activity = db.Logs.Where(l => l.id_user == id &&l.date >= date_start && l.date <= date_finish).GroupBy(l => l.id_activity_type).Select(a => new { Amount = a.Sum(b => b.hours), Name = a.Key }).ToList();
            foreach (var act in hours_per_activity)
            {
                var activity_name = (from a in db.ActivityTypes where a.id == act.Name select a.name).FirstOrDefault();
                if (activity_name != null)
                {
                    activities.Add(activity_name);
                    activities.Add(act.Amount.ToString());
                }

            }
        }

        return activities;
    }
}
