using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsApplicationCollection
    {
        List<clsApplication> mApplicationList = new List<clsApplication>();
        clsApplication mThisApplication = new clsApplication();
        public List<clsApplication> ApplicationList 
        {
            get
            {
                return mApplicationList;
            }
            set
            {
                mApplicationList = value;
            }
        }
        public int Count
        { 
            get
            {
                return mApplicationList.Count;
            }
                
            set
            {
                
            }
        }
        public clsApplication ThisApplication { get; set; }

        public clsApplication ThisAddress {
            get
            {
                return mThisApplication;
            }
            set
            {
                mThisApplication = value;
            }
        } 

        /*public clsApplicationCollection()
        {
            clsApplication TestItem = new clsApplication();

            TestItem.StaffId = 1;
            TestItem.ApplicantName = "Test";
            TestItem.EmailAddress = "Test";
            TestItem.ContactNumber = "Test";
            TestItem.PositionApplied = "Test";

            mApplicationList.Add(TestItem);
            TestItem = new clsApplication(); 

            TestItem.StaffId = 1;
            TestItem.ApplicantName= "Test";
            TestItem.ContactNumber= "Test";
            TestItem.EmailAddress= "Test";
            TestItem.PositionApplied= "Test";
            mApplicationList.Add(TestItem);
        }*/

        public clsApplicationCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("dbo.jobApplication_selectAll");
            RecordCount = DB.Count;

            while (Index < RecordCount)
            {
                clsApplication AnApplication = new clsApplication();
                AnApplication.StaffId = Convert.ToInt32(DB.DataTable.Rows[Index]["StaffId"]);
                AnApplication.AdminId = 1;
                AnApplication.ApplicantName = Convert.ToString(DB.DataTable.Rows[Index]["ApplicantName"]);
                AnApplication.ContactNumber = Convert.ToString(DB.DataTable.Rows[Index]["ContactNumber"]);
                AnApplication.EmailAddress = Convert.ToString(DB.DataTable.Rows[Index]["EmailAddress"]);
                AnApplication.PositionApplied = Convert.ToString(DB.DataTable.Rows[Index]["PositionApplied"]);

                mApplicationList.Add(AnApplication);
                Index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@StaffId", mThisApplication.StaffId);
            DB.AddParameter("@AdminId", 1);
            DB.AddParameter("@ApplicantName", mThisApplication.ApplicantName);
            DB.AddParameter("@ContactNumber", mThisApplication.ContactNumber);
            DB.AddParameter("@EmailAddress", mThisApplication.EmailAddress);
            DB.AddParameter("@PositionApplied", mThisApplication.PositionApplied);

            if (mThisApplication.Resume != null)
            {
                DB.AddParameter("@Resume", mThisApplication.Resume);

            }

            return DB.Execute("dbo.jobApplication_create");
        }
    }
}