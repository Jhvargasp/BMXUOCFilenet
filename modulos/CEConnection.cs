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
        public void EstablishCredentials(String userName, String password, String uri)
        {
            UsernameCredentials cred = new UsernameCredentials(userName, password);
            // now associate this Credentials with the whole process
            ClientContext.SetProcessCredentials(cred);
            IConnection connection = Factory.Connection.GetConnection(uri);
            isCredetialsEstablished = true;
            IntializeVariables(connection);
        }

        //
        // Retrieves the Domain and ObjectStore information from CE represented by
        // IConnection object. 
        //
        private void IntializeVariables(IConnection connection)
        {
            domain = Factory.Domain.FetchInstance(connection, null, null);
            domainName = domain.Name;
            ost = domain.ObjectStores;
            SetOSNames();
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
            IObjectStore os = Factory.ObjectStore.FetchInstance(domain, name, null);
            return os;
        }

        internal IPropertyDescriptionList getPropertiesDescriptions(IObjectStore oLibrary, string[] asClasses)
        {
            IClassDescription objClassDesc = ClassDescription.FetchInstance(oLibrary, asClasses[0], null);
            return objClassDesc.PropertyDescriptions;

        }
    }
}
