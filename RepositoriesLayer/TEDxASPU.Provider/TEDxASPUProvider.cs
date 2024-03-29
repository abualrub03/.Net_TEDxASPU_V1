﻿using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
namespace TEDxASPU.Provider
{
    public class TEDxASPUProvider
    {
        public bool SignUpNewUser(Entities.Account acc)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@honorific", Value =  acc.honorific },
                new SqlParameter{ ParameterName = "@firstName", Value = acc.firstName },
                new SqlParameter{ ParameterName = "@lastName", Value =  acc.lastName},
                new SqlParameter{ ParameterName = "@gender", Value =  acc.gender },
                new SqlParameter{ ParameterName = "@age", Value =acc.age},
                new SqlParameter{ ParameterName = "@emailAddress", Value =  acc.emailAddress },
                new SqlParameter{ ParameterName = "@phoneNumber", Value =  acc.phoneNumber },
                new SqlParameter{ ParameterName = "@password", Value = acc.password },
                new SqlParameter{ ParameterName = "@userName", Value =  acc.userName },
                new SqlParameter{ ParameterName = "@role", Value = acc.role },
            };
            return DAL.ExecuteNonQuery("spSignUpNewUser");
        }


        public Entities.Account SignInNewUser(Entities.Account acc) 
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter>
                {
                    new SqlParameter{ ParameterName = "@userName", Value = acc.userName },
                    new SqlParameter{ ParameterName = "@password", Value = acc.password }
            };

            return DAL.ExecuteReader<Entities.Account>("spSignInNewUser").FirstOrDefault();
        }

        /*
        public bool spDelFromtblTeam(int Id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  Id }
            };
            return DAL.ExecuteNonQuery("spDelFromtblTeam");
        }
        public bool UpdateNameAndDetails(int Id, string name, string details)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  Id },
                new SqlParameter{ ParameterName = "@Name", Value =  name },
                new SqlParameter{ ParameterName = "@Details", Value =  details },
            };
            return DAL.ExecuteNonQuery("spUpdateNameAndDetails");
        }
        public List<Entities.Team> getAllTeamMembers()
        {
            using var DAL = new DataAccess.DataAccessLayer();
            return DAL.ExecuteReader<Entities.Team>("spSelectAllTblTeam");
        }
        public List<Entities.Team> getAMember(int id)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@Id", Value =  id }
            };
            return DAL.ExecuteReader<Entities.Team>("spSelectTblTeamWhere");
        }
        public bool addTeamMember(IFormFile imageFile, Entities.Team Team)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var imageStream = imageFile.OpenReadStream())
                {
                    long imageLength = imageFile.Length;
                    byte[] imageData = new byte[imageLength];

                    int bytesRead = imageStream.Read(imageData, 0, (int)imageLength);

                    if (bytesRead != imageLength)
                    {
                        return false;
                    }
                    Team.ImageData = imageData;
                    Team.ImageName = imageFile.FileName;
                    Team.ImageContentType = imageFile.ContentType;
                    using var DAL = new DataAccess.DataAccessLayer();
                    DAL.Parameters = new List<SqlParameter> {
                        new SqlParameter{ ParameterName = "@Name", Value =  Team.Name },
                        new SqlParameter{ ParameterName = "@Details", Value =  Team.Details },
                        new SqlParameter{ ParameterName = "@Email", Value =  Team.Email },
                        new SqlParameter{ ParameterName = "@Password", Value =  Team.Password },
                        new SqlParameter{ ParameterName = "@PhoneNumber", Value =  Team.PhoneNumber},
                        new SqlParameter{ ParameterName = "@Role", Value =  Team.Role },
                        new SqlParameter{ ParameterName = "@encryptedPassword", Value =  Team.encryptedPassword },
                        new SqlParameter{ ParameterName = "@encryptrdId", Value =  Team.EncryptedId },
                        new SqlParameter{ ParameterName = "@IdSalt", Value =  Team.IdSalt},
                        new SqlParameter{ ParameterName = "@PasswordSalt", Value =  Team.PasswordSalt },
                        new SqlParameter{ ParameterName = "@ImageData", Value =  Team.ImageData },
                        new SqlParameter{ ParameterName = "@ImageName", Value =  Team.ImageName},
                        new SqlParameter{ ParameterName = "@ImageContentType", Value =  Team.ImageContentType },
                    };
                    Team.Email = "sddsfdsf";
                    Team.Password = "sasdfdsf";
                    Team.PhoneNumber = "1234567890";
                    Team.EncryptedId = "22222";
                    Team.IdSalt = "1234567890";
                    Team.encryptedPassword = "safsaf";
                    Team.PasswordSalt = "fsdfds";
                    Team.Role = "Admin";
                    Team.EncryptedId = "232344234";
                    return DAL.ExecuteNonQuery("spInsertIntoTblTeam");
                }
            }
            else
            {
                return false;
            }


        }
        public Entities.Team getTeamMemberByInfo(string email, string password)
        {
            using var DAL = new DataAccess.DataAccessLayer();
            DAL.Parameters = new List<SqlParameter>
                {
                    new SqlParameter{ ParameterName = "@Email", Value = email },
                    new SqlParameter{ ParameterName = "@Password", Value = password }
            };

            return DAL.ExecuteReader<Entities.Team>("spGetTeamMemberbyEmailAndPassword").FirstOrDefault();
        }

        */
    }
}
