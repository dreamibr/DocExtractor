// Project: DocExtractor Utility for SharePoint
// By Eng. Ibrahem A. Ibraheem 2012
// v1.0.0.0

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using System.Windows.Forms;
using System.IO;



namespace DocExtractor
{
    class QueryBuilder
    {
        private string Query;
        private List<string> Conditions;

        // constructor
        public QueryBuilder()
        {
            Query = String.Empty;
            Conditions = new List<string>();
        }

        public void addCondition(string condition)
        {
            Conditions.Add(condition);// without op
        }

        public void addCondition(string condition, string Op)
        {
            Conditions.Add(Op);// AND or OR with the previous condition
            Conditions.Add(condition);
        }

        public string constructQuery()
        {
            if (Conditions.Count > 0)
            {
                // Conditions[x]
                // even 0,2,4,6,.. index: actual conditions
                // odd  1,3,5,7,.. index: AND or OR ops

                Query = Conditions[0] as string;// first condition
                
                // no tagging if only 1 condition available
                if (Conditions.Count > 1)
                {
                   for (int i = 2; i < Conditions.Count; i=i+2)
                    {
                        if (Conditions[i - 1] == "AND")
                        {
                            Query = @"<And>" + Query + Conditions[i] + @"</And>";
                        }
                        
                        else if (Conditions[i - 1] == "OR")
                        {
                            Query = @"<Or>" + Query + Conditions[i] + @"</Or>";
                        }
                    }
                }

                Query = @"<Where>" + Query.Trim() + @"</Where>";             
            }
            return Query;
        }
    }

    class DocExtractor
    {
        public string SiteUrl;
        public string WebName;
        public string LibTitle;

        // for search-user
        public string UserDisplayName;
        public string UserLoginName;
        private SPUser user;

        public List<string> DocTypes;
        public string CusDocType;
        public int DocSize;
        public string TextinName;

        public enum FilterUser
        {
            AllUsers,
            SpecificCreatedByUser,
            SpecifiModifiedByUSer
        };
        public FilterUser UserSelection;

        public enum FilterType
        {
            AllTypes,
            MSOffice,
            AdobePDF,
            Images,
            Videos,
            Audio,
            Web,
            Custom
        };
        public FilterType DocTypeSelection;

        public enum FilterDate
        {
            AllDates,
            SpecificCreatedDate,
            SpecificModifiedDate
        };
        public FilterDate DocDateSelection;

        public DateTime DocBeginDate;
        public DateTime DocEndDate;

        public enum FilterText
        {
            AnyText,
            SpecificText
        };
        public FilterText NameTextSelection;

        // constructor
        public DocExtractor()
        {
            SiteUrl = "";
            WebName = "";
            LibTitle = "";

            UserSelection = FilterUser.AllUsers; // be default

            UserDisplayName = "";
            UserLoginName = "";

            // populate file types
            DocTypes = new List<string>();
            DocTypes.Add("All Types");
            DocTypes.Add("MS Office: .docx, .xlsx, .pptx");
            DocTypes.Add("Adobe .pdf");
            DocTypes.Add("Images: .jpg, .bmp, .png");
            DocTypes.Add("Videos: .wmv, .mpg, .avi, .mp4");
            DocTypes.Add("Audio: .mp3, .wav, .wma");
            DocTypes.Add("Web: .htm, .aspx, .xml");
            DocTypes.Add("Custom");//allow user to specify custom extension such as .txt
            CusDocType = "";// the custom value

            DocSize = 0;

            DocBeginDate = System.DateTime.Now;
            DocEndDate = System.DateTime.Now;

            TextinName = "";
        }

        public List<string> getAllSitesInSiteCollection()
        {
            List<string> SiteNames = new List<string>();

            using (SPSite site = new SPSite(SiteUrl))
            {
                SPWebCollection webcoll = site.AllWebs;
                foreach (SPWeb w in webcoll)
                {
                    SiteNames.Add(w.Title);
                    w.Dispose();
                }
            }

            return (SiteNames);
        }

