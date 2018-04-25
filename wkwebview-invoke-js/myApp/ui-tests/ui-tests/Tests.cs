using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace uitests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Verify_InvokeJS_WKWebView()
        {
            //WKWebView is not returned as a default WebView
            var webViewDetected = app.Query(c => c.WebView());
            Assert.IsFalse(webViewDetected.Any());

            //You can query for WKWebView by class
            var wkWebViewByClass = app.Query(c => c.Class("WKWebView"));
            Assert.AreEqual(wkWebViewByClass.Length,1);

            //Css Query should return html elements
			var htmlElementsByCssSelector = app.Query(c => c.Class("WKWebView").Css("*"));
            Assert.GreaterOrEqual(htmlElementsByCssSelector.Length, 1);

			//InvokeJS should not throw an exception, but it throws Javascript invoked on non-webview
            Assert.DoesNotThrow(() => app.Query(c => c.Class("WKWebView").InvokeJS("alert('Hello')")));
        }
    }
}
