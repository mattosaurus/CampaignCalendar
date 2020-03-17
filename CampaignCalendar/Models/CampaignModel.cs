using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignCalendar.Models
{
    public class CampaignModel
    {
        public int Id { get; set; }

        public CampaignStatus Status { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    public enum CampaignStatus
    {
        Todo,
        Started,
        Completed
    }
}