        public string getSiteUrl(string SiteTitle)
        {
            string WebUrl = "";

            using (SPSite site = new SPSite(SiteUrl))
            {
                SPWebCollection webcoll = site.AllWebs;
                foreach (SPWeb w in webcoll)
                {
                    if (w.Title == SiteTitle)
                    {
                        WebUrl = w.ServerRelativeUrl;
                        w.Dispose();
                        break;
                    }
                    w.Dispose();
                }
            }

            return (WebUrl);
        }

        public List<string> getAllUsersInSiteCollection()
        {
            List<string> UserNames = new List<string>();

            using (SPSite site = new SPSite(SiteUrl))
            {
                SPUserCollection usercoll = site.RootWeb.SiteUsers;
                foreach (SPUser user in usercoll)
                {
                    UserNames.Add(user.Name);
                }
            }

            return (UserNames);
        }

        public string getUserLoginName(string UserName)
        {
            string t = "";

            using (SPSite site = new SPSite(SiteUrl))
            {
                SPUserCollection usercoll = site.RootWeb.SiteUsers;
                foreach (SPUser user in usercoll)
                {
                    if (user.Name == UserName)
                    {
                        t = user.LoginName;
                        break;
                    }
                }
            }

            return (t);
        }

        // Specific files according to user criteria in single site
        public List<string> _getSpecificDocsInSingleSite(string SiteTitle)
        {
            List<string> FileRefs = new List<string>();
            SPSiteDataQuery DocFilesQuery;

            using (SPSite site = new SPSite(SiteUrl))
            {
                // 1: get file ref of files inside document libraries their decsendents including hidden ones
                using (SPWeb web = site.AllWebs[getSiteUrl(SiteTitle)])
                {
                    user = null;
                    if (UserLoginName != "")
                        user = web.EnsureUser(UserLoginName);// only when specific user

                    DocFilesQuery = new SPSiteDataQuery();

                    DocFilesQuery.Lists = "<Lists BaseType='1' /><Lists Hidden = \"TRUE\" />";// generic list // better!
                    //query.Lists = "<Lists ServerTemplate='101' /><Lists Hidden = \"TRUE\" />";// doc lib

                    DocFilesQuery.Query = CriteriaQuery(); // return all files

                    // Select only needed columns: file reference
                    DocFilesQuery.ViewFields = "<FieldRef Name='FileRef' />";

                    // constructring file url from GetSiteDataQuery
                    DataRowCollection filerows = web.GetSiteData(DocFilesQuery).Rows;
                    foreach (DataRow row in filerows)
                    {
                        // add relativeUrl into FileRef collection
                        FileRefs.Add(getRelativeFileRef(row["FileRef"].ToString()));
                    }
                    
                    // site specific attachments
                    SPListCollection listcoll = web.Lists;
                    foreach (SPList list in listcoll)
                    {
                        SPFolderCollection foldercoll = list.RootFolder.SubFolders;
                        foreach (SPFolder folder in foldercoll)
                        {
                            if (folder.Name == "Attachments")
                            {
                                SPFolderCollection attachmentFolders = folder.SubFolders;
                                foreach (SPFolder itemFolder in attachmentFolders)
                                {
                                    SPFileCollection files = itemFolder.Files;
                                    foreach (SPFile file in files)
                                    {
                                        if (CriteriaApply(file))
                                            FileRefs.Add(file.ServerRelativeUrl);
                                    }
                                }
                                break;
                            }
                        }

                    }
                }
            }
            return (FileRefs);
        }

