using Alit.Marker.Service.Update.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Alit.Marker.Service.Update.Controllers
{
    public class CheckUpdateController : ApiController
    {
        public IHttpActionResult GetLatestVersionNumber()
        {
            PostResultViewModel<SoftwareVersionViewModel> result = new PostResultViewModel<SoftwareVersionViewModel>();
            try
            {
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    var ver = db.tblSoftwareVersions.OrderByDescending(r => r.SoftwareVersionID).FirstOrDefault();
                    if (ver != null)
                    {
                        result.Success = true;
                        result.ResultObject = new SoftwareVersionViewModel()
                        {
                            SoftwareVersionID = ver.SoftwareVersionID,
                            MajorVersion = ver.GUIVersionMajor,
                            MinorVersion = ver.GUIVersionMinor
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        public IHttpActionResult GetNextRequiredFileVersions(int? MajorVersion, int? MinorVersion)
        {
            Model.PostResultViewModel<string[]> result = new Model.PostResultViewModel<string[]>();
            try
            {
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    var LastVersion = db.tblSoftwareVersions.OrderByDescending(r => r.SoftwareVersionID).FirstOrDefault();
                    var ver = db.tblSoftwareVersions.Where(r => r.SoftwareVersionID == LastVersion.SoftwareVersionID ||
                                (r.GUIVersionMajor > MajorVersion || (r.GUIVersionMajor == MajorVersion && r.GUIVersionMinor > MinorVersion) && r.FilesDownloadsRequired));
                    if (ver != null)
                    {
                        string[] res = ver.Select(r => r.GUIVersionMajor.ToString() + "." + r.GUIVersionMinor.ToString()).ToArray();
                        result.Success = true;
                        result.ResultObject = res;
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        public IHttpActionResult GetNextVersions(int? MajorVersion, int? MinorVersion)
        {
            PostResultViewModel<List<SoftwareVersionViewModel>> result = new PostResultViewModel<List<SoftwareVersionViewModel>>();
            try
            {
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    var LastVersion = db.tblSoftwareVersions.OrderByDescending(r => r.SoftwareVersionID).FirstOrDefault();
                    var ver = db.tblSoftwareVersions.Where(r => r.SoftwareVersionID == LastVersion.SoftwareVersionID ||
                                (r.GUIVersionMajor > MajorVersion || (r.GUIVersionMajor == MajorVersion && r.GUIVersionMinor > MinorVersion)));
                    if (ver != null)
                    {
                        List<SoftwareVersionViewModel> res = ver.Select(r => new SoftwareVersionViewModel()
                        {
                            SoftwareVersionID = r.SoftwareVersionID,
                            MajorVersion = r.GUIVersionMajor,
                            MinorVersion = r.GUIVersionMinor,
                            RequiredFileDownload = r.FilesDownloadsRequired,
                        }).ToList();

                        result.Success = true;
                        result.ResultObject = res;
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        public IHttpActionResult GetDatabaseUpdateScript(int? MajorVersion, int? MinorVersion)
        {
            MajorVersion = MajorVersion ?? 0;
            MinorVersion = MinorVersion ?? 0;
            Model.PostResultViewModel<IEnumerable<DatabaseUpdateScriptViewModel>> result = new Model.PostResultViewModel<IEnumerable<DatabaseUpdateScriptViewModel>>();
            try
            {
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    var ver = from u in db.tbldbUpdateScripts
                              join r in db.tblSoftwareVersions on u.SoftwareVersionID equals r.SoftwareVersionID
                              where (r.GUIVersionMajor > MajorVersion || (r.GUIVersionMajor == MajorVersion && r.GUIVersionMinor > MinorVersion))
                              select new Model.DatabaseUpdateScriptViewModel
                              {
                                  SoftwareVersionID = u.SoftwareVersionID,
                                  dbUpdateScriptID = u.UpdateScriptID,
                                  MajorVersion = r.GUIVersionMajor,
                                  MinorVersion = r.GUIVersionMinor,
                                  ScriptTitle = u.dbScriptTitle,
                                  dbScript = u.dbScript,
                              };

                    if (ver != null)
                    {
                        result.Success = true;
                        result.ResultObject = ver.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                ex = CommonFunctions.GetFinalError(ex);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return Ok(result);
        }

        public IHttpActionResult GetFTPAddress()
        {
            Model.PostResultViewModel<string[]> result = new Model.PostResultViewModel<string[]>();
            result.Success = true;
            result.ResultObject = new string[] { "ftp://ftp.site4now.net/markerupdate/Updatefiles/", "alittech-001", "786Sakina52" };
            return Ok(result);
        }
    }
}