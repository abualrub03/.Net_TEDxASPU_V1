using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITeam
    {
        public bool spDelFromtblTeam(int Id);

        public bool UpdateNameAndDetails(int Id, string name, string details);
        public List<Entities.Team> getAllTeamMembers();
        public List<Entities.Team> getAMember(int id);
        public bool addTeamMember(IFormFile imageFile, Entities.Team Team);
        public Entities.Team getTeamMemberByInfo(string email, string password);
    }
}