        // All files across site collection
        public List<string> _getAllDocsInSiteCollection()
        {
            List<string> FileRefs = new List<string>();
            SPSiteDataQuery DocFilesQuery;
            
            using (SPSite site = new SPSite(SiteUrl))
            {
                //using (SPWeb web = site.OpenWeb("/"))
                using (SPWeb web = site.OpenWeb())
                {
                    user = null;
                    if (UserLoginName != "")
                        user = web.EnsureUser(UserLoginName);// only when specific user

                    DocFilesQuery = new SPSiteDataQuery();

                    DocFilesQuery.Lists = "<Lists BaseType='1' /><Lists Hidden = \"TRUE\" />";// generic list // better!
                    //query.Lists = "<Lists ServerTemplate='101' /><Lists Hidden = \"TRUE\" />";// doc lib

                    DocFilesQuery.Query = CriteriaQuery(); // return all files

                    // Select only needed columns: file reference
                    DocFilesQuery.ViewFields = "<FieldRef Name='FileRef' />";

                    // Search in all webs of the site collection
                    DocFilesQuery.Webs = "<Webs Scope='SiteCollection' />";

                    // constructring file url from GetSiteDataQuery
                    DataRowCollection filerows = web.GetSiteData(DocFilesQuery).Rows;
                    foreach (DataRow row in filerows)
                    {
                        // add relativeUrl into FileRef collection
                        FileRefs.Add(getRelativeFileRef(row["FileRef"].ToString()));
                    }

                    // All attachments
                    SPListCollection listcoll = web.Lists;
                    foreach (SPList list in listcoll)
                    {
                        SPFolderCollection foldercoll = list.RootFolder.SubFolders;
                        foreach (SPFolder folder in foldercoll)
                        {
                            if (folder.Name == "Attachments")
                            {
                                SPFolderCollection attachmentFolders = folder.SubFolders;
                                foreach (SPFolder itemFolder in attachmentFolders)
                                {
                                    SPFileCollection files = itemFolder.Files;
                                    foreach (SPFile file in files)
                                    {
                                        FileRefs.Add(file.ServerRelativeUrl);
                                    }
                                }
                                break;
                            }
                        }

                    }
                }
            }

            return (FileRefs);
        }

        // Specific files according to user criteria in all sites
        public List<string> _getSpecificDocsInSiteCollection()
        {
            List<string> FileRefs = new List<string>();
            SPSiteDataQuery DocFilesQuery;

            using (SPSite site = new SPSite(SiteUrl))
            {
                //using (SPWeb web = site.OpenWeb("/"))
                using (SPWeb web = site.OpenWeb())
                {
                    user = null;
                    if (UserLoginName != "")
                        user = web.EnsureUser(UserLoginName);// only when specific user

                    DocFilesQuery = new SPSiteDataQuery();

                    DocFilesQuery.Lists = "<Lists BaseType='1' /><Lists Hidden = \"TRUE\" />";// generic list // better!
                    //query.Lists = "<Lists ServerTemplate='101' /><Lists Hidden = \"TRUE\" />";// doc lib

                    DocFilesQuery.Query = CriteriaQuery();

                    // Select only needed columns: file reference
                    DocFilesQuery.ViewFields = "<FieldRef Name='FileRef' />";

                    // Search in all webs of the site collection
                    DocFilesQuery.Webs = "<Webs Scope='SiteCollection' />";

                    // constructring file url from GetSiteDataQuery
                    DataRowCollection filerows = web.GetSiteData(DocFilesQuery).Rows;
                    foreach (DataRow row in filerows)
                    {
                        // add relativeUrl into FileRef collection
                        FileRefs.Add(getRelativeFileRef(row["FileRef"].ToString()));
                    }


                    // specific attachments
                    SPListCollection listcoll = web.Lists;
                    foreach (SPList list in listcoll)
                    {
                        SPFolderCollection foldercoll = list.RootFolder.SubFolders;
                        foreach (SPFolder folder in foldercoll)
                        {
                            if (folder.Name == "Attachments")
                            {
                                SPFolderCollection attachmentFolders = folder.SubFolders;
                                foreach (SPFolder itemFolder in attachmentFolders)
                                {
                                    SPFileCollection files = itemFolder.Files;
                                    foreach (SPFile file in files)
                                    {
                                        if (CriteriaApply(file))
                                            FileRefs.Add(file.ServerRelativeUrl);
                                    }
                                }
                                break;
                            }
                        }

                    }
                }
            }

            return (FileRefs);
        }

