DocExtractor
============

A Bulk file download and criteria-based utility for SharePoint.


Features:
* The user can either select to download all files on the site collection without exception, or to specify desired 
criteria in no time. 

* Criteria can be any combination of the following:
- Site(s), 
- User(s) and his/her role (Author/ Modifier) , 
- File type (groups of formats in MS Office, PDF, Images, Videos, Audio, Web and custom), 
- File size (in B/KB/MB)
- File creation/modification date period
- Text in title (a 'Contains' Filter)

* All lists and libraries (including hidden ones) will be searched, and the tool will download last checked-in 
  version of each file, as well as list attachments.
* We can choose whether to download the files with or without its folders hierarchy. If the latter option used 
  then the tool will rename file copies automatically on the output directory. 
* User can cancel the download operation at any time, 
* User will see colored notifications about the download status. 
* After download is completed, a log file is created to show all the download details and errors if any.
* Tested in SharePoint 2010 Foundation
