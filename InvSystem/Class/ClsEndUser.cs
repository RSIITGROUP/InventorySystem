using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvSystem.Class
{
    public class ClsEndUser
    {
        private string nik;
        private string name;
        private string email;
        private string region;
        private string department;
        private string mobileno;
        private string sapusrid;
        private string peachusrid;
        private string aqmusrid;
        private string talentausrid;
        private string remark;

        public string NIK
        {
            get { return nik; }
            set { nik = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Region
        {
            get { return region; }
            set { region = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public string MobileNo
        {
            get { return mobileno; }
            set { mobileno = value; }
        }
        public string SAPUsrId
        {
            get { return sapusrid; }
            set { sapusrid = value; }
        }
        public string PeachUsrId
        {
            get { return peachusrid; }
            set { peachusrid = value; }
        }
        public string AQMUserId
        {
            get { return aqmusrid; }
            set { aqmusrid = value; }
        }
        public string TalentaUsrId
        {
            get { return talentausrid; }
            set { talentausrid = value; }
        }
        public string Remarks
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}