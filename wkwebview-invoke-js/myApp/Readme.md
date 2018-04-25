# Steps to repro
1. Open the ui-tests/ui-tests/ui-tests.sln
2. Run the iOS Verify_InvokeJS_WKWebView test
    - Expected : Succeeds, because you can invoke JS within a WKWebView 
    - Actual : Fails, because InvokeJS throws an exception