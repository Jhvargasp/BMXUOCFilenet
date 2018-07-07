/*
       IBM grants you a nonexclusive copyright license to use all programming code 
	examples from which you can generate similar function tailored to your own 
	specific needs.

	All sample code is provided by IBM for illustrative purposes only.
	These examples have not been thoroughly tested under all conditions.  IBM, 
	therefore cannot guarantee or imply reliability, serviceability, or function of 
	these programs.

	All Programs or code component contained herein are provided to you “AS IS “ 
	without any warranties of any kind.
	The implied warranties of non-infringement, merchantability and fitness for a 
	particular purpose are expressly disclaimed.

	© Copyright IBM Corporation 2007, ALL RIGHTS RESERVED.
 */

using System;
using System.Collections.Generic;
using System.Text;
using FileNet.Api.Core;
using FileNet.Api.Collection;
using System.Collections;
using FileNet.Api.Util;
using FileNet.Api.Authentication;
using FileNet.Api.Meta;
using static FileNet.Api.Core.Factory;
using System.IO;

namespace BulkLoader
{
    //
    // Represents the connection with Content Engine.
    //
    public class CEConnection
    {
        private IDomain domain;
        private IObjectStoreSet ost;
        private ArrayList osNames;
        private String domainName;
        private bool isCredetialsEstablished;
                
        //
        // Constructor
        //
        public CEConnection()
        {
            domain = null;
            ost = null;
            osNames = new ArrayList();
            domainName = null;
            isCredetialsEstablished = false;
        }

        //
        // This method establishes user credentials with the Content Engine on a process basis.
        // Once credentials are established, you can make API calls to CE.
        //
        IObjectStore os;
        public void EstablishCredentials(String userName, String password, String uri,String osName)
        {
            //IConnection  conn = Factory.Connection.GetConnection(uri);
            //Subject subject = UserContext.createSubject(conn, username, password, null);
            //UserContext.get().pushSubject(subject);

            UsernameCredentials cred = new UsernameCredentials(userName, password);
            // now associate this Credentials with the whole process
            ClientContext.SetProcessCredentials(cred);
            IConnection connection = Factory.Connection.GetConnection(uri);
            IDomain domain = Factory.Domain.GetInstance(connection, null);
            isCredetialsEstablished = true;
            os = Factory.ObjectStore.FetchInstance(domain, osName, null);

            //domainName = domain.Name;
            //ost = domain.ObjectStores;
            //SetOSNames();
        }


        //
        // Intializes the ArrayList osNames with object store names.
        //
        private void SetOSNames()
        {
            IEnumerator ie = ost.GetEnumerator();
            while (ie.MoveNext())
            {
                IObjectStore os = (IObjectStore)ie.Current;
                osNames.Add(os.DisplayName);
            }
        }

        //
        // Returns the osNames ArrayList.
        //
        public ArrayList GetOSNames()
        {
            return osNames;
        }

        //
        // Returns the domain (IDomain object).
        //
        public IDomain GetDomain()
        {
            return domain;
        }

        //
        // Returns the domain name.
        //
        public String GetDomainName()
        {
            return domainName;
        }

        //
        // Returns true or false based on whether credentials have been
        // established with CE or not.
        //
        public bool IsCredentialsEstablished()
        {
            return isCredetialsEstablished;
        }

        //
        // Fetches the ObjectStore object using given name.
        //
        public IObjectStore FetchOS(String name)
        {
            //IObjectStore os = Factory.ObjectStore.FetchInstance(domain, name, null);
            return os;
        }

        internal IPropertyDescriptionList getPropertiesDescriptions(IObjectStore oLibrary, string[] asClasses)
        {
            IClassDescription objClassDesc = ClassDescription.FetchInstance(oLibrary, asClasses[0], null);
            //IClassDescription objClassDesc = ClassDescription.FetchInstance(oLibrary, "Document", null);
            return objClassDesc.PropertyDescriptions;

        }


        public String GetContentElement(String id) {

            //MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //FileNet.Api.Property.PropertyFilter pf = new FileNet.Api.Property.PropertyFilter();
            //pf.AddIncludeProperty(new FileNet.Api.Property.FilterElement(null, null, null, "Cont", null));

            // Get a document from the version series to be checked for downloads.
            IDocument documentObj = Factory.Document.FetchInstance(os, id, null);

            IContentTransfer cTransfer = (IContentTransfer)documentObj.ContentElements[0];

            String name = cTransfer.RetrievalName;
            Stream stream = cTransfer.AccessContentStream();
            double size = writeContent(stream, Path.GetTempPath()+"/"+ name);

            return Path.GetTempPath() + "/" + name;
        }

        private double writeContent(Stream stream, string name)
        {
            byte[] buffer = new byte[4096];
            int bufferSize;
            double size = 0;
            BinaryWriter wr = new BinaryWriter(File.Open(name, FileMode.Create));
            while ((bufferSize=stream.Read(buffer,0,buffer.Length))!=0) {
                size += bufferSize;
                wr.Write(buffer, 0, bufferSize);
            }
            wr.Close();
            stream.Close();
            return size;
        }
    }
}
