using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Text;

using kcptun_gui.Common;

namespace kcptun_gui.Controller
{
    public class UpdateChecker
    {
        public const string GUI_VERSION = "1.5.8";

        public const string GUI_RELEASE_PAGE = "https://github.com/GangZhuo/kcptun-gui-windows/releases";
        public const string KCPTUN_RELEASE_PAGE = "https://github.com/xtaci/kcptun/releases";


        private const string GUI_UPDATE_API_URL = "https://api.github.com/repos/GangZhuo/kcptun-gui-windows/releases/latest";
        private const string KCPTUN_UPDATE_API_URL = "https://api.github.com/repos/xtaci/kcptun/releases/latest";
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";

        private MainController controller;

        public event EventHandler<CheckUpdateEventArgs> CheckUpdateCompleted;

        public event EventHandler<DownloadEventArgs> DownloadCompleted;

        public UpdateChecker(MainController controller)
        {
            this.controller = controller;
        }

        #region Check Update

        public void CheckUpdateForGUI(int delay = 0, object userState = null)
        {
            CheckUpdateState state = new CheckUpdateState
            {
                app = App.GUI,
                apiUrl = GUI_UPDATE_API_URL,
                currentVersion = GUI_VERSION,
                userState = userState
            };
            CheckUpdate(state, delay);
        }

        public void CheckUpdateForKCPTun(int delay = 0, object userState = null)
        {
            string version = controller.KCPTunnelController.GetKcptunVersionNumber();
            CheckUpdateState state = new CheckUpdateState
            {
                app = App.KCPTun,
                apiUrl = KCPTUN_UPDATE_API_URL,
                currentVersion = version,
                userState = userState
            };
            CheckUpdate(state, delay);
        }