        // construct the CAML query based on user criteria
        private string CriteriaQuery()
        {
            string qry = string.Empty;
            QueryBuilder qBuilder = new QueryBuilder();

            //----------------------------------------------------------------------------------------------------------
            // By Type
            if (DocTypeSelection == FilterType.MSOffice)
            {
                // first condition is without op parameter

                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>doc</Value>
                                            </Eq>");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>docx</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>xls</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>xlsx</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>ppt</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>pptx</Value>
                                            </Eq>", "OR");
            }

            else if (DocTypeSelection == FilterType.AdobePDF)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>pdf</Value>
                                            </Eq>");
            }

            else if (DocTypeSelection == FilterType.Images)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>jpg</Value>
                                            </Eq>");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>jpeg</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>bmp</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>png</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>gif</Value>
                                            </Eq>", "OR");

            }

            else if (DocTypeSelection == FilterType.Videos)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>avi</Value>
                                            </Eq>");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>mpg</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>wmv</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>mp4</Value>
                                            </Eq>", "OR");
            }

            else if (DocTypeSelection == FilterType.Audio)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>mp3</Value>
                                            </Eq>");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>wav</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>wma</Value>
                                            </Eq>", "OR");
            }
            else if (DocTypeSelection == FilterType.Web)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>htm</Value>
                                            </Eq>");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>aspx</Value>
                                            </Eq>", "OR");
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='DocIcon' />
                                                <Value Type='Computed'>xml</Value>
                                            </Eq>", "OR");
            }

            else if (DocTypeSelection == FilterType.Custom)
            {
                // first condition is without op parameter
                qBuilder.addCondition(@"<Eq>
                                                  <FieldRef Name='DocIcon' />
                                                  <Value Type='Computed'>" + CusDocType + @"</Value>
                                             </Eq>");
            }

            // All types
            else
            {
                // dummy first condition for All Types
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='FSObjType'/>
                                                <Value Type='Lookup'>0</Value>
                                              </Eq>");
            }
            //----------------------------------------------------------------------------------------------------------
            // for retrieving files only not folders
            qBuilder.addCondition(@"<Eq>
                                              <FieldRef Name='FSObjType'/>
                                              <Value Type='Lookup'>0</Value>
                                          </Eq>", "AND");
            //----------------------------------------------------------------------------------------------------------
            // by User
            if (UserSelection == FilterUser.SpecificCreatedByUser)
            {
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='Author' LookupId='TRUE' />
                                                <Value Type='User'>" + user.ID + @"</Value>
                                              </Eq>", "AND");
            }
            if (UserSelection == FilterUser.SpecifiModifiedByUSer)
            {
                qBuilder.addCondition(@"<Eq>
                                                <FieldRef Name='Editor' LookupId='TRUE' />
                                                <Value Type='User'>" + user.ID + @"</Value>
                                              </Eq>", "AND");
            }

            //----------------------------------------------------------------------------------------------------------

            // by Size
            qBuilder.addCondition(@"<Geq>
                                            <FieldRef Name='File_x0020_Size' />
                                            <Value Type='Lookup'>" + DocSize.ToString() + @"</Value>
                                          </Geq>", "AND");

            //----------------------------------------------------------------------------------------------------------


            // by Date
            if (DocDateSelection == FilterDate.SpecificCreatedDate)
            {
                qBuilder.addCondition(@"<Geq>
                                                <FieldRef Name='Created' />
                                                <Value Type='DateTime'>" + SPUtility.CreateISO8601DateTimeFromSystemDateTime(DocBeginDate) + @"</Value>
                                              </Geq>", "AND");
                qBuilder.addCondition(@"<Leq>
                                                <FieldRef Name='Created' />
                                                <Value Type='DateTime'>" + SPUtility.CreateISO8601DateTimeFromSystemDateTime(DocEndDate) + @"</Value>
                                              </Leq>", "AND");
            }
            else if (DocDateSelection == FilterDate.SpecificModifiedDate)
            {
                qBuilder.addCondition(@"<Geq>
                                                <FieldRef Name='Modified' />
                                                <Value Type='DateTime'>" + SPUtility.CreateISO8601DateTimeFromSystemDateTime(DocBeginDate) + @"</Value>
                                              </Geq>", "AND");
                qBuilder.addCondition(@"<Leq>
                                                <FieldRef Name='Modified' />
                                                <Value Type='DateTime'>" + SPUtility.CreateISO8601DateTimeFromSystemDateTime(DocEndDate) + @"</Value>
                                              </Leq>", "AND");
            }

            //----------------------------------------------------------------------------------------------------------

            // by Text
            if (NameTextSelection == FilterText.SpecificText)
            {
                qBuilder.addCondition(@"<Contains>
                                                <FieldRef Name='FileLeafRef'/>
                                                <Value Type='Text'>" + TextinName + @"</Value>
                                              </Contains>", "AND");
            }


            //----------------------------------------------------------------------------------------------------------

            qry = qBuilder.constructQuery();

            return (qry);
        }

        // Indicate if an attachment file corresponds to all criteria conditions
        private bool CriteriaApply(SPFile AttachmentFile)
        {
            bool result = true;

            // this is similar to CriteriaQuery()
            result = UserCriteriaApply(AttachmentFile) && TypeCriteriaApply(AttachmentFile) && SizeCriteriaApply(AttachmentFile) &&
                DateCriteriaApply(AttachmentFile) && TextCriteriaAppy(AttachmentFile);

            return (result);
        }

        private bool UserCriteriaApply(SPFile AttachmentFile)
        {
            if (UserSelection == FilterUser.AllUsers)
            {
                return (true);
            }
            else
            {
                try
                {

                    if (UserSelection == FilterUser.SpecificCreatedByUser)
                    {
                        if (AttachmentFile.Author.ID == user.ID) return (true);
                    }
                    else if (UserSelection == FilterUser.SpecifiModifiedByUSer)
                    {
                        if (AttachmentFile.ModifiedBy.ID == user.ID) return (true);
                    }
                }
                catch (Exception e)
                {
                    // file Author or Editor could not be found
                }
            }

            return (false);
        }

        private bool TypeCriteriaApply(SPFile AttachmentFile)
        {
            try
            {
                string FileExt = fetFileExtension(AttachmentFile).ToUpper();

                if (DocTypeSelection == FilterType.AllTypes)
                {
                    return (true);
                }
                else if (DocTypeSelection == FilterType.MSOffice)
                {
                    if (FileExt == "DOC" || FileExt == "DOCX" || FileExt == "XLS" || FileExt == "XLSX" || FileExt == "PPT" || FileExt == "PPTX") return (true);
                }
                else if (DocTypeSelection == FilterType.AdobePDF)
                {
                    if (FileExt == "PDF") return (true);
                }
                else if (DocTypeSelection == FilterType.Images)
                {
                    if (FileExt == "BMP" || FileExt == "JPG" || FileExt == "JPEG" || FileExt == "PNG" || FileExt == "GIF") return (true);
                }
                else if (DocTypeSelection == FilterType.Videos)
                {
                    if (FileExt == "AVI" || FileExt == "MPEG" || FileExt == "WMV" || FileExt == "MP4") return (true);
                }
                else if (DocTypeSelection == FilterType.Audio)
                {
                    if (FileExt == "WAV" || FileExt == "MP3" || FileExt == "WMA" || FileExt == "PNG") return (true);
                }
                else if (DocTypeSelection == FilterType.Web)
                {
                    if (FileExt == "HTM" || FileExt == "ASPX" || FileExt == "XML") return (true);
                }
                else if (DocTypeSelection == FilterType.Custom)
                {
                    if (FileExt == CusDocType) return (true);
                }
            }
            catch (Exception e)
            {
                //
            }

            return (false);
        }

        private bool SizeCriteriaApply(SPFile AttachmentFile)
        {
            try
            {
                byte[] fileData = AttachmentFile.OpenBinary();
                if (fileData.Length > DocSize) return (true);
            }
            catch (Exception e)
            {
                //
            }

            return (false);
        }

        private bool DateCriteriaApply(SPFile AttachmentFile)
        {
            try
            {
                if (DocDateSelection == FilterDate.AllDates)
                {
                    return (true);
                }
                else if (DocDateSelection == FilterDate.SpecificCreatedDate)
                {
                    if (
                        (AttachmentFile.TimeCreated.CompareTo(DocBeginDate) >= 0) &&
                        (AttachmentFile.TimeCreated.CompareTo(DocEndDate) <= 0)
                        )
                        return (true);
                }
                else if (DocDateSelection == FilterDate.SpecificModifiedDate)
                {
                    if (
                        (AttachmentFile.TimeLastModified.CompareTo(DocBeginDate) >= 0) &&
                        (AttachmentFile.TimeLastModified.CompareTo(DocEndDate) <= 0)
                        )
                        return (true);
                }
            }
            catch (Exception e)
            {
                //
            }
            return (false);
        }

        private bool TextCriteriaAppy(SPFile AttachmentFile)
        {
            try
            {
                string FileTitle = AttachmentFile.Name.Remove(AttachmentFile.Name.IndexOf('.')).ToUpper();
                if (FileTitle.Contains(TextinName.ToUpper())) return (true);
            }
            catch (Exception e)
            {
                //
            }

            return (false);
        }

        //convert SPFile into byte array
        public byte[] getFileData(string relativeFileUrl)
        {
            SPFile spfile;

            using (SPSite site = new SPSite(SiteUrl))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    spfile = web.GetFile(relativeFileUrl);
                }
            }

            return (spfile.OpenBinary());
        }

        public string getFullUrl(string relativeUrl)
        {
            string url = "";

            using (SPSite site = new SPSite(SiteUrl))
            {
                url = site.MakeFullUrl(relativeUrl);
            }
            return (url);
        }

        // returns only the extension: JPG, PDF,..
        private string fetFileExtension(SPFile file)
        {
            return (file.Name.Substring(file.Name.IndexOf('.') + 1));
        }

        // get all WebApplications availble on current WFE machine
        public List<string> getAvailableWebAppsOnMachine()
        {
            List<string> WebNames = new List<string>();
            
            SPWebServiceCollection webServices = new SPWebServiceCollection(SPFarm.Local);
            foreach (SPWebService webService in webServices)
            {
                SPWebApplicationCollection webappcoll = webService.WebApplications;
                foreach (SPWebApplication webApp in webappcoll)
                {
                    // only include the data web apps not configuration (central admin)
                    if (!webApp.IsAdministrationWebApplication)
                        WebNames.Add(webApp.Name);
                    //url = webApp.GetResponseUri(SPUrlZone.Default).AbsoluteUri);
                }
            }
            
            // sort + reverse so that sharepoint-80 is shown first
            WebNames.Sort();
            WebNames.Reverse();
            return (WebNames);
        }

        public List<string> getSiteCollectionsInWebApp(string WebAppName)
        {
            List<string> SiteCollNames = new List<string>();

            SPWebServiceCollection webServices = new SPWebServiceCollection(SPFarm.Local);
            foreach (SPWebService webService in webServices)
            {
                SPWebApplicationCollection webappcoll = webService.WebApplications;
                foreach (SPWebApplication webApp in webappcoll)
                {
                    if (webApp.Name == WebAppName)
                    {
                        SPSiteCollection sitecoll = webApp.Sites;
                        foreach (SPSite Site in sitecoll)
                        {
                            SiteCollNames.Add(Site.Url);
                            Site.Dispose();
                        }
                        return (SiteCollNames);
                    }
                }
            }
           return (SiteCollNames);
        }

        private string getRelativeFileRef(string rUrl)
        {
            rUrl = rUrl.ToLower();

            rUrl = rUrl.Substring(rUrl.IndexOf("#") + 1);

            while (rUrl.Contains("sites"))
            {
                // to pass after 'sites/'
                rUrl = rUrl.Substring(rUrl.IndexOf("sites") + 6);

                // to pass after the first site name,
                 rUrl = rUrl.Substring(rUrl.IndexOf("/") + 1);

                // Example: http://dev/sites/ibr/.. --> so substring will start after last '/'
            }
            return rUrl;
        }
    } 
}
