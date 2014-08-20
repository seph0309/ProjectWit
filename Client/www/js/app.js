// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function () {

    /* ---------------------------------- Local Variables ---------------------------------- */
    HomeView.prototype.template = Handlebars.compile($("#home-tpl").html());
    SnapDrawerView.prototype.template = Handlebars.compile($("#snap-drawer-tpl").html());

    var slider = new PageSlider($('body'));
    
    router.addRoute('', function() {
        console.log('empty');
        slider.slidePage(new HomeView().render().$el);
    });

    router.start();
    
    //service.initialize().done(function () {
    //});

    /* --------------------------------- Event Registration -------------------------------- */
    document.addEventListener('deviceready', function () {
        StatusBar.overlaysWebView( false );
        StatusBar.backgroundColorByHexString('#ffffff');
        StatusBar.styleDefault();
        FastClick.attach(document.body);
        if (navigator.notification) { // Override default HTML alert with native dialog
            window.alert = function (message) {
                navigator.notification.alert(
                    message,    // message
                    null,       // callback
                    "WitMobile", // title
                    'OK'        // buttonName
                );
            };
        }
    }, false);

    /* ---------------------------------- Local Functions ---------------------------------- */

}());

/* Prevent Safari opening links when viewing as a Mobile App */
(function (a, b, c) {
    if (c in b && b[c]) {
        var d, e = a.location,
                f = /^(a|html)$/i;
        a.addEventListener("click", function (a) {
            d = a.target;
            while (!f.test(d.nodeName))
                d = d.parentNode;
            "href" in d && (d.href.indexOf("http") || ~d.href.indexOf(e.host)) && (a.preventDefault(), e.href = d.href)
        }, !1)
    }
})(document, window.navigator, "standalone");