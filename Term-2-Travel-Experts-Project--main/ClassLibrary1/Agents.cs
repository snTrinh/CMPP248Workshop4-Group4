using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class constructor for ProductsDB
 * Created by Susan Trinh on January 26, 2021
 */
namespace AgentsData
{
    public class Agents
    {
        public int AgentId { get; set; }
        public string AgtFirstName { get; set; }
        public string AgtMiddleInitial { get; set; }
        public string AgtLastName { get; set; }
        public string AgtBusPhone { get; set; }
        public string AgtEmail { get; set; }
        public string AgtPosition { get; set; }
        public int AgencyId { get; set; }
    }
}
