﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using OpenQA.Selenium;

namespace Microsoft.Dynamics365.UIAutomation.Browser
{
    public class BrowserOptions
    {
        public BrowserOptions()
        {
//            this.DriversPath = Path.Combine(Directory.GetCurrentDirectory()); //, @"Drivers\");
            this.BrowserType = BrowserType.Chrome;
            this.PageLoadTimeout = new TimeSpan(0, 3, 0);
            this.CommandTimeout = new TimeSpan(0, 10, 0);
            this.StartMaximized = true;
            this.FireEvents = false;
            this.TraceSource = Constants.DefaultTraceSource;
            this.EnableRecording = false;
            this.RecordingScanInterval = TimeSpan.FromMilliseconds(Constants.Browser.Recording.DefaultScanInterval);
            this.Credentials = BrowserCredentials.Default;
            this.HideDiagnosticWindow = true;
            this.Height = null;
            this.Width = null;
            this.Headless = true;
            this.UCITestMode = true;
        }

        public BrowserType RemoteBrowserType { get; set; }
        public Uri RemoteHubServer { get; set; }
        public BrowserType BrowserType { get; set; }
        public BrowserCredentials Credentials { get; set; }
        public string DriversPath { get; set; }
        public bool PrivateMode { get; set; }
        public bool CleanSession { get; set; }
        public TimeSpan PageLoadTimeout { get; set; }
        public TimeSpan CommandTimeout { get; set; }
        /// <summary>
        /// When <see langword="true" /> the browser will open maximized at the highest supported resolution.
        /// </summary>
        public bool StartMaximized { get; set; }
        public bool FireEvents { get; set; }
        public bool EnableRecording { get; set; }
        public TimeSpan RecordingScanInterval { get; set; }
        public string TraceSource { get; set; }
        public bool HideDiagnosticWindow { get; set; }
        public bool Headless { get; set; }
        public bool UserAgent { get; set; }
        public string UserAgentValue { get; set; }
        public int DefaultThinkTime { get; set; }
        /// <summary>
        /// Gets or sets the browser height when <see cref="StartMaximized"/> is <see langword="false" />. Both <see cref="Height"/> and <see cref="Width"/> must be set.
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// Gets or sets the browser width when Both <see cref="StartMaximized"/> is <see langword="false" />. Both <see cref="Height"/> and <see cref="Width"/> must be set.
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Gets or sets the TestMode flag for the UnifiedInterface. This flag should not be used when capturing performance measurements
        /// This flag introduces full loading patterns that are not typical of a normal user experience, but are required for full DOM interaction.
        /// Please raise any issues with this TestMode being enabled to the Microsoft/EasyRepro community on GitHub for review.
        /// </summary>
        public bool UCITestMode { get; set; }

        public virtual ChromeOptions ToChrome()
        {
            var options = new ChromeOptions();

            // For running in container
            options.AddArguments(new String[] { "--disable-dev-shm-usage", "--no-sandbox", "--no-startup-window", "--silent-launch", "--headless", "--start-maximized", "--window-size=1920,1080" });

            return options;
        }
        
        public virtual InternetExplorerOptions ToInternetExplorer()
        {
            // Not supportd on .net5
            return null;
        }

        public  virtual FirefoxOptions ToFireFox()
        {
            var options = new FirefoxOptions()
            {
                UseLegacyImplementation = false
            };

            return options;
        }

        public virtual EdgeOptions ToEdge()
        {
            var options = new EdgeOptions()
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            return options;
        }
    }
}