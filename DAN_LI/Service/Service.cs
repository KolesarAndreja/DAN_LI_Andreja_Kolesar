using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI.Service
{
    class Service
    {
        #region Get user, patient, doctor
        public static tblUser GetUserByUsernameAndPsw(string username, string password)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    tblUser result = (from x in context.tblUsers where x.username == username && x.password == password select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public static tblDoctor isDoctor(tblUser e)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    tblDoctor result = (from x in context.tblDoctors where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public static tblPatient isPatient(tblUser e)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    tblPatient result = (from x in context.tblPatients where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region GET LISTS
        public static List<vwDoctor> GetDoctorsList()
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    List<vwDoctor> list = new List<vwDoctor>();
                    list = (from x in context.vwDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD USER
        public static tblUser AddUser(tblUser user)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    if (user.userId == 0)
                    {
                        //add 
                        tblUser newUser = new tblUser();
                        newUser.username = user.username;
                        newUser.password = user.password;
                        newUser.fullname = user.fullname;
                        newUser.JMBG = user.JMBG;
                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        user.userId = newUser.userId;
                        return user;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD DOCTOR
        public static tblDoctor AddDoctor(tblDoctor doctor)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    if (doctor.doctorId == 0)
                    {
                        //add 
                        tblDoctor newDoctor = new tblDoctor();
                        newDoctor.account = doctor.account;
                        newDoctor.userId = doctor.userId;
                        context.tblDoctors.Add(newDoctor);
                        context.SaveChanges();
                        doctor.doctorId = newDoctor.doctorId;
                        return doctor;
                    }
                    return doctor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion


        #region ADD PATIENT
        public static tblPatient AddPatient(tblPatient patient)
        {
            try
            {
                using (dbMedicalInstitutionEntities context = new dbMedicalInstitutionEntities())
                {
                    if (patient.patientId == 0)
                    {
                        //add 
                        tblPatient newPatient = new tblPatient();
                        newPatient.userId = patient.userId;
                        newPatient.cardNumber = patient.cardNumber;
                        newPatient.doctorId = patient.doctorId;
                        context.tblPatients.Add(newPatient);
                        context.SaveChanges();
                        patient.patientId = newPatient.patientId;
                        return patient;
                    }
                    return patient;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion
    }
}