        private void CheckUpdate(CheckUpdateState state, int delay = 0)
        {
            if (delay > 0)
            {
                CheckUpdateTimer timer = new CheckUpdateTimer(delay);
                timer.State = state;
                timer.AutoReset = false;
                timer.Elapsed += Timer_Elapsed;
                timer.Enabled = true;
            }
            else
            {
                CheckUpdate(state);
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckUpdateTimer timer = (CheckUpdateTimer)sender;
            CheckUpdateState state = timer.State;
            timer.Elapsed -= Timer_Elapsed;
            timer.Enabled = false;
            timer.Dispose();
            CheckUpdate(state);
        }

        private void CheckUpdate(CheckUpdateState state)
        {
            try
            {
                Logging.Debug($"Checking updates... - {state.apiUrl}");
                if (string.IsNullOrEmpty(state.currentVersion))
                {
                    if (CheckUpdateCompleted != null)
                    {
                        CheckUpdateCompleted.Invoke(this, new CheckUpdateEventArgs()
                        {
                            App = state.app,
                            ApiUrl = state.apiUrl,
                            CurrentVersion = state.currentVersion,
                            UserState = state.userState
                        });
                    }
                }
                else
                {
                    WebClient http = CreateWebClient();
                    http.Encoding = Encoding.UTF8;
                    http.DownloadStringCompleted += http_DownloadStringCompleted;
                    http.DownloadStringAsync(new Uri(state.apiUrl), state);
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                CheckUpdateState state = (CheckUpdateState)e.UserState;

                string response = e.Result;

                JObject release = JObject.Parse(response);

                CheckUpdateEventArgs args = new CheckUpdateEventArgs();
                args.App = state.app;
                args.ApiUrl = state.apiUrl;
                args.CurrentVersion = state.currentVersion;
                args.UserState = state.userState;
                if (release != null)
                {
                    foreach (JObject asset in (JArray)release["assets"])
                    {
                        Release ass = new Release() { app = state.app };
                        ass.Parse(asset);
                        if (ass.IsNewVersion(state.currentVersion))
                        {
                            args.ReleaseList.Add(ass);
                        }
                    }
                }
                if (CheckUpdateCompleted != null)
                    CheckUpdateCompleted(this, args);
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        #endregion

        #region Download File

        public void Download(Release release)
        {
            DownloadState state = new DownloadState
            {
                release = release,
                saveTo = Utils.GetTempPath(release.name),
                percent = 0
            };
            Download(state);
        }

        private void Download(DownloadState state)
        {
            try
            {
                WebClient http = CreateWebClient();
                http.DownloadFileCompleted += Http_DownloadFileCompleted;
                http.DownloadProgressChanged += Http_DownloadProgressChanged;
                state.percent = 0;
                http.DownloadFileAsync(new Uri(state.release.browser_download_url), state.saveTo, state);
                Console.WriteLine($"Downloading {state.release.browser_download_url}...");
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void Http_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                DownloadState state = (DownloadState)e.UserState;
                if (state.percent != e.ProgressPercentage)
                {
                    state.percent = e.ProgressPercentage;
                    Console.WriteLine($"{e.ProgressPercentage}%  {e.BytesReceived}/{e.TotalBytesToReceive} Bytes");
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void Http_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                DownloadState state = (DownloadState)e.UserState;
                DownloadEventArgs args = new DownloadEventArgs();
                args.Error = e.Error;
                args.SaveTo = state.saveTo;
                args.Release = state.release;
                args.UserState = state.userState;
                if (e.Error != null)
                    Logging.LogUsefulException(e.Error);
                if (DownloadCompleted != null)
                    DownloadCompleted.Invoke(this, args);
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        #endregion

        private WebClient CreateWebClient()
        {
            WebClient http = new WebClient();
            http.Headers.Add("User-Agent", UserAgent);
            http.Proxy = WebRequest.GetSystemWebProxy();
            return http;
        }

        private void SortByVersions(List<Release> asserts)
        {
            asserts.Sort(new ReleaseComparer());
        }

        class CheckUpdateTimer : System.Timers.Timer
        {
            public CheckUpdateState State { get; set; }

            public CheckUpdateTimer(int p) : base(p)
            {
            }
        }

        public enum App
        {
            None,
            GUI,
            KCPTun
        }

        public class Release
        {
            public App app;

            public bool prerelease;
            public string name;
            public string version;
            public string browser_download_url;
            public string url;
            public long size;

            public bool IsNewVersion(string currentVersion)
            {
                if (prerelease)
                {
                    return false;
                }
                if (string.IsNullOrEmpty(version))
                {
                    return false;
                }
                return CompareVersion(version, currentVersion) > 0;
            }

            public void Parse(JObject asset)
            {
                name = (string)asset["name"];
                browser_download_url = (string)asset["browser_download_url"];
                version = ParseVersionFromURL(browser_download_url);
                prerelease = browser_download_url.IndexOf("prerelease") >= 0;
                url = (string)asset["url"];
                size = (long)asset["size"];
            }

            private static string ParseVersionFromURL(string url)
            {
                Match match = Regex.Match(url, @".*/download/v?([\d\.]+)/.*", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    if (match.Groups.Count == 2)
                    {
                        return match.Groups[1].Value;
                    }
                }
                return null;
            }

            public static int CompareVersion(string l, string r)
            {
                var ls = l.Split('.');
                var rs = r.Split('.');
                for (int i = 0; i < Math.Max(ls.Length, rs.Length); i++)
                {
                    int lp = (i < ls.Length) ? int.Parse(ls[i]) : 0;
                    int rp = (i < rs.Length) ? int.Parse(rs[i]) : 0;
                    if (lp != rp)
                    {
                        return lp - rp;
                    }
                }
                return 0;
            }
        }

        public class CheckUpdateEventArgs : EventArgs
        {
            public App App { get; set; }

            public string ApiUrl { get; set; }

            public string CurrentVersion { get; set; }

            public object UserState { get; set; }

            public List<Release> ReleaseList { get; private set; } = new List<Release>();
        }

        class ReleaseComparer : IComparer<Release>
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed. 
            public int Compare(Release x, Release y)
            {
                return Release.CompareVersion(x.version, y.version);
            }
        }

        class CheckUpdateState
        {
            public App app;
            public string apiUrl;
            public string currentVersion;
            public object userState;
        }

        class DownloadState
        {
            public Release release;
            public string saveTo;
            public int percent;
            public object userState;
        }

        public class DownloadEventArgs : EventArgs
        {
            public Exception Error { get; set; }

            public Release Release { get; set; }

            public string SaveTo { get; set; }

            public object UserState { get; set; }
        }
    }
}
